using static System.Math;
using System;
using static System.Double;
public class Integ{

    // defining a 3-point recursive open-quadrature adaptive integrator that accepts negative limits:

    public static (double,double,int) integ (
        Func<double,double> f,
        double a,
        double b, 
        double acc=0.01, 
        double eps=0.01,
        double f2 = NaN,
        int eval = 0){

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

        double f1 = f(a + (b-a)/6);
        double f3 = f(a + 5*(b-a)/6);
        if(IsNaN(f2)){
            f2 = f(a + 3*(b-a)/6);
            }
        double Q = (3*f1 + 2*f2 + 3*f3)/8 * (b-a);
        double q = (f1 + f2 + f3)/3 * (b-a);
        double err = Abs(Q-q);
        double tol = acc + eps*Abs(Q);
        eval += 1;
        if(err < tol){
            return (Q,err,eval);
        }
        (double Q1, double err1, int eval1) = integ(f,a,(a+b)/3, acc/Sqrt(2), eps, f1,eval);
        (double Q2, double err2, int eval2) = integ(f,(a+b)/3,2*(a+b)/3, acc/Sqrt(2), eps, f2,eval);
        (double Q3, double err3, int eval3) = integ(f,2*(a+b)/3,b, acc/Sqrt(2), eps, f3,eval);

        return (Q1 + Q2 + Q3,Sqrt(Pow(err1,2) + Pow(err2,2) +Pow(err3,2)), eval1+eval2 + eval3);

        }//integ

}//Integ (class)