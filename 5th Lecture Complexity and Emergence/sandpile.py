#!/usr/bin/python3

import numpy as np
from time import sleep
from termcolor import colored

threshold = 4
size = 20
RANDOM_START = True

cs = ["white", "green", "blue", "red"]

if RANDOM_START:
	m = np.random.randint(0,4,size=(size,size))
else:
	m = np.zeros((size,size), dtype="int")

def disp():
	for i in range(size):
		for j in range(size):
			print(colored(m[i][j], cs[m[i][j]]), end=" ")
		print("")
	print("")

def prop(x, y):
	if x<0 or y<0 or x>=size or y>=size:
		return
	m[x][y]+=1
	if m[x][y]>=threshold:
		m[x][y]=0
		prop(x+1, y)
		prop(x-1, y)
		prop(x, y+1)
		prop(x, y-1)
while True:
	x, y = np.random.randint(size),np.random.randint(size)
	prop(x,y)
	disp()
	sleep(.1)
