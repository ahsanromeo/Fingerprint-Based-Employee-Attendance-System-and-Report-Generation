void initTimeAndDate()
{
    Rtc.Begin();
    //RtcDateTime myTime = RtcDateTime(18,03,03,18,28,0); //define date and time object 
    //Rtc.SetDateTime(myTime);
    return;
    //Serial.print(__DATE__);
    //Serial.println(__TIME__);
    
    RtcDateTime compiled = RtcDateTime(__DATE__, __TIME__);
    //Rtc.SetDateTime(compiled);
    //Serial.println();
    if (!Rtc.IsDateTimeValid()) 
    {
        Rtc.SetDateTime(compiled);
    }

    if (!Rtc.GetIsRunning())
    {
        //Serial.println(F("RTC was not actively running, starting now"));
        Rtc.SetIsRunning(true);
    }

    RtcDateTime now = Rtc.GetDateTime();
    if (now < compiled) 
    {
        //Serial.println(F("RTC is older than compile time!  (Updating DateTime)"));
        Rtc.SetDateTime(compiled);
    }
    else if (now > compiled) 
    {
        //Serial.println(F("RTC is newer than compile time. (this is expected)"));
    }
    else if (now == compiled) 
    {
        //Serial.println(F("RTC is the same as compile time! (not expected but all is fine)"));
    }

    // never assume the Rtc was last configured by you, so
    // just clear them to your needed state
    Rtc.Enable32kHzPin(false);
    Rtc.SetSquareWavePin(DS3231SquareWavePin_ModeNone); 
}

String setTime(const int year, const int month, const int day, const int hour, const int minute, const int second)
{
  RtcDateTime curr = RtcDateTime(year - 2000, month, day, hour, minute, second);
  Rtc.SetDateTime(curr);
  delay(10);
  RtcDateTime t = Rtc.GetDateTime();
  String ret = (String)t.Year() + "_" + (String)t.Month() + "_" + (String)t.Day() + "_" + (String)t.Hour() + "_" + (String)t.Minute() + "_" + (String)t.Second();
  return ret;
}

void printDateAndTime(const uint8_t row)
{
  char buf[20];
  RtcDateTime t = Rtc.GetDateTime();
  snprintf(buf, 20, "%02u/%02u/%02u %02u:%02u:%02u", t.Day(), t.Month(), t.Year(), t.Hour(), t.Minute(), t.Second());
  D(row, buf);
}

