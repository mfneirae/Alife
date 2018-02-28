#
# #############################################################################
#        Copyright (c) 2018 by Manuel Embus. All Rights Reserved.
#
#              This work is licensed under a Creative Commons
#        Attribution - NonCommercial - ShareAlike 4.0
#        International License.
#
#        For more information write me to jai@mfneirae.com
#        Or visit my webpage at https://mfneirae.com/
# #############################################################################
#

#******************************************************************************
#                      Logistic Map - Fix Point
#******************************************************************************
import matplotlib.pyplot as plt
import numpy as np
#******************************************************************************
#Designer Parameters
#******************************************************************************
resolution = 100                    #Number of Points
iteraciones = 100
r = 3                               #Reproduction Rate
x1 =[0.13]
#******************************************************************************
#Definitions
#******************************************************************************
x = []
y = []
y1 = []
y2 = []
#******************************************************************************
#Main
#******************************************************************************
time = np.arange(0, 1, 1/resolution)
x = np.ndarray.tolist(time)
y1 = x
for t in range(0,len(time)):
    f = r*time[t]*(1-time[t])
    y.append(f)
for z in range(0,iteraciones):
    f1 = r*x1[z]*(1-x1[z])
    f2 = r*x1[z]*(1-x1[z])
    y2.append(f2)
    if z < iteraciones-1:
        x1.append(f1)
#******************************************************************************
#Plot
#******************************************************************************
t = list(range(0,iteraciones))
plt.grid(True)
plt.subplot(221)
plt.plot(x,y, color="red")
plt.plot(x,y1, color="blue")
plt.plot(x1,y2, color="green", marker="^")
plt.subplot(222)
plt.plot(x1,y2, color="green", marker="^")
plt.subplot(212)
plt.plot(t,x1, color="red")
plt.show()
