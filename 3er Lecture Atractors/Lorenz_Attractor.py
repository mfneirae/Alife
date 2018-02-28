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
#                      Lorenz Attractor
#******************************************************************************
import matplotlib.pyplot as plt
import numpy as np
from scipy.integrate import odeint
from mpl_toolkits.mplot3d import Axes3D
#******************************************************************************
#Designer Parameters
#******************************************************************************
rho = 28.0
sigma = 10.0
beta = 8.0 / 3.0
#******************************************************************************
#Definitions
#******************************************************************************
def f(state, t):
  x, y, z = state  # unpack the state vector
  return sigma * (y - x), x * (rho - z) - y, x * y - beta * z  # derivatives
#******************************************************************************
#Main
#******************************************************************************
state0 = [1.0, 1.0, 1.0]
t = np.arange(0.0, 40.0, 0.01)
states = odeint(f, state0, t)
#******************************************************************************
#Plot
#******************************************************************************
fig = plt.figure()
ax = fig.gca(projection='3d')
ax.plot(states[:,0], states[:,1], states[:,2], color = "red")
plt.show()
