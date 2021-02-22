void setup() {
  Serial.begin(9600);
}
void loop() {
  Serial.println("77E 05 62 22 0D 55 65 AA AA");//all doors close
  //delay(10);
  Serial.println("77E 05 62 22 1B 81 AA AA AA");//turnSignal
  //delay(20);
  Serial.println("77E 05 62 22 98 00 14 AA AA");//currFuelConsumption
  //delay(30);
  Serial.println("77E 05 62 22 05 21 AA AA AA");//handbrake is on
  //delay(50);
  Serial.println("77E 04 62 20 2F 67 AA AA AA");//oilTemp
  //delay(500);
  Serial.println("77E 05 62 22 0D 00 65 AA AA");//all doors open
  delay(10);
  Serial.println("77E 04 62 F4 05 65 AA AA AA");//coolantTemp
  delay(40);
  Serial.println("77E 05 62 22 0D 54 65 AA AA");//driver door open
  delay(100);
  Serial.println("77E 05 62 22 0D 51 65 AA AA");//passenger door open
  delay(100);
  Serial.println("77E 05 62 22 0D 50 65 AA AA");//driver and passenger door open
  delay(1200);
  Serial.println("77E 05 62 22 0D 45 65 AA AA");//back left door open
  delay(90);
  Serial.println("77E 05 62 22 1B 84 AA AA AA");//turnSignal
  delay(100);
  Serial.println("7B0 05 62 26 13 00 1D AA AA"); //inTemp
  delay(600);
  Serial.println("77E 05 62 F4 0C 0B E8 AA AA");//EngineRpm
  delay(800);
  Serial.println("77E 04 62 22 06 2C AA AA AA");//fuelLevel
  delay(600);
  Serial.println("77E 05 62 22 03 51 B0 AA AA");//totalKm
  delay(100);
  Serial.println("77E 04 62 F4 05 85 AA AA AA");//coolantTemp
  delay(900);
  Serial.println("77E 04 62 20 2F 36 AA AA AA");//oilTemp
  delay(150);
  Serial.println("77E 05 62 22 98 00 91 AA AA");//currFuelConsumption
  delay(200);
  Serial.println("7B0 05 62 26 13 00 5C AA AA"); //inTemp
  delay(300);
  Serial.println("77E 05 62 22 0D 44 65 AA AA");//driver and back right door open
  delay(150);
  Serial.println("77E 05 62 22 0D 40 65 AA AA");//driver and passenger and left back door open 
  delay(200);
  Serial.println("77E 04 62 22 0C 55 AA AA AA");//outTemp
  delay(900);
  Serial.println("77E 05 62 22 1B 80 AA AA AA");//turnSignal
  delay(200);
  Serial.println("77E 04 62 22 0C 65 AA AA AA");//outTemp
  delay(15);
  Serial.println("77E 04 62 22 0C 66 AA AA AA");//outTemp
  delay(140);
  Serial.println("77E 05 62 22 05 20 AA AA AA");//handbrake is off
  delay(150);
  Serial.println("77E 04 62 22 06 16 AA AA AA");//fuelLevel
  delay(25);
  Serial.println("77E 04 62 22 0C 68 AA AA AA");//outTemp
  delay(90);
  Serial.println("77E 05 62 F4 0C 1C 32 AA AA");//EngineRpm
  delay(160);
  Serial.println("77E 05 62 22 03 24 C0 AA AA");//totalKm
  delay(300);
}
