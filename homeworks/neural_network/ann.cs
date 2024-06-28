using System;
using static System.Math;
using static System.Console;
public class ann{
   public readonly int n;// Number of hidden neurons. 
   public static Func<double,double> f = x => x * Exp(-x*x); //activation function
   public static double a, b, w ; 
   public static vector p;
   public double geta(int i) { return(p[i]); }
   public double getb(int i) { return(p[i+n]); }
   public double getw(int i) { return(p[i+2*n]); }
   public void seta(int i,double z) { p[i]=z; }
   public void setb(int i,double z) { p[i+n]=z; }
   public void setw(int i,double z) { p[i+2*n]=z; }



   public static double response(double x){
      // return the response of the network to the input signal x
      // parameters p are added to be able to minimize these
      
      double sum = 0;
      for(int i=0; i<ann.n; i++){//Summing over all the neurons
         sum += getw(i)*f((x-geta(i))/getb(i));

      }
      return sum;

     }

   public static vector train(vector x,vector y){
      /* train the network to interpolate the given table {x,y} */

      for(int i=0;i<n;i++){
		   setw(i,1);
		   setb(i,1);
		   seta(i,x[0]+(x[x.Length-1]-x[0])*i/(n-1));
	      }
      int ncalls=0;
      /*
      Func<vector,double> cost = delegate(vector p) {
         double sum=0; 
         for(int i=0; i<x.size; i++){
            sum+= Pow(response(x[i]) - y[i],2);}
         return sum;
         };
      */

      Func<vector,double> cost = (u) => {
		ncalls++;
		ann annu = new ann(u);
		double sum=0;
		for(int k=0;k<x.size;k++)
			sum+=Pow(annu.response(x[k])-y[k],2);
		return sum/x.size;
		};

      (double count,vector result) = minimization.Newton(cost,p);

      return result;

      
      
   }
}//ann