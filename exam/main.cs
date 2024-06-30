using System;
using static System.Math;
using static System.Console;
public class main{

    public static void Main(){

        WriteLine("################### Exam project: Adaptive recursive integrator with subdivision in three subintervals. #########################");
        WriteLine(" - We utilize the resuable points x_i = {1/6, 3/6, 5/6}");
        WriteLine(" - This will for the trapezium rule and rectangle rule give the weights w_i={3/8,2/8,3/8} and v_i={1/3,1/3,1/3}");
        WriteLine(" - These weights are checked in the pdf: 3point_open_quadrature.pdf");
        WriteLine("");
        WriteLine("################### Testing: We test our integrator on the following integrals. ###############################");
        double acc = 1e-2;
        double eps = 1e-10;
        double integral;
        double error;
        int neval;
        

        //defining test functions:
        Func<double,double>[] functions = new Func<double,double>[8]{
            x => Sin(x),
            x => Sqrt(x),
            x => 1/Sqrt(x),
            x => 4*Sqrt(1 - x*x),
            x => Log(x)/Sqrt(x),
            x => Pow(x,-2),
            x => Exp(x),
            x => Sqrt(x)*Exp(-x),
        };
        double[] lower = new double[8]{0,0,0,0,0,1,double.NegativeInfinity,0};
        double[] upper = new double[8]{PI/2,1,1,1,1,double.PositiveInfinity,1,double.PositiveInfinity};
        double[] correct = new double[8]{1,2.0/3,2.0,PI,-4.0,1.0,E,Sqrt(PI)/2};
        string[] text = new string[8]{
            "Sin(x)",
            "sqrt(x)",
            "1/sqrt(x)",
            "4sqrt(1-x^2)",
            "ln(x)/sqrt(x)",
            "1/x**2",
            "exp(x)",
            "Sqrt(x)*Exp(-x)"
        };

        WriteLine("Function:".PadRight(15) + "Limits:".PadRight(25) + "Estimate".PadRight(20) + 
        "Tabulated:".PadRight(20) + "Est. error:".PadRight(20) +
         "Actual error:".PadRight(20) + "N-evaluations:".PadRight(20));
        for(int i = 0; i<functions.Length; i++){
            (integral,error, neval) = Integ3.integ(functions[i],lower[i],upper[i]);
            string line = $"{text[i]}".PadRight(15);
            line += $"[{lower[i]}, {upper[i]}]".PadRight(25);
            line += $"{Round(integral,4)}".PadRight(20);
            line += $"{Round(correct[i],4)}".PadRight(20);
            line += $"{Round(error,4)}".PadRight(20);
            line += $"{Round(Abs(integral-correct[i]),4)}".PadRight(20);
            line += $"{neval}".PadRight(20);
            WriteLine(line);
        }

        WriteLine("");

        WriteLine("#################### Comparing integrator with homework-integrator: #############################");

        int N_estimate = 0; //Number of times exam estimate is closer
        int N_error = 0; //Number of times exam error is closer to actual error
        int N = 8; // Number of test functions;

        WriteLine(" - Results from homework integrator with the same accuracy and error requirements: ");
        WriteLine("Function:".PadRight(15) + "Limits:".PadRight(25) + "Estimate".PadRight(20) + 
        "Tabulated:".PadRight(20) + "Est. error:".PadRight(20) +
         "Actual error:".PadRight(20) + "N-evaluations:".PadRight(20));
        for(int i = 0; i<functions.Length; i++){
            (integral,error, neval) = Integ.integ(functions[i],lower[i],upper[i]);
            string line = $"{text[i]}".PadRight(15);
            line += $"[{lower[i]}, {upper[i]}]".PadRight(25);
            line += $"{Round(integral,4)}".PadRight(20);
            line += $"{Round(correct[i],4)}".PadRight(20);
            line += $"{Round(error,4)}".PadRight(20);
            line += $"{Round(Abs(integral-correct[i]),4)}".PadRight(20);
            line += $"{neval}".PadRight(20);
            WriteLine(line);

            (double integral3,double error3, int neval3) = Integ3.integ(functions[i],lower[i],upper[i]);
            if(Abs(integral-correct[i]) > Abs(integral3-correct[i])){N_estimate+=1;};
            if(Abs(Abs(error) - Abs(integral-correct[i])) > Abs(Abs(error3) - Abs(integral3-correct[i]))){N_error+=1;};



        }
        WriteLine($"Number of times exam integrator makes better estimate: {N_estimate }/{N}");
        WriteLine($"Number of times exam error is closer to actual error: {N_error }/{N}");
        (integral,error, neval) = Integ3.integ(functions[0],lower[0],upper[0],0.001,0.000001);
        WriteLine($"{integral}, {error}, {neval}");



        WriteLine("");
        WriteLine("###################### Comments: #################################");
        WriteLine(" - It appears that the homework-integrator that only subdivides into 2 has a lower actual error.");
        WriteLine(" - The homework integrator makes many more evaluations for some integrals, while we seem \n" +
                    "     to mitigate this by subdividing in 3 instead of 2.");
        WriteLine(" - An issue with the program is that we reach Stack Overflow if we require too high an accuracy.\n" +
                    "      I tried to fix this by setting a limit to the number of evaluations so that it at least \n" +
                    "      returns a value and doesn't just crash the program, but this didn't help. \n" + 
                    "      This problem does not occour for the homework integrator, which can be set to high accuracy.");
        


        
        
    }//Main

}//main