
using System;
using static System.Console;
using static System.Math;


public class spline{

    public static double linenterp(double[] x, double[] y, double z){
        int i = binsearch(x,z);
        double dy = y[i+1] - y[i];
        double dx = x[i+1] - x[i];
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
        double z_y = linenterp(x,y,z);

        for(int i= 0; i<=j;i++){
            double dy = y[i+1] - y[i];
            double dx = x[i+1] - x[i];
            if (i==j){
                integral_sum += z_y*(z-x[i]) + 0.5 * dy/dx * Pow(z-x[i],2);
            }
            else{
                integral_sum += y[i]*(x[i+1]-x[i]) + 0.5 * dy/dx * Pow(x[i+1]-x[i],2);
            }
        }

    return integral_sum;
    }//linterpInteg

    

}//spline



