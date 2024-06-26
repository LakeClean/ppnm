using System;
using static System.Math;
using static System.Console;
public class main{

    public static void Main(){

        double acc = 1e-2;
        double eps = 1e-10;
        double integral;
        double error;
        int neval;

        (integral,error, neval) = Integ.integ(x => Sqrt(x),0,1,acc,eps);
        WriteLine($"sqrt(x): estimate = {integral} +/-{error}, Correct value = {2.0/3}. Abs. accuracy goal: {acc}. Number of evaluation: {neval}");
        
        (integral,error, neval) = Integ.integ(x => 1/Sqrt(x),0,1,acc,eps);
        WriteLine($"1/sqrt(x): estimate = {integral} +/-{error}, Correct value = {2.0}. Abs. accuracy goal: {acc}. Number of evaluation: {neval}");
        
        (integral,error, neval) = Integ.integ(x => 4*Sqrt(1 - x*x),0,1,acc,eps);
        WriteLine($"4sqrt(1-x^2): estimate = {integral} +/-{error}, Correct value = {PI} Abs. accuracy goal: {acc}. Number of evaluation: {neval}");
        
        (integral,error, neval) = Integ.integ(x => Log(x)/Sqrt(x),0,1,acc,eps);
        WriteLine($"ln(x)/sqrt(x): estimate = {integral} +/-{error}, Correct value = {-4.0}. Abs. accuracy goal: {acc}. Number of evaluation: {neval}");
        
        
    }//Main

}//main