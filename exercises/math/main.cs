using System;
using static System.Console;
using static System.Math;
class main{
	static int Main(){
		//#1
		double sqrt2 = Pow(2,0.5);
		double root5_of2 = Pow(2,0.2);
		double epowerpi = Pow(E,PI);
		double pipowere = Pow(PI,E);
		Write($"sqrt2^2 = {sqrt2*sqrt2} should equal 2\n");
		Write($"2^1/5 = {root5_of2} should equal 1.148698\n");
		Write($"e^pi = {epowerpi} should equal 23.140692\n");
		Write($"pi^e = {pipowere} should equal 22.45915\n");
		//#2
		double x = 1;
		for(double i=1;i<11;i+=1){
			if (i>1) {x = x*(i-1);}
			Console.WriteLine($"gamma({i})={sfuns.gamma(i)} should be equal to {x}");
			}
		//#3
		x = 1;
		for(double i=1;i<11;i+=1){
			if (i>1) {x = x*(i-1);}
			Console.WriteLine($"lngamma({i})={sfuns.lngamma(i)} should be equal to {Log(x)}");
			}
		return 0;
	}
}
