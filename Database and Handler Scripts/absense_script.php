<?php
	include('configuration.php');
	//include('local_configuration/configuration.php');
	use Carbon\Carbon;
	require 'libs/Carbon/Carbon.php';
	date_default_timezone_set('Asia/Dhaka');
	$today = new Carbon();
	$today-> hour = 0;
	$today-> minute = 0;
	$today-> second = 0;
	$conn;
	try
	{
		$conn = new PDO("mysql:host=$host;dbname=$db",$user,$pw);
	}
	catch(PDOException $e)
	{
		die("Couldn't connect to database");
	}
	// if($today -> dayOfWeek > 4)
	// {
	// 	die("Friday Or Satarday");
	// }

	if(isHoliday($conn, $today))
	{
		die("Holiday");
	}

	$e_table = $conn->query("SELECT fid, holiday FROM employee");
	if($e_table -> rowCount() == 0)
		die("");
	foreach ($e_table as $e_row)
	{
		$uid = $e_row['fid'];
		$holis = $e_row['holiday'];
		$br = false;
		for($i = 0; $i < strlen($holis); $i++)
		{
			$x = ord($holis[$i]) - 48;
			if($today -> dayOfWeek == $x)
			{
				$br = true;
				break;
			}
		}
		if($br == true)
		{
			$s = $today->toDateTimeString();
			$work_date = substr($s, 0, 10);
			$na = "N/A";
			$wh = "Weekly Holiday";
			
			$q = "INSERT INTO attendance (user_id, work_date, entry_time, late_in_seconds, exit_time, presence) VALUES ('$uid', '$work_date', 'N/A', 'N/A', 'N/A', '$wh')";
			$conn->query($q);
			continue; /// weekly holiday for this employee
		}
		$leaves = $conn->query("SELECT start_date, end_date FROM leaves WHERE uid='$uid'");
		foreach($leaves as $leave)
		{
			$ss = $leave['start_date'];
			$ee = $leave['end_date'];

			$sd = substr($ss, 0, 2);
			$sm = substr($ss, 3, 2);
			$sy = substr($ss, 6, 4);

			$ed = substr($ee, 0, 2);
			$em = substr($ee, 3, 2);
			$ey = substr($ee, 6, 4);

			$ts = Carbon::create((int)$sy, (int)$sm, (int)$sd, 0, 0, 0);
			$te = Carbon::create((int)$ey, (int)$em, (int)$ed, 23, 59, 59);

			if($today->greaterThanOrEqualTo($ts) && $today->lessThanOrEqualTo($te))
			{
				$br = true;
				break;
			}
		}

		if($br == true)
		{
			$s = $today->toDateTimeString();
			$work_date = substr($s, 0, 10);
			$na = "N/A";
			$il = "In Leave";
			$q = "INSERT INTO attendance (user_id, work_date, entry_time, late_in_seconds, exit_time, presence) VALUES ('$uid', '$work_date', 'N/A', 'N/A', 'N/A', '$il')";
			$conn->query($q);
			continue; /// in leave
		}

		$s = $today->toDateTimeString();
		$work_date = substr($s, 0, 10);
		$atd = $conn -> query("SELECT * FROM attendance WHERE user_id='$uid' AND work_date='$work_date' AND presence='Present'");
		if($atd -> rowCount() > 0)
		{
			foreach ($atd as $cd)
			{
				if($cd['exit_time'] == "")
				{
					$id = $cd['id'];
					$conn -> query("UPDATE attendance SET exit_time='Early Exit' WHERE id='$id'");
				}
			}
			continue; /// present;
		}
		$conn->query("INSERT INTO attendance (user_id, work_date, entry_time, late_in_seconds, exit_time, presence) VALUES ('$uid', '$work_date', 'N/A', 'N/A', 'N/A', 'Absent')");
	}

?>

<?php
	function isHoliday($conn, $today)
	{
		$h_table = $conn->query("SELECT * FROM holidays");
		if($h_table -> rowCount() == 0)
			return false;
		foreach ($h_table as $row)
		{
			$ss = $row['start_date'];
			$ee = $row['end_date'];

			$sd = substr($ss, 0, 2);
			$sm = substr($ss, 3, 2);

			$ed = substr($ee, 0, 2);
			$em = substr($ee, 3, 2);

			$hs = Carbon::create($today -> year, (int)$sm, (int)$sd, 0, 0, 0);
			$he = Carbon::create($today -> year, (int)$em, (int)$ed, 23, 59, 59);

			$h1 = $hs -> toDateTimeString();
			$h2 = $he -> toDateTimeString();
			$t = $today -> toDateTimeString();


			if($today->greaterThanOrEqualTo($hs) && $today->lessThanOrEqualTo($he))
				return true;
		}

		return false;
	}
?>