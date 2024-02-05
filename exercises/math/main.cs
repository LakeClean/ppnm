
using System;
using static System.Console;
using static System.Math;
class main{
	static int Main(){
		Console.Write($"sqrt(2): {Math.Pow(2,0.5)}\n");
		Console.Write($"2^1.5: {Math.Pow(2,1.5)}\n");
		Console.Write($"e^pi: {Math.Pow(Math.E,Math.PI)}\n");
		Console.Write($"pi^e: {Math.Pow(Math.PI,Math.E)}\n");

		for(double x=1;x<10;x+=1)
			Console.WriteLine($"{sfuns.gamma(x)}");
		return 0;
	}
}
