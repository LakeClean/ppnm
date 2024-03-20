using static System.Console;
using static System.Math;

class main{
    public static void Main(){

        var result1 = cmath.sqrt(new complex( -1, 0));
        var result2 = cmath.log(new complex( 0, 1));
        var result3 = cmath.sqrt(new complex( 0, 1));
        var result4 = cmath.pow(new complex( 0, 1),new complex( 0, 1));
        WriteLine($"sqrt(-1) = {result1} is equal to +/-i: {(result1).approx(new complex(0,1))} ");
        WriteLine($"ln(i) = {result2} is equal to iπ/2: {(result2).approx(new complex(0,PI/2))} ");
        WriteLine($"sqrt(i) = {result3} is equal to 1/√2+i/√2: {(result3).approx(new complex(1/Sqrt(2),1/Sqrt(2)))} ");
        WriteLine($"i^(i) = {result4} is approx. equal to 0.208: {(result4).approx(new complex(0.20787957635076,0))} ");
    }//Main
}//main