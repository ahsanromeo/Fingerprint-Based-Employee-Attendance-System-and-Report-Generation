#define waitingTime 10000
#define standardDelay 500

void enrollUser()
{
  D(0, F("Enroll Mode"));
  int16_t id;
  if (get_free_id(&id))
  {
    send("free " + (String)id);
    delay(10);
    int ret = getFingerprintEnroll(id);
    if(ret == FINGERPRINT_WAITINGERROR)
    {
      send(F("ERROR Time Out"));
      D(1, F("ERROR Time Out"));
    }
    else if(ret == 0)
    {
      send("Success " + (String)id);
      D(1, "Success " + (String)id);
    }
    else if(ret == FINGERPRINT_ENROLLMISMATCH)
    {
      send(F("Failed Did Not Match"));
      D(1, F("Failed Did Not Match"));
    }
    else if(ret == FINGERPRINT_PACKETRECIEVEERR || ret == FINGERPRINT_BADLOCATION || ret == FINGERPRINT_FLASHERR)
    {
      send(F("ERROR Device"));
      D(1, F("Device Error"));
    }
    else if(ret == FINGERPRINT_IMAGEFAIL || ret == FINGERPRINT_IMAGEMESS || ret == FINGERPRINT_FEATUREFAIL || ret == FINGERPRINT_INVALIDIMAGE)
    {
      send(F("ERROR Imaging"));
      D(1, F("Imaging Error"));
    }
    else
    {
      send(F("ERROR Unknown"));
      D(1, F("Unknown Error"));
    }
  }
  else
  {
    send(F("ERROR No Free Slot or other error"));
    D(1, F("ERROR! Sorry !"));
    D(2, F("No Free Slot"));
    D(3, F("....or other error"));
  }
}

int getFingerprintEnroll(int id) {
  int p = -1;
  unsigned long initTime = millis();
  send(F("Place finger on device"));
  D(1, F("Put finger on device"));
  while (p != FINGERPRINT_OK) {
    unsigned long len = millis() - initTime;
    if(len > waitingTime)
    {
      D(1, F("Time limit up"));
      return FINGERPRINT_WAITINGERROR;
    }
    p = finger.getImage();
    switch (p) {
    case FINGERPRINT_OK:
      send(F("Image taken"));
      D(1, F("Image taken"));
      clearRow(2);
      clearRow(3);
      delay(standardDelay);
      break;
    case FINGERPRINT_NOFINGER:
      send("Waiting " + (String)(len / 1000 + 1) + " Seconds");
      D(2, F("Waiting "));
      D(3, (String)(len / 1000 + 1) + " Seconds");
      break;
    case FINGERPRINT_PACKETRECIEVEERR:
      //Serial.println("Communication error");
      break;
    case FINGERPRINT_IMAGEFAIL:
      //Serial.println("Imaging error");
      break;
    default:
      //Serial.println("Unknown error");
      break;
    }
  }
  // OK success!

  p = finger.image2Tz(1);
  switch (p) {
    case FINGERPRINT_OK:
      //Serial.println("Image converted");
      send(F("Image converted"));
      D(1, F("Image converted"));
      delay(standardDelay);
      break;
    case FINGERPRINT_IMAGEMESS:
      //Serial.println("Image too messy");
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      //Serial.println("Communication error");
      return p;
    case FINGERPRINT_FEATUREFAIL:
      //Serial.println("Could not find fingerprint features");
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      //Serial.println("Could not find fingerprint features");
      return p;
    default:
      //Serial.println("Unknown error");
      return p;
  }
  
  //Serial.println("Remove finger");
  send(F("Remove finger..."));
  D(1, F("Remove finger..."));
  p = 0;
  //uint8_t cnt = 0;
  while (p != FINGERPRINT_NOFINGER) {
    p = finger.getImage();
  }
  p = -1;
  //Serial.println("Place same finger again");
  send(F("Place finger again"));
  D(1, F("Place finger again"));
  initTime = millis();
  while (p != FINGERPRINT_OK) {
    unsigned long len = millis() - initTime;
    if(len > waitingTime)
    {
      return FINGERPRINT_WAITINGERROR;
    }
    p = finger.getImage();
    switch (p) {
    case FINGERPRINT_OK:
      send(F("Image taken"));
      D(1, F("Image taken"));
      delay(standardDelay);
      break;
    case FINGERPRINT_NOFINGER:
      send("Waiting " + (String)(len / 1000 + 1) + " Seconds");
      D(2, F("Waiting "));
      D(3, (String)(len / 1000 + 1) + " Seconds");
      break;
    case FINGERPRINT_PACKETRECIEVEERR:
      //Serial.println("Communication error");
      break;
    case FINGERPRINT_IMAGEFAIL:
      //Serial.println("Imaging error");
      break;
    default:
      //Serial.println("Unknown error");
      break;
    }
  }

  // OK success!

  p = finger.image2Tz(2);
  switch (p) {
    case FINGERPRINT_OK:
      send(F("Image converted"));
      clearRow(2);
      clearRow(3);
      D(1, F("Image converted"));
      delay(standardDelay);
      break;
    case FINGERPRINT_IMAGEMESS:
      //Serial.println("Image too messy");
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      //Serial.println("Communication error");
      return p;
    case FINGERPRINT_FEATUREFAIL:
      //Serial.println("Could not find fingerprint features");
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      //Serial.println("Could not find fingerprint features");
      return p;
    default:
      //Serial.println("Unknown error");
      return p;
  }
  
  
  // OK converted!
  p = finger.createModel();
  if (p == FINGERPRINT_OK) {
    send(F("Prints matched!"));
    D(1, F("Prints matched!"));
    delay(standardDelay);
  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    //Serial.println("Communication error");
    return p;
  } else if (p == FINGERPRINT_ENROLLMISMATCH) {
    //Serial.println("Fingerprints did not match");
    return p;
  } else {
    //Serial.println("Unknown error");
    return p;
  }   
  
  //Serial.print("ID "); Serial.println(id);
  p = finger.storeModel(id);
  if (p == FINGERPRINT_OK) {
    //Serial.println("Stored!");
    send(F("Stored !!!"));
    D(1, F("Successful !"));
    delay(standardDelay);
    return 0;
  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    //Serial.println("Communication error");
    return p;
  } else if (p == FINGERPRINT_BADLOCATION) {
    //Serial.println("Could not store in that location");
    return p;
  } else if (p == FINGERPRINT_FLASHERR) {
    //Serial.println("Error writing to flash");
    return p;
  } else {
    //Serial.println("Unknown error");
    return p;
  }   
}

bool get_free_id(int16_t * id){
  int p = -1;
  for (int page = 0; page < (finger.capacity / TEMPLATES_PER_PAGE) + 1; page++){
    p = finger.getFreeIndex(page, id);
    switch (p){
      case FINGERPRINT_OK:
        if (*id != FINGERPRINT_NOFREEINDEX){
          return true;
        }
      case FINGERPRINT_PACKETRECIEVEERR:
        //send(F("ERROR"));
        //send(F("Communication"));
        return false;
      default:
        //send(F("ERROR"));
        //send(F("Unknown"));
        return false;
    }
  }
}

