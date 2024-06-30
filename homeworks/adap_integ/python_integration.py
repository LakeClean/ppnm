from scipy.integrate import quad
import numpy as np

def f(x):
    return x**(-0.5)

def g(x):
    return np.log(x)/np.sqrt(x)

result = quad(g, 0, 1, full_output=1, epsabs=1e-2, epsrel=1e-10)
print("For the function np.log(x)/np.sqrt(x) python makes ",result[2]['neval'], " evaluations")

result = quad(f, 0, 1, full_output=1, epsabs=1e-2, epsrel=1e-10)
print("For the function 1/sqrt(x) python makes ",result[2]['neval'], " evaluations")

