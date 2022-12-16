//Node MCU Code.


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
