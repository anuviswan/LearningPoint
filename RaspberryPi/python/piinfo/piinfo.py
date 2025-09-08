import platform as p
import os as o
import gpiozero as gpio
import psutil as psutil
from gpiozero import pi_info

# Refer : https://docs.python.org/3/library/platform.html
print(f"OS Information : {p.system()}")
print(f"OS Version : {p.version}")
print(f"Architecture : {p.machine()}")
print(f"Processor : {p.processor()}")
print(f"Network : {p.node()}")
print(f"Python Version : {p.python_version()}")

# Refer : https://docs.python.org/3/library/os.html
print(f"User : {o.getlogin()}")
print(f"Current working dir : {o.getcwd()}")

# Refer : https://gpiozero.readthedocs.io/en/stable/api_info.html


print("Pi Model:", pi_info().model)
print("Pi Revision:", pi_info().revision)
print("CPU Revision:", pi_info().cpu_revision)
print("Memory:", pi_info().memory)


# Refer:https://pypi.org/project/psutil/

print("CPU cores:", psutil.cpu_count())
print("CPU usage %:", psutil.cpu_percent(interval=1))
print("Memory info:", psutil.virtual_memory())