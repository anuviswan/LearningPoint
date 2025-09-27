# Testing distance with HR S04 sensor

import RPi.GPIO as GPIO
import time

TRIG = 23
ECHO = 24

GPIO.setmode(GPIO.BCM)
GPIO.setup(TRIG, GPIO.OUT)
GPIO.setup(ECHO, GPIO.IN)

def get_distance(timeout=0.02):
    # Ensure trigger low
    GPIO.output(TRIG, False)
    time.sleep(0.05)

    # Trigger pulse
    GPIO.output(TRIG, True)
    time.sleep(0.00001)
    GPIO.output(TRIG, False)

    # Wait for echo start
    start = time.time()
    t0 = start
    while GPIO.input(ECHO) == 0:
        stop = time.time()
        if stop - t0 > timeout:
            return None


    # wait for echo end
    stop = time.time()
    t0 = stop
    while GPIO.input(ECHO) == 1:
        stop = time.time()
        if stop - t0 > timeout:
            return None

    pulse_duration = stop - start
    distance = pulse_duration * (34300/2) # speed of sound c./s
    return distance

try:
    while True:
        distance = get_distance()
        if distance == None:
            print("No echo (timeout)")
        else:
            print("Distance: " + str(distance))
        time.sleep(0.3)
except KeyboardInterrupt:
    pass
finally:
    GPIO.cleanup()


