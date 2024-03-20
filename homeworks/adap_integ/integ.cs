using static System.Math;
using System;
using static System.Double;
public class Integ{

    // defining a recursive open-quadrature adaptive integrator that accepts negative limits:

    public static (double,double,int) integ (
        Func<double,double> f,
        double a,
        double b, 
        double acc=0.01, 
        double eps=0.01,
        double f2 = NaN,
        double f3 = NaN,
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
        double f4 = f(a + 5*(b-a)/6);
        if(IsNaN(f2)){
            f2 = f(a + 2*(b-a)/6);
            f3 = f(a + 4*(b-a)/6);
            }
        double Q = (2*f1 + f2 + f3 + 2*f4)/6 * (b-a);
        double q = (f1 + f2 + f3 + f4)/4 * (b-a);
        double err = Abs(Q-q);
        double tol = acc + eps*Abs(Q);
        eval += 1;
        if(err < tol){
            return (Q,err,eval);
        }
        (double Q1, double err1, int eval1) = integ(f,a,(a+b)/2, acc/Sqrt(2), eps, f1, f2,eval);
        (double Q2, double err2, int eval2) = integ(f,(a+b)/2,b, acc/Sqrt(2), eps, f3, f4,eval);

        return (Q1 + Q2,Sqrt(Pow(err1,2) + Pow(err2,2)), eval1+eval2);

        }//integ
    

    public static (double,double,int) Clenshaw_Curtis(
        Func<double,double> f,
        double a,
        double b, 
        double acc=0.01, 
        double eps=0.01){

        return integ(theta => f( (a+b)/2+(b-a)/2*Cos(theta) )*Sin(theta)*(b-a)/2, 0, PI, acc, eps);
        }//Clenshaw_Curtis

}//Integ (class)