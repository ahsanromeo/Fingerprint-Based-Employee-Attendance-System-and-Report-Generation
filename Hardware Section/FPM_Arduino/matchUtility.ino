int getMatch()
{  
  bool has = false, got = false;
  int p = search(has, got);
  if(has)
  {
    if(got)
    {
      return p;
    }
    else
    {
      if(p == FINGERPRINT_NOTFOUND)
      {
        //D(2, F("No match found!"));
      }
      else if(p == FINGERPRINT_PACKETRECIEVEERR)
      {
        //D(2, F("Device Error !!!"));
      }
      else if(p == FINGERPRINT_IMAGEFAIL || p == FINGERPRINT_IMAGEMESS || p == FINGERPRINT_FEATUREFAIL || p == FINGERPRINT_INVALIDIMAGE)
      {
        //D(2, F("Imaging Error !!!"));
      }
      else
      {
        //D(2, F("Unknown Error !!!"));
      }
      return -1;
    }
  }
  else
  {
    return -2;
  }
}
int search(bool& has, bool& got)
{
  has = got = false;
  int p = -1;
  while (p != FINGERPRINT_OK){
    p = finger.getImage();
    switch (p) {
      case FINGERPRINT_OK:
        //Serial.println(F("Image taken"));
        has = true;
        break;
      case FINGERPRINT_NOFINGER:
        //Serial.println(".");
        return FINGERPRINT_NOFINGER;
        break;
      case FINGERPRINT_PACKETRECIEVEERR:
        //Serial.println(F("Communication error"));
        return FINGERPRINT_PACKETRECIEVEERR;
        break;
      case FINGERPRINT_IMAGEFAIL:
        //Serial.println(F("Imaging error"));
        return FINGERPRINT_IMAGEFAIL;
        break;
      default:
        //Serial.println(F("Unknown error"));
        return -1;
        break;
    }
  }
  has = true;
  // OK success!

  p = finger.image2Tz();
  switch (p) {
    case FINGERPRINT_OK:
      //Serial.println(F("Image converted"));
      break;
    case FINGERPRINT_IMAGEMESS:
      //Serial.println(F("Image too messy"));
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      //Serial.println(F("Communication error"));
      return p;
    case FINGERPRINT_FEATUREFAIL:
      //Serial.println(F("Could not find fingerprint features"));
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      //Serial.println(F("Could not find fingerprint features"));
      return p;
    default:
      //Serial.println(F("Unknown error"));
      return -1;
  }

  send(F("Remove finger..."));
  while (p != FINGERPRINT_NOFINGER){
    p = finger.getImage();
  }
  //Serial.println();
  // OK converted!
  p = finger.fingerFastSearch();
  if (p == FINGERPRINT_OK) {
    //Serial.println(F("Found a print match!"));
  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    //Serial.println(F("Communication error"));
    return p;
  } else if (p == FINGERPRINT_NOTFOUND) {
    //Serial.println(F("Did not find a match"));
    return p;
  } else {
    //Serial.println(F("Unknown error"));
    return -1;
  }
  got = true;
  return finger.fingerID;
}
