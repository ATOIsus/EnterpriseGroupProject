//Node MCU Code.


//Importing libraries to connect to Blynk.
#define BLYNK_PRINT Serial
#include <ESP8266WiFi.h>
#include <BlynkSimpleEsp8266.h>


//Blynk authentication token.
#define BLYNK_AUTH_TOKEN "byCuxbgAUlcWYXyZBW6r0q1R4Xv_PB2h"

//Connecting to Wi-Fi.
char auth[] = BLYNK_AUTH_TOKEN;
char ssid[] = "ssid";  //WI-FI name
char pass[] = "pass";    //WI-FI password




//Commuunication with the virtual pin to remotely turn ON or OFF door lamp.
BLYNK_WRITE(V2) {

  //Take the value of the virtual pin.
  bool value = param.asInt();

  // Check these values and turn the led ON or OFF.
  if (value == HIGH) {
    digitalWrite(led, HIGH);
  } else {
    digitalWrite(led, LOW);
  }

}




//Defining the pins for motors.
#define motorHotWater D0
#define motorColdWater D1
#define motorWaterOut D2
#define motorAir D3


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
   Serial.begin(9600);
}





void loop() {
 

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
