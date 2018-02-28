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
import numpy as np
import pylab
from random import randint
#******************************************************************************
#Definitions
#******************************************************************************
def midpoint(point1, point2):
    return [(point1[0] + point2[0])/2, (point1[1] + point2[1])/2]
curr_point = [0,0]
v1 = [0,0]
v2 = [1,0]
v3 = [.5,np.sqrt(3)/2]
#******************************************************************************
#Plot
#******************************************************************************
for _ in range(10000):
    val = randint(0,2)
    if val == 0:
        curr_point = midpoint(curr_point, v1)
    if val == 1:
        curr_point = midpoint(curr_point, v2)
    if val == 2:
        curr_point = midpoint(curr_point, v3)
    pylab.plot(curr_point[0],curr_point[1],'b.',markersize=2)
pylab.show()
