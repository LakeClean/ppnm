using System;
using static System.Math;
using static System.Console;
public class ann{
   public static int n = 3;// Number of hidden neurons. 
   public static Func<double,double> f = x => x * Exp(-x*x); //activation function
   public static double a, b, w ; 
   public static vector p;
   
   /*
   public ann(int m){
      n = m;
      p = new vector(3*n);
      for(int i=0; i<n; i++){
         p[3*i] = 1;
         p[3*i + 1] = 1;
         p[3*i + 2] = 0;

      }
   }*/




   public static double response(double x, vector p){
      // return the response of the network to the input signal x
      // parameters p are added to be able to minimize these
      
      double sum = 0;
      for(int i=0; i<n; i++){//Summing over all the neurons
         sum += f((x-p[3*i])/p[3*i+1])*p[3*i+2];

      }
      return sum;

     }

   public static vector train(vector x,vector y){
      /* train the network to interpolate the given table {x,y} */
      Func<vector,double> cost = delegate(vector p) {double sum=0; for(int i=0; i<x.size; i++) sum+= Pow(response(x[i],p) - y[i],2); return sum;};

      vector guess = new vector(3*n);
      for(int i=0; i<n; i++){
         guess[3*i] = 1;
         guess[3*i + 1] = 1;
         guess[3*i + 2] = 1;

      }

      (double count,vector result) = minimization.Newton(cost,guess);

      return result;

      
      
   }
}//ann