
#define TEMPLATES_PER_PAGE  256

int getFingerprintEnroll(int id);

SoftwareSerial mySerial(2, 3);


bool initFingerPrint()
{
  //Serial.println(F("fingertest"));
  mySerial.begin(57600);
 
  if (finger.begin(&mySerial)) {
    //Serial.println(F("Found fingerprint sensor!"));
    //Serial.print(F("Capacity: ")); Serial.println(finger.capacity);
    //Serial.print(F("Packet length: ")); Serial.println(finger.packetLen);
    int p = finger.getTemplateCount();
    if (p == FINGERPRINT_OK){
      //Serial.print(finger.templateCount); Serial.println(F(" print(s) in module memory."));
    }
    else if (p == FINGERPRINT_PACKETRECIEVEERR)
    {
      //Serial.println(F("Communication error!"));
      return false;
    }
    else
    {
      //Serial.println(F("Unknown error!"));
      return false;
    }
    return true;
  } else {
    return false;
  }
}


bool emptyDataBase()
{
  int p = -1;
  while (p != FINGERPRINT_OK){
    p = finger.emptyDatabase();
    if (p == FINGERPRINT_OK){
      //send(F("Database empty!"));
      return true;
    }
    else if (p == FINGERPRINT_PACKETRECIEVEERR) {
      send(F("Communication error!"));
      return false;
    }
    else if (p == FINGERPRINT_DBCLEARFAIL) {
      send(F("Could not clear database!"));
      return false;
    }
  }
  return false;
}


int deleteFingerprint(int id) {
  int p = -1;
  
  p = finger.deleteModel(id);

  if (p == FINGERPRINT_OK) {
    send(F("Deleted!"));
  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    send(F("ERROR Communication"));
    //Serial.println("Communication error");
    return p;
  } else if (p == FINGERPRINT_BADLOCATION) {
    send(F("ERROR Could not delete in that location"));
    return p;
  } else if (p == FINGERPRINT_FLASHERR) {
    send(F("ERROR writing to flash"));
    return p;
  } else {
    send("ERROR Unknown error: 0x" + (String)(p, HEX));
    //Serial.print("Unknown error: 0x"); Serial.println(p, HEX);
    return p;
  }   
}
