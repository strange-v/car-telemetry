void setup() {
  Serial.begin(9600);
}
void loop() {
  Serial.println("77E 05 62 22 0D 55 65 AA AA");//all doors close
  delay(1000);
  Serial.println("77E 05 62 22 05 21 AA AA AA");//handbrake is on
  delay(1500);
  Serial.println("77E 05 62 22 0D 00 65 AA AA");//all doors open
  delay(800);
  Serial.println("77E 04 62 F4 05 65 AA AA AA");//coolantTemp
  delay(400);
  Serial.println("77E 05 62 22 0D 54 65 AA AA");//driver door open
  delay(1000);
  Serial.println("77E 05 62 22 0D 51 65 AA AA");//passenger door open
  delay(1000);
  Serial.println("77E 05 62 22 0D 50 65 AA AA");//driver and passenger door open
  delay(1200);
  Serial.println("77E 05 62 22 0D 45 65 AA AA");//back left door open
  delay(900);
  Serial.println("7B0 05 62 26 13 00 1D AA AA"); //inTemp
  delay(600);
  Serial.println("77E 05 62 F4 0C 0B E8 AA AA");//EngineRpm
  delay(800);
  Serial.println("77E 04 62 22 06 2C AA AA AA");//fuelLevel
  delay(600);
  Serial.println("77E 04 62 F4 05 85 AA AA AA");//coolantTemp
  delay(900);
  Serial.println("77E 05 62 22 0D 44 65 AA AA");//driver and back right door open
  delay(1500);
  Serial.println("7B0 05 62 26 13 00 5C AA AA"); //inTemp
  delay(300);
  Serial.println("77E 05 62 22 0D 40 65 AA AA");//driver and passenger and left back door open 
  delay(2000);
  Serial.println("77E 04 62 22 0C 55 AA AA AA");//outTemp
  delay(900);
  Serial.println("77E 04 62 22 0C 65 AA AA AA");//outTemp
  delay(1500);
  Serial.println("77E 04 62 22 0C 66 AA AA AA");//outTemp
  delay(1400);
  Serial.println("77E 05 62 22 05 20 AA AA AA");//handbrake is off
  delay(1500);
  Serial.println("77E 04 62 22 06 16 AA AA AA");//fuelLevel
  delay(2500);
  Serial.println("77E 04 62 22 0C 68 AA AA AA");//outTemp
  delay(900);
  Serial.println("77E 05 62 F4 0C 1C 32 AA AA");//EngineRpm
  delay(1600);
}
