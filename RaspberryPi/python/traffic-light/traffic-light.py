import RPi.GPIO as GPIO
import time


def TurnOn(led:int):
    GPIO.output(led, GPIO.HIGH)

def TurnOff(led:int):
    GPIO.output(led, GPIO.LOW)


RED = 17
GREEN = 22
YELLOW = 23
GPIO.setmode(GPIO.BCM)

GPIO.setup(RED, GPIO.OUT)
GPIO.setup(GREEN, GPIO.OUT)
GPIO.setup(YELLOW, GPIO.OUT)
try:
    while True:
        TurnOn(RED)
        TurnOff(YELLOW)
        TurnOff(GREEN)

        time.sleep(0.5)

        TurnOff(RED)
        TurnOn(YELLOW)
        TurnOff(GREEN)

        time.sleep(0.5)

        TurnOff(RED)
        TurnOff(YELLOW)
        TurnOn(GREEN)

        time.sleep(0.5)

        TurnOff(RED)
        TurnOn(YELLOW)
        TurnOff(GREEN)

        time.sleep(0.5)

except KeyboardInterrupt:
    print("Shutting down")
finally:
    GPIO.cleanup()


