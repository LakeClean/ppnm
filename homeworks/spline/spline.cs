
using System;
using static System.Console;
using static System.Math;


public class spline{

    
    public static double linenterp(double[] x, double[] y, double z){
        int i = binsearch(x,z);
        double dy = y[i+1] - y[i];
        double dx = x[i+1] - x[i]; if(!(dx>0)) throw new Exception("uups...");
    return  y[i] + dy/dx * (z- x[i]);
    }//linenterp

    public static int binsearch(double[] x, double z){
        if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception($"binsearch: z={z},{x[x.Length-1]},{x[0]} not within table");
	    int i=0, j=x.Length-1;
	    while(j-i>1){
		    int mid=(i+j)/2;
		    if(z>x[mid]) i=mid; else j=mid;
		}
	    return i;
	}//binsearch
    



    public static double linterpInteg(double[] x, double[] y, double z){
        int j = binsearch(x,z);
        double integral_sum = 0;
        double dy;
        double dx;
        for(int i= 0; i<j;i++){
            dy = y[i+1] - y[i];
            dx = x[i+1] - x[i];

            integral_sum += 0.5 * dy/dx * (Pow(x[i+1],2) - Pow(x[i],2)) + (y[i] - dy/dx * x[i])*(x[i+1] - x[i]);

            
        }
        dy = y[j+1] - y[j];
        dx = x[j+1] - x[j];

        integral_sum += 0.5 * dy/dx * (Pow(z,2) - Pow(x[j],2)) + (y[j] - dy/dx * x[j])*(z - x[j]);

    return integral_sum;
    }//linterpInteg

    public class qspline {
	vector x,y,b,c;
	public qspline(vector xs,vector ys){
		x=xs.copy(); 
        y=ys.copy(); 
        int n = x.size;

        b = new vector(n-1);
        c = new vector(n-1);

        c[0] = 0;
        b[0] = (y[1] - y[0]) / (x[1] - x[0] );

        double dx_0, dx_1, dy_0, dy_1, p_0, p_1;
        for(int i=1; i<x.size-1;i++){
            dx_0 = x[i] - x[i-1];
            dy_0 = x[i] - x[i-1];
            p_0 = dy_0/dx_0 ;

            dx_1 = x[i+1] - x[i];
            dy_1 = x[i+1] - x[i];
            p_1 = dy_1/dx_1 ;

            c[i] = 1/dx_0 * (p_1 - p_0 - c[i-1]*dx_1);
            b[i] = p_1 - c[i]*dx_1;
        }
        
        
		}
	public double evaluate(double z){
        int i = binsearch(x,z);
        return y[i] + b[i]*(z-x[i]) + c[i]*Pow(z-x[i],2);
    }//evaluate

	public double derivative(double z){
        int i = binsearch(x,z);
        return b[i] + 2*c[i]*(z-x[i]);
    }//derivative
    
	public double integral(double z){
        int j = binsearch(x,z);
        double integral_sum = 0;
        
        for(int i= 0; i<j;i++){
            integral_sum += (x[i+1] - x[i])*y[i] + b[i]*Pow(x[i+1]-x[i],2)/2 + c[j]*Pow(x[i+1] - x[i],3)/3;}


        integral_sum += (z - x[j])*y[j] + b[j]*Pow(z-x[j],2)/2 + c[j]*Pow(z - x[j],3)/3;;

    return integral_sum;
 
    }//integral

	}//qspline

}//spline



