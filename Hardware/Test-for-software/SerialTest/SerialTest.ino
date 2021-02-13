void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.println("77E 05 62 22 0D 55 65 AA AA");//all doors close
  delay(1000);
  Serial.println("77E 05 62 22 0D 00 65 AA AA");//all doors open
  delay(1000);
  Serial.println("77E 05 62 22 0D 54 65 AA AA");//driver door open
  delay(1000);
  Serial.println("77E 05 62 22 0D 51 65 AA AA");//passenger door open
  delay(1000);
  Serial.println("77E 05 62 22 0D 50 65 AA AA");//driver and passenger door open
  delay(1000);
  Serial.println("77E 05 62 22 0D 45 65 AA AA");//back left door open
  delay(1000);
  Serial.println("77E 05 62 22 0D 40 65 AA AA");//driver and passenger and left back door open 
  delay(1000);
  Serial.println("77E 05 62 22 0D 44 65 AA AA");//driver and back right door open
  delay(1000);
  Serial.println("7B0 05 62 26 13 00 5C AA AA");
  delay(1000);
  Serial.println("7B0 05 62 26 13 00 1D AA AA");
  delay(1000);
  Serial.println("77E 04 62 22 0C 55 AA AA AA");
  delay(1000);
  Serial.println("77E 04 62 22 0C 65 AA AA AA");
  delay(1000);
  Serial.println("77E 04 62 22 0C 66 AA AA AA");
  delay(1000);
  Serial.println("77E 04 62 22 0C 68 AA AA AA");
  delay(1000);
}
