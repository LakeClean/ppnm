using System;
using static System.Math;
using static System.Console;
public class ann{

//public Func<double,double> f  = z => 1/(1+z*z);
//public Func<double,double> f  = z => Exp(-z*z);
public Func<double,double> f  = z => z*Exp(-z*z);
public vector p;
public readonly int n;
public double geta(int i) { return(p[i]); }
public double getb(int i) { return(p[i+n]); }
public double getw(int i) { return(p[i+2*n]); }
public void seta(int i,double z) { p[i]=z; }
public void setb(int i,double z) { p[i+n]=z; }
public void setw(int i,double z) { p[i+2*n]=z; }

public ann(int n){ this.n=n; p=new vector(3*n); }
public ann(vector p) { this.n=p.size/3; this.p=p; }

public double response(double x){
	double sum=0;
	for(int i=0;i<n;i++) sum+=getw(i)*f((x-geta(i))/getb(i));
	return sum;
	}

public void train(double[] xs,double[] ys){
	for(int i=0;i<n;i++){
		setw(i,1);
		setb(i,1);
		seta(i,xs[0]+(xs[xs.Length-1]-xs[0])*i/(n-1));
	}
	int ncalls=0;
	Func<vector,double> cost = (u) => {
		ncalls++;
		ann annu = new ann(u);
		double sum=0;
		for(int k=0;k<xs.Length;k++)
			sum+=Pow(annu.response(xs[k])-ys[k],2);
		return sum/xs.Length;
		};


minimization.Newton(cost,ref p,1e-3);

Error.Write($"ncalls={ncalls}\n");
	}

}//ann