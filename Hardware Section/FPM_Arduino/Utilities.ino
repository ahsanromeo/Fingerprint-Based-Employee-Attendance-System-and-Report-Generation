#define waitingTime 10000
#define standardDelay 500

void D(const uint8_t row, String line)
{
  lcd.setCursor(0, row);
  while(line.length() < 20)
    line += ' ';
  lcd.print(line);
}

void D(const uint8_t row, const int16_t item)
{
  lcd.setCursor(0, row);
  lcd.print(item);
}


void clearRow(const uint8_t row)
{
  D(row, "");
}

String generateString(const int& mid)
{
  RtcDateTime t = Rtc.GetDateTime();
  String to_send = thisDevice.substring(0, 3);
  if(mid < 10) to_send += "00";
  else if(mid < 100) to_send += "0";
  to_send += (String)mid + "_" + (String)t.Year() + "/";
  if(t.Month() < 10) to_send += "0";
  to_send += (String)t.Month() + "/";
  if(t.Day() < 10) to_send += "0";
  to_send += (String)t.Day() + "_";
  if(t.Hour() < 10) to_send += "0";
  to_send += (String)t.Hour() + ":";
  if(t.Minute() < 10) to_send += "0";
  to_send += (String)t.Minute() + ":";
  if(t.Second() < 10) to_send += "0";
  to_send += (String)t.Second();
  return to_send;
}

