import RPi.GPIO as GPIO
import time

GPIO.setmode(GPIO.BCM)
RED = 17

def TurnOn():
    GPIO.output(RED, GPIO.HIGH)
    time.sleep(2)

def TurnOff():
    GPIO.output(RED, GPIO.LOW)
    time.sleep(2)

GPIO.setup(RED, GPIO.OUT)


try:
    while True:
        print("Turning on LED")
        TurnOn()
        print("Turning off LED")
        TurnOff()
except KeyboardInterrupt:
    print("Bye")
finally:
    GPIO.cleanup()


