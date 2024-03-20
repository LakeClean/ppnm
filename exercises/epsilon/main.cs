using static System.Console;
using System;
class main{
	static int Main(){

		//1
		// Finding my maximum integer
		WriteLine("Task 1: ");
		int i = 0;
		while (i+1>i){i+=1;}
			WriteLine($"My maximum representable is {i}");

		// Finding my minimum integer
		i = 0;
               	while (i-1<i){i-=1;}
                	WriteLine($"My minimum representable is {i}",int.MinValue);

		//2
		WriteLine("Task 2: ");
		double x = 1;
		while (x+1 != 1){
				x/=2;
				}
		Write($"The Machine epsilon for doubles is {x}. It should be in the order of {Math.Pow(2,-52)}.\n");

		float y=1f;
		while((float)(1f+y) != 1f){y/=2f;} y*=2f;
		Write($"The Machine epsilon for floats is {y}. It should be in the order of {Math.Pow(2,-23)}.\n");

		//3
		WriteLine("Task 3: ");
		double epsilon = Math.Pow(2,-52);
		double tiny = epsilon/2;
		double a = 1+tiny+tiny;
		double b = tiny+tiny +1;

		Write($"a={a:e16}\n"); // returns 1.0000000000000000000
		Write($"b={b:e16}\n"); // returns 1.0000000000000000002
		Write($"a==b: {a==b}, 1<b: {1<b}, 1<a: {1<a}\n");

		
		WriteLine(@"epsilon is already the smallest value representable. tiny can therefore not be represented. Therefore when we define
		a as 1 and then add two unrepresentable values, nothing is added. However when we define b as the tiny value
		something has to be put in so it just adds the smallest representable it can. Then when one is added we have
		a slightly higher value than one and b>a.");
		


		//4
		WriteLine("Task 4: ");
		double d2 = 0.1 * 8;
		double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
		WriteLine($"d1={d1:e15}");
		WriteLine($"d2={d2:e15}");
		WriteLine($"d1==d2 ? => {d1==d2}");

		Write($"approx(d1,d2): {approx(d1,d2)}\n");
		return 0;
		}//Main
	//4
	static public bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
		if (Math.Abs(b-a) <= acc) return true;
		if(Math.Abs(b-a) <= Math.Max(Math.Abs(a),Math.Abs(b))*eps) return true;
		return false;
		}//approx

	

}//main
