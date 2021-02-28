#include "Emulator_parameters.h"

// definitions of CAN messages and raw representations of parameters

struct can_frame door_msg = {
  .can_id  = 0x77E,
  .can_dlc = 8,
  .data = {0x05, 0x62, 0x22, 0x0D, 0x55, 0x65, 0xAA, 0xAA}
};
bool door_state[] = {0, 0, 0, 0}; // closed - 1, opened - 0

struct can_frame handbrake_msg = {
  .can_id  = 0x77E,
  .can_dlc = 8,
  .data = {0x05, 0x62, 0x22, 0x05, 0x20, 0xAA, 0xAA, 0xAA}
};
bool handbrake_raw = 0;

struct can_frame outdoor_temperature_msg = {
  .can_id  = 0x77E,
  .can_dlc = 8,
  .data = {0x04, 0x62, 0x22, 0x0C, 0x55, 0xAA, 0xAA, 0xAA}
};
uint8_t outdoor_temperature_raw = 0;

struct can_frame fuel_level_msg = {
  .can_id  = 0x77E,
  .can_dlc = 8,
  .data = {0x04, 0x62, 0x22, 0x06, 0x2C, 0xAA, 0xAA, 0xAA}
};
uint8_t fuel_level_raw = 0;

struct can_frame coolant_temp_msg = {
  .can_id  = 0x77E,
  .can_dlc = 8,
  .data = {0x04, 0x62, 0xF4, 0x05, 0x87, 0xAA, 0xAA, 0xAA}
};
uint8_t coolant_temp_raw = 0;

struct can_frame rpm_msg = {
  .can_id  = 0x77E,
  .can_dlc = 8,
  .data = {0x05, 0x62, 0xF4, 0x0C, 0x0B, 0xC6, 0xAA, 0xAA}
};
uint16_t rpm_raw = 0;

struct can_frame oil_temp_msg = {
  .can_id  = 0x77E,
  .can_dlc = 8,
  .data = {0x04, 0x62, 0x20, 0x2F, 0x36, 0xAA, 0xAA, 0xAA}
};
uint8_t oil_temp_raw = 0;

struct can_frame indoor_temp_msg = {
  .can_id  = 0x77E,
  .can_dlc = 8,
  .data = {0x05, 0x62, 0x26, 0x13, 0x00, 0x5D, 0xAA, 0xAA}
};
uint8_t indoor_temp_raw = 0;

struct can_frame steering_switch_msg = {
  .can_id  = 0x77E,
  .can_dlc = 8,
  .data = {0x05, 0x62, 0x22, 0x1B, 0x80, 0xAA, 0xAA, 0xAA}
};
uint8_t steering_switch_raw = 0;

struct can_frame current_consumption_msg = {
  .can_id  = 0x77E,
  .can_dlc = 8,
  .data = {0x05, 0x62, 0x22, 0x98, 0x00, 0x00, 0xAA, 0xAA}
};
float current_consumption_raw = 0;

struct can_frame odometer_msg = {
  .can_id  = 0x77E,
  .can_dlc = 8,
  .data = {0x05, 0x62, 0x22, 0x03, 0x24, 0xC0, 0xAA, 0xAA}
};
uint32_t odometer_raw = 0;

// function for setting parameters value randomly
void change_parameters_randomly() {
  // invert state of random door
  door_i = random(4);
  door_state[door_i] = !door_state[door_i];
  update_door_msg();

  // set random handbrake state
  handbrake_raw = random(2);
  update_handbrake_msg();

  // set random outdoor temperature value
  outdoor_temperature_raw = random(0, 30);
  update_outdoor_temperature_msg();

  // set random fuel level
  fuel_level_raw = random(50);
  update_fuel_level_msg();

  // set random coolant temperature value
  coolant_temp_raw = random(150);
  update_coolant_temp_msg();

  // set random rpm
  rpm_raw = random(3000);
  update_rpm_msg();

  // set random oil temperature
  oil_temp_raw = random(50);
  update_oil_temp_msg();

  // set random indoor temperature value
  indoor_temp_raw = random(25);
  update_indoor_temp_msg();

  // set random steering switch value
  steering_switch_raw = random(3);
  update_steering_switch_msg();

  // set random current consumption value
  current_consumption_raw = random(200) / 10.0;
  update_current_consumption_msg();

  // set random odometer value
  odometer_raw = random(200000);
  update_odometer_msg();
}


// functions for updating CAN messages according to raw value

void update_door_msg() {
  door_msg.data[4] = 0;
  for (uint8_t i = 0; i < 4; i++) {
    door_msg.data[4] = door_msg.data[4] | door_state[i] << (i * 2);
  }
}

void update_handbrake_msg() {
  if (handbrake_raw) {
    handbrake_msg.data[4] = 0x21;
  } else {
    handbrake_msg.data[4] = 0x20;
  }
}

void update_outdoor_temperature_msg() {
  outdoor_temperature_msg.data[4] = outdoor_temperature_raw * 2 + 100;
}

void update_fuel_level_msg() {
  fuel_level_msg.data[4] = fuel_level_raw;
}

void update_coolant_temp_msg() {
  coolant_temp_msg.data[4] = coolant_temp_raw + 40;
}

void update_rpm_msg() {
  uint16_t conv_rpm = rpm_raw * 4;
  rpm_msg.data[4] = conv_rpm >> 8;
  rpm_msg.data[5] = conv_rpm & 255;
}

void update_oil_temp_msg() {
  oil_temp_msg.data[4] = oil_temp_raw + 58;
}

void update_indoor_temp_msg() {
  indoor_temp_msg.data[4] = indoor_temp_raw + 40;
}

void update_steering_switch_msg() {
  if (steering_switch_raw == 0) {
    steering_switch_msg.data[4] = 0x80;
  } else if (steering_switch_raw == 1) {
    steering_switch_msg.data[4] = 0x81;
  } else if (steering_switch_raw == 2) {
    steering_switch_msg.data[4] = 0x84;
  }
}

void update_current_consumption_msg() {
  current_consumption_msg.data[4] = current_consumption_raw * 10;
}

void update_odometer_msg() {
  uint16_t conv_odometer = odometer_raw / 10;
  odometer_msg.data[4] = conv_odometer >> 8;
  odometer_msg.data[5] = conv_odometer & 255;
}
