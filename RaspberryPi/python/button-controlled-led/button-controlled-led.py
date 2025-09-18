import RPi.GPIO as GPIO
import time

LED_PIN = 17
BTN_PIN = 18

GPIO.setmode(GPIO.BCM)
GPIO.setup(LED_PIN, GPIO.OUT)
GPIO.setup(BTN_PIN, GPIO.IN, pull_up_down=GPIO.PUD_UP)

try:
    print("Press the button to toggle LED (CTRL+C to exit).")
    led_state = False
    while True:
        if GPIO.input(BTN_PIN) == GPIO.LOW:
            print("Button state changed")
            led_state = not led_state
            GPIO.output(LED_PIN, led_state)
            time.sleep(0.25)
        time.sleep(0.1)
except KeyboardInterrupt:
    print('Closing....')
finally:
    print("cleaning up")
    GPIO.output(LED_PIN, False)
    GPIO.cleanup()
