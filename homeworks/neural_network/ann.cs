using System;
using static System.Math;
using static System.Console;
using static System.Random;
//using linalg;
//using calculus;


public class ann{
   int n;// Number of hidden neurons. 
   vector p;
   int count;
   vector x,y;
   double acc, eps;
   Func<double,double> f = (double x) => x*Exp(-x*x);

   //Constructor
   public ann(int n, double acc=1e-2, double eps=1e-2){
		this.n = n;
		this.acc = acc;
		this.eps = eps;
		this.p = new vector(this.n*3); /* 3 parameters per neuron*/
		var rand = new Random(1);
		for(int i=0; i<p.size; i++) p[i] = rand.NextDouble(); /* start guess: all params = 1 */
	}

   public void train(vector x,vector y){
      /* train the network to interpolate the given table {x,y} */
      this.x = x; this.y = y;
		for(int i=0; i<n; i++) p[3*i] = x[0]+(i+0.5)*(x[x.size-1]-x[0])/n;

      vector newp = minimization.qnewton(Cost,p,acc,1e-2);
      this.count = minimization.count1;
		this.p = newp;

		}
   
   public double predict(double x, string func = "f"){
		return F(x,p,this.f);
	}

   double F(double xi, vector fitp, Func<double,double> func){
		double sum = 0.0;
		double ai, bi, wi;
		for(int i=0; i<p.size; i+=3){
			ai = fitp[i]; bi = fitp[i+1]; wi = fitp[i+2];
			sum += func((xi-ai)/bi)*wi;
		}
		return sum;
	}

   double Cost(vector fitp){
		double sum = 0.0;
		for(int i=0; i<x.size; i++){
			sum += Pow(F(x[i],fitp,this.f)-y[i],2);
		}
		return sum;
	}

   public vector get_params(){
		return p;
	}

   
	public int get_count(){
		return count;
	}
   

      
}//ann