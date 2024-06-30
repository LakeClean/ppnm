
- This project consist of constructing a 3-point addaptive numerical integrator that subdivides the interval into 
    3 subdivisions at each itteration. It allows for infinite limits and is open so also allows for divergences 
    at the limits.

- The abscissas used in the three point quadrature are xi = {1/6, 3/6, 5/6}. These are useful since they allow for the
    reuse of points, reducing the number of evaluations of the function being integrated. 
    The weights are determined to be wi = {3/8,2/8,3/8}, as outlined in the accompanying pdf: "3point_open_quadrature.pdf".
    This is determined from the constraints that the weights sum to one and that the integral exactly
    fits with a second order polynomial.

- The integrator is tested on a range of definite integrals.

- This 'exam integrator' is then compared with the 'homework integrator' that uses 4 points and subdivides into two.