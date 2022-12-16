//Node MCU Code.


//Importing libraries to connect to Blynk.
#define BLYNK_PRINT Serial
#include <ESP8266WiFi.h>
#include <BlynkSimpleEsp8266.h>


//Defining the pins for motors.
#define motorHotWater D0
#define motorColdWater D1
#define motorWaterOut D2
#define motorAir D3


//Blynk authentication token.
#define BLYNK_AUTH_TOKEN "byCuxbgAUlcWYXyZBW6r0q1R4Xv_PB2h"

//Connecting to Wi-Fi.
char auth[] = BLYNK_AUTH_TOKEN;
char ssid[] = "ssid";  //WI-FI name
char pass[] = "pass";    //WI-FI password


//Serial Communication with Arduino.
bool startCount = false;
int stringLength = 74;
int count = 0;
String wholeString;


//Sensor data.
String tempAquarium;
String tempHotWater;
String levelAquarium;
String levelFood;



void setup() {
  //Initializing Serial Monitor for Serial communication.
  Serial.begin(9600);

  //Defining pin modes.
  pinMode(motorColdWater, OUTPUT);
  pinMode(motorHotWater, OUTPUT);
  pinMode(motorWaterOut, OUTPUT);
  pinMode(motorAir, OUTPUT);

  //Initializing the Blynk library
  Blynk.begin(auth, ssid, pass, "blynk.cloud", 80);
}





void loop() {

  //Running the Blynk library
  Blynk.run();

  Blynk.virtualWrite(V0, levelAquarium);
  Blynk.virtualWrite(V1, levelFood);
  Blynk.virtualWrite(V2, tempAquarium);
  Blynk.virtualWrite(V3, tempHotWater);

}




void serialCommunication() {
  while (Serial.available()) {
    char c = Serial.read();

    if (c == '$') {
      startCount = true;
    }

    if (startCount == true )
    {

      if (count < stringLength)
      {
        wholeString = String(wholeString + c);
        count++;
      }
      if (count >= stringLength) {
        count = 0;
        startCount = false;

        tempAquarium = wholeString.substring(2, 5);
        tempHotWater = wholeString.substring(7, 9);
        levelAquarium = wholeString.substring(12, 15);
        levelFood = wholeString.substring(17, 19);

        wholeString = "";
      }
    }
  }
}





//Commuunication with the virtual pin to remotely turn ON or OFF the motors.
BLYNK_WRITE(V4) {
  //Take the value of the virtual pin.
  bool value = param.asInt();

  // Check these values and turn the led ON or OFF.
  if (value == HIGH) {
    digitalWrite(motorHotWater, HIGH);
  } else {
    digitalWrite(motorHotWater, LOW);
  }
}


BLYNK_WRITE(V5) {
  bool value = param.asInt();
  if (value == HIGH) {
    digitalWrite(motorColdWater, HIGH);
  } else {
    digitalWrite(motorColdWater, LOW);
  }
}


BLYNK_WRITE(V6) {
  bool value = param.asInt();
  if (value == HIGH) {
    digitalWrite(motorWaterOut, HIGH);
  } else {
    digitalWrite(motorWaterOut, LOW);
  }
}



BLYNK_WRITE(V7) {
  bool value = param.asInt();
  if (value == HIGH) {
    digitalWrite(motorAir, HIGH);
  } else {
    digitalWrite(motorAir, LOW);
  }
}
