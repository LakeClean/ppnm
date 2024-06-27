using System.Collections.Generic;
using static System.Console;
using System;
using static System.Math;
public static class ODE_solver{

    
    public static (vector,vector) rkstepXY(
        Func<double,vector,vector> f, //The function dy/dx= f(x,y) that takes a double and a vector and returns a vector
        double x, // The prior step 
        vector y, // The prior step
        double h // step size
        )
        {
            //(Bogacki-Shampine 32-method):
            matrix a = new matrix($"0 0 0 0; {1.0/2} 0 0 0; 0 {3.0/4} 0 0; {2.0/9} {1.0/3} {4.0/9} 0");
            vector c = new vector($"0 {1.0/2} {3.0/4} 1");
            vector b = new vector($"{2.0/9} {1.0/3} {4.0/9} 0");
            vector b_star = new vector($"{7.0/24} {1.0/4} {1.0/3} {1.0/8}");

            //(Euler/Midpoint 12-method):
            /*
            matrix a = new matrix($"0 0; {0.5} 0 ");
            vector c = new vector($"0 {0.5}");
            vector b = new vector($"0 1");
            vector b_star = new vector($"1 0");
            */

            var ks=new genlist<vector>();
            //ks.add(new vector(y.size));
            for(int i=0; i<a.size1; i++){
                vector p = y.copy(); //The lower order
                for(int j = 0; j<i; j++){
                    p += h*a[i,j]*ks[j];
                }
                ks.add(f(x+c[i]*h,p));
            }
        
            vector yh = y.copy();
            vector delta_y = new vector(y.size);

            for(int i = 0; i<a.size1; i++){
                yh+= ks[i] * b[i] * h;
                delta_y += h * (b[i]-b_star[i]) * ks[i];
            }
            return (yh, delta_y);
    }//rkstepXY

    
    public static (genlist<double>,genlist<vector>) driver(
        Func<double,vector,vector> f,
        (double,double) interval, // starting and ending points x and xn
        vector ystart, // starting vector y
        double h=0.125, //initial step size
        double abs = 0.01, //Abs accuaracy
        double rel = 0.01, // relative accuracy
        int max_step = 999
    ){
        //intrinsic values: 
        double power = 0.25;
        double safety = 0.95;

        //Initial values:
        var (a,b) = interval;
        double x = a;
        vector y = ystart.copy();

        //lists to return:
        var xs=new genlist<double>();
        xs.add(x);
        var ys=new genlist<vector>();
        ys.add(y);

        // Current step:
        int n = 0;



        while (x+h <= b && n<=max_step) // We stop when we have reached the end of the interval
        {
            if(x+h>b) h=b-x; // We should not go beyond interval

            var (y_step, delta_y) = rkstepXY(f,x,y,h);
            double tolerance = abs+y_step.norm()*rel * Sqrt(h/(b-a));
            double error = delta_y.norm();

            if (error < tolerance ){ // If the error is below the tolerance we accept the step and adjust x and y accordingly
                x+=h;
                y=y_step;
                xs.add(x);
                ys.add(y);
                n += 1;
            }
            h *= Min(Pow(tolerance/error,power) * safety,2); // Step size should not be changed by more than double

        }
    return (xs,ys);
    }//driver
    
    public static Func<double,vector> make_linear_interpolant(genlist<double> x,genlist<vector> y){
	    Func<double,vector> interpolant = delegate(double z){
		    int i= binsearch(x,z);
		    double dx = x[i+1] - x[i];
		    vector dy = y[i+1] - y[i];
		    return y[i]+dy/dx*(z-x[i]);
	    };
	return interpolant;
    }//make_linear_interpolant

    public static int binsearch(genlist<double> x, double z){
        if(!(x[0]<=z && z<=x[x.size-1])) throw new Exception($"binsearch: z={z},{x[x.size-1]},{x[0]} not within table");
	    int i=0, j=x.size-1;
	    while(j-i>1){
		    int mid=(i+j)/2;
		    if(z>x[mid]) i=mid; else j=mid;
		}
	    return i;
	}//binsearch

    public static Func<double,vector> make_ode_ivp_interpolant
    (Func<double,vector,vector> f,(double,double)interval,vector y,double acc=0.01,double eps=0.01,double hstart=0.01 ){
	    var (xlist,ylist) = driver(f,interval,y,acc,eps,hstart);
	    return make_linear_interpolant(xlist,ylist);
    }//make_ode_ivp_interpolant
    
    
}//ODE_solver