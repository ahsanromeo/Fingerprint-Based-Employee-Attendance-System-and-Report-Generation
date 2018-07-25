#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>

//const char* ssid = "DecentBoysOf201";
//const char* password = "amravalochele";

const char* ssid = "Romeo_wifi";
const char* password = "romeowifi";

String address, data, payload;

void setup ()
{
    Serial.begin(115200);
    Serial.println("\nSerial Began");
    WiFi.begin(ssid, password);
    uint8_t wi = 0;
    while (WiFi.status() != WL_CONNECTED)
    {
        delay(1000);
        Serial.print("Connecting...");
        Serial.println(++wi);
    }
    Serial.println("\nConnection Successful");
    address = "http://www.ahsanromeo.me/fpm/load.php?data=";
    //address = "http://www.ahsanromeo.me/fpm/test.php?data=";
    data = "";
    address.trim();
}

void loop()
{
  if(!Serial.available()) return;
  data = Serial.readString();
  data.trim();
  if(WiFi.status() != WL_CONNECTED)
  {
    Serial.println("NoConnection");
  }
  else
  {
    data = address + data;
    HTTPClient http;
    http.begin(data);
    int httpCode = http.GET();
    Serial.println((String)httpCode);
    if(httpCode == 200)
    {
      payload = http.getString();
      //payload.trim();
      Serial.println("pay: " + payload);
    }
    else
    {
      Serial.println("SendingFailed");
    }
    http.end();
  }
  delay(1000);
}


