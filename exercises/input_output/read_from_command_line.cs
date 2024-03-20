using static System.Console;
using static System.Math;
using System;
class main{
	public static int Main(string[] args){

		WriteLine("Task 1: ");
		// Reading from command-line:
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-numbers"){
				var numbers=words[1].Split(',');
				foreach(var number in numbers){
					double x = double.Parse(number);
					WriteLine($"{x}, {Sin(x)}, {Cos(x)}");
					}
				}
			}
		
	return 0;
	}//Main
}//main
