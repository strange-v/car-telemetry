#include <mcp2515.h>

extern struct can_frame door_msg;
extern bool door_state[4]; // closed - 1, opened - 0
extern uint8_t door_i;

extern struct can_frame handbrake_msg;
extern bool handbrake_raw;

extern struct can_frame outdoor_temperature_msg;
extern uint8_t outdoor_temperature_raw;

extern struct can_frame fuel_level_msg;
extern uint8_t fuel_level_raw;

extern struct can_frame coolant_temp_msg;
extern uint8_t coolant_temp_raw;

extern struct can_frame rpm_msg;
extern uint16_t rpm_raw;

extern struct can_frame oil_temp_msg;
extern uint8_t oil_temp_raw;

extern struct can_frame indoor_temp_msg;
extern uint8_t indoor_temp_raw;

extern struct can_frame steering_switch_msg;
extern uint8_t steering_switch_raw;

extern struct can_frame current_consumption_msg;
extern float current_consumption_raw;

extern struct can_frame odometer_msg;
extern uint32_t odometer_raw;

void change_parameters_randomly();
void update_door_msg();
void update_handbrake_msg();
void update_outdoor_temperature_msg();
void update_fuel_level_msg();
void update_coolant_temp_msg();
void update_rpm_msg();
void update_oil_temp_msg();
void update_indoor_temp_msg();
void update_steering_switch_msg();
void update_current_consumption_msg();
void update_odometer_msg();