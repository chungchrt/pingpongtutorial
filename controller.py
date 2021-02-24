import os
import auto
import auto2
from multiprocessing import Process

def script_device_1():
    os.system("auto.py")


def script_deive_2():
    os.system("auto2.py")

if __name__ == '__main__':
    p1 = Process(target=script_device_1)
    p2 = Process(target=script_deive_2)
    p1.start()
    p2.start()
    p1.join()
    p2.join()