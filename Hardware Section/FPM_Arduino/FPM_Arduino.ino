#include <SoftwareSerial.h>
#include <LiquidCrystal.h>
#include <FPM.h>
#include <Wire.h>
#include <RtcDS3231.h>
//#include <StandardCplusplus.h>
//#include <queue>
//using namespace std;
RtcDS3231<TwoWire> Rtc(Wire);
SoftwareSerial wifi(10, 11);
const String thisDevice = "Administrative Building";

const uint8_t rs = 9, en = 8, d4 = 4, d5 = 5, d6 = 6, d7 = 7;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);
String cmd = "";
bool hasCmd = false;
String payload = "";
bool haspay = false;

uint8_t mode;

FPM finger;

//queue < char* > Q;

bool isConnectedWithPC = false;

void setup()
{
  pinMode(13, OUTPUT);
  isConnectedWithPC = false;
  wifi.begin(115200);
  Serial.begin(9600);
  lcd.begin(20, 4);
  lcd.clear();
  D(0, "Hello");
  if(initFingerPrint())
  {
    Serial.println("FPM Loaded");
    D(1, "FPM Loaded");
  }
  else
  {
    Serial.println("FPM Failed");
    D(1, "FPM Failed");
    while(1);
  }
  initTimeAndDate();
  delay(1500);
}


void loop()
{
  lcd.clear();
  if(hasCmd)
  {
    if(cmd == "START\n")
    {
      send(thisDevice);
      D(0, " ** PC Connected ** ");
      delay(500);
      isConnectedWithPC = true;
    }
    else if(cmd == "STOP\n")
    {
      D(0, "Disconnected");
      delay(500);
      isConnectedWithPC = false;
    }
    else if(cmd == "AreYouThere?\n")
    {
      send(thisDevice);
    }
    else if(cmd == "info\n")
    {
      send(thisDevice + "_" + (String)finger.capacity + "_" + (String)finger.templateCount);
    }
    else if(cmd == "ENROLL\n")
    {
      enrollUser();
    }
    else if(cmd == "EMPTY\n")
    {
      if(emptyDataBase())
        send(F("Success"));
    }
    else if(cmd == "CHECK_TIME\n")
    {
      RtcDateTime t = Rtc.GetDateTime();
      String ret = (String)t.Day() + "/" + (String)t.Month() + "/" + (String)t.Year() + " " + (String)t.Hour() + ":" + (String)t.Minute() + ":" + (String)t.Second();
      send(ret);
    }
    else if(cmd[0] == 'D' && cmd[1] == 'E' && cmd[2] == 'L')
    {
      int id = 0;
      for(int i = 7; cmd[i] != '\n'; ++i)
      {
        id = id * 10 + (cmd[i] - 48);
      }
      deleteFingerprint(id);
    }
    else if(cmd[0] == 'S' && cmd[1] == 'E' && cmd[2] == 'T' && cmd[3] == cmd[2]) // SETTIME
    {
      String res = setTime((cmd[12] - 48) * 1000 + (cmd[13] - 48) * 100 + (cmd[14] - 48) * 10 + (cmd[15] - 48), (cmd[10] - 48) * 10 + (cmd[11] - 48), (cmd[8] - 48) * 10 + (cmd[9] - 48), (cmd[16] - 48) * 10 + (cmd[17] - 48), (cmd[18] - 48) * 10 + (cmd[19] - 48), (cmd[20] - 48) * 10 + (cmd[21] - 48));
      delay(10);
      send(res);
    }
    cmd = "";
    hasCmd = false;
    return;
  }
  if(isConnectedWithPC) return;
  D(0, "Put finger on device");
  D(1, ".....");
  int mid = getMatch();
  if(mid >= 0)
  {
    D(0, "Fingerprint Found");
    D(1, "With ID: " + (String)mid);
    String ss = generateString(mid);
    send(ss);
    wifi.println(ss);
    D(2, "Success !");
    D(3, "Confirmed");
    delay(2000);
    tone(13, 100);
    delay(200);
    noTone(13);
  }
  else if(mid == -2)
  {

  }
  else if(mid == -1)
  {
    send("NOT Found");
    D(0, "Sorry");
    D(1, "No match Found");
    delay(1500);
  }
  delay(50);
}

void serialEvent()
{
  while (Serial.available())
  {
    char inChar = (char)Serial.read();
    cmd += inChar;
    if (inChar == '\n')
    {
      hasCmd = true;
    }
  }
}

void send(const String s)
{
  while(Serial.available()) Serial.read();
  Serial.print(s + "\n");
}

void sendToWifi(const String s)
{
  while(wifi.available()) wifi.read();
  wifi.print(s + "\n");
}

void getWifi()
{
  while (wifi.available())
  {
    char inChar = (char)wifi.read();
    payload += inChar;
    if (inChar == '\n')
    {
      haspay = true;
      break;
    }
  }
  while (wifi.available());
}

