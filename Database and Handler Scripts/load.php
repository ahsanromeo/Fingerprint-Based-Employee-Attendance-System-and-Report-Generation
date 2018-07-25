<?php
	include('configuration.php');
	//include('local_configuration.php');
	use Carbon\Carbon;
	require 'libs/Carbon/Carbon.php';
	date_default_timezone_set('Asia/Dhaka');
	$conn;
	try
	{
		$conn = new PDO("mysql:host=$host;dbname=$db",$user,$pw);
	}
	catch(PDOException $e)
	{
		die("");
	}
	if(isset($_GET['data']))
	{
		$data = $_GET['data'];
		$len = strlen($data);

		$uid = substr($data, 0, 6);
		$bid = substr($data, 0, 3);

		$time_from_server = Carbon::now();
		
		$enroll_time = $time_from_server;

		$current_time_from_data = "";

		if($len == 26) // ok
		{
			$year = substr($data, 7, 4);
			$month = substr($data, 12, 2);
			$day = substr($data, 15, 2);
			$hour = substr($data, 18, 2);
			$minute = substr($data, 21, 2);
			$second = substr($data, 24, 2);
			$current_time_from_data = Carbon::create((int)$year, (int)$month, (int)$day, (int)$hour, (int)$minute, (int)$second);

			$diff = $time_from_server->diffInSeconds($current_time_from_data);

			if($diff > 60)
			{
				$len = 28; /// device time may be okay but differs from server time by more than 1 minute, so, marking it's as a wrong time.
			}
		}

		if($len == 26)
		{
			$enroll_time = $current_time_from_data;
		}

		$query_date = substr($enroll_time, 0, 10);

		$q = "SELECT * FROM attendance WHERE user_id='$uid' AND work_date='$query_date'";

		$table = $conn->query($q);

		$rc = (int)$table->rowCount();

		if($rc == 0) // entry
		{
		    $start_time = Carbon::now();
		    
		    $table2 = $conn->("SELECT shift_start FROM employee WHERE fid='$uid'");
		    foreach($table2 as $row2)
		    {
		        $currs = $row2['shift_start'];
		        $start_time->hour = (int)substr($currs, 0, 2);
		        if($currs[6] == 'P')
		            $start_time->hour = $start_time->hour + 12;
		        break;
		    }
			
			$start_time->minute = 0;
			$start_time->second = 0;

			$end_time = Carbon::now();
			$end_time->hour = $start_time->hour + 2; // correct one
			$end_time->minute = 0;
			$end_time->second = 0;
			if($enroll_time->gt($end_time))
			{
				die("No entry");
			}
			if($enroll_time->lt($start_time))
			{
				$enroll_time = $start_time;
			}

			$late = $enroll_time->diffInSeconds($start_time);
			$enroll_time = $enroll_time->toDateTimeString();
			$et = substr($enroll_time, 11, 8);

			$q = "INSERT INTO attendance (user_id, building_id, work_date, entry_time, late_in_seconds, presence) VALUES ('$uid', '$bid', '$query_date', '$et', '$late', 'Present')";

			if($conn->query($q))
			{
				echo "SUCCESS";
			}
			else
			{
				echo "Failed";
			}
		}
		else if($rc == 1)
		{
			$start_time = Carbon::now();
			
			$table2 = $conn->("SELECT shift_end FROM employee WHERE fid='$uid'");
		    foreach($table2 as $row2)
		    {
		        $currs = $row2['shift_start'];
		        $start_time->hour = (int)substr($currs, 0, 2);
		        if($currs[6] == 'P')
		            $start_time->hour = $start_time->hour + 12;
		        break;
		    }
		    $start_time->hour = $start_time->hour - 2;
			$start_time->minute = 0;
			$start_time->second = 0;

			if($enroll_time->lt($start_time))
			{
				$q = "UPDATE attendance SET exit_time='Early Exit' WHERE user_id='$uid' AND work_date='$query_date' AND presence='Present'";
			}
			else
			{
				$enroll_time = $enroll_time->toDateTimeString();
				$et = substr($enroll_time, 11, 8);
				$q = "UPDATE attendance SET exit_time='$et' WHERE user_id='$uid' AND work_date='$query_date' AND presence='Present'";
			}
			if($conn->query($q))
			{
				echo "SUCCESS";
			}
			else
			{
				echo "Failed";
			}
		}
	}
?>