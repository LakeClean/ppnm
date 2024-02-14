using System;
class main{
	static double d2 = 0.1*8;
	static double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	static int Main(){

		//1
		// Finding my maximum integer
		//int i = 0;
		//while (i+1>i){i+=1;}
		//System.Console.Write($"My maximum integer is {i}");
		//return 0;
		// Finding my minimum integer
               	// while (i-1<i){i-=1;}
                //System.Console.Write($"My minimum integer is {i}\n",int.MinValue);

		//2
		/*
		double x = 1;
		while (x+1 != 1){
				x/=2;
				}
		System.Console.Write($"{x}\n");

		float y=1f;
		while((float)(1f+y) != 1f){y/=2f;} y*=2f;
		System.Console.Write($"{y}\n");
		*/

		//3
		/*
		double epsilon = Math.Pow(2,-52);
		double tiny = epsilon/2;
		double a = 1+tiny+tiny;
		double b = tiny+tiny +1;

		System.Console.Write($"epsilon= {Math.Pow(2,-52)}\n");
		System.Console.Write($"{a:e16}\n"); // returns 1.0000000000000000000
		System.Console.Write($"{b:e16}\n"); // returns 1.0000000000000000002
		System.Console.Write($"{a==b}, 1<b: {1<b}, 1<a: {1<a}\n"); // returns False, 1<b: True, 1<a: False
		*/
		/*
		When we add such a tiny value to one this does not change the value as we checked above.
		however when we already have the tiny number represented and then add a one, ot does not cost extra memory
		to change the 0 to a one and so the two values differ.
		*/


		//4
		/*
		double d2 = 0.1 * 8;
		double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
		Console.WriteLine($"d1={d1:e15}");
		Console.WriteLine($"d2={d2:e15}");
		Console.WriteLine($"d1==d2 ? => {d1==d2}");

		static public bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
		if (Math.Abs(b-a) <= acc) return true;
		if(Math.Abs(b-a) <= Math.Max(Math.Abs(a),Math.Abs(b))*eps) return true;
		return false;
		}*/
		System.Console.Write($"d1={d1:e15}\n");
    	System.Console.Write($"d2={d2:e15}\n");
		System.Console.Write($"d1==d2 ? => {d1==d2}\n");
		System.Console.Write($"{approx(d1,d2)}\n");

		return 0;
		}//Main
	//4
	static public bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
		if (Math.Abs(b-a) <= acc) return true;
		if(Math.Abs(b-a) <= Math.Max(Math.Abs(a),Math.Abs(b))*eps) return true;
		return false;
		}//approx
		

}//main
