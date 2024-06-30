using static System.Math;
using System;
using static System.Double;
public class Integ3{

    // defining a 3-point recursive open-quadrature adaptive integrator that accepts negative limits and splits interval into three subintervals:

    public static vector w = new vector($"{3/8} {2/8} {3/8}"); // Trapoziodal rule
    public static vector v = new vector($"{1/3} {1/3} {1/3}"); // rectangle rule
    public static vector x = new vector($"{1/6} {3/6} {5/6}"); // abscissas

    public static (double,double) integ (
        Func<double,double> f,
        double a,
        double b, 
        double acc=0.01, 
        double eps=0.01,
        double f2 = NaN){

        
        if(Double.IsInfinity(a) || Double.IsInfinity(b)){
            if(Double.IsNegativeInfinity(a)){ 
                if(Double.IsPositiveInfinity(b)){ //a is -inf and b is inf
                    return integ(t=> (f((1-t)/t) +f(-(1-t)/t))/t/t, 0, 1, acc, eps);
                }
                else { //a is -inf b is not inf
                    return integ(t=> (f(b - (1-t)/t) )/t/t, 0, 1, acc, eps);
                }

            }
            else { // a is not -inf and b is inf
                return integ(t=> (f(a + (1-t)/t) )/t/t, 0, 1, acc, eps);
            }
        }
        double h = b-a;
        double f1 = f(a + h/6);
        double f3 = f(a + 5*h/6);
        if(IsNaN(f2)){
            f2 = f(a + 3*h/6);
            }
        double Q = (3*f1 + 2*f2 + 3*f3)/8 * h;
        double q = (f1 + f2 + f3)/3 * h;
        double err = Abs(Q-q);
        double tol = acc + eps*Abs(Q);
        if(err < tol){
            return (Q,err);
        }

        (double Q1, double err1) = integ(f,a,a+h/3, acc/Sqrt(2), eps, f1);
        (double Q2, double err2) = integ(f,a+h/3,a+2*h/3, acc/Sqrt(2), eps, f2);
        (double Q3, double err3) = integ(f,a+2*h/3,b, acc/Sqrt(2), eps, f3);

        return (Q1 + Q2 + Q3,Sqrt(Pow(err1,2) + Pow(err2,2) +Pow(err3,2)));
        

        }//integ

}//Integ (class)
