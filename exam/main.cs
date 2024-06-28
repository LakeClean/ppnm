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
        Func<double,double>[] functions = new Func<double,double>[7]{
            x => Sqrt(x),
            x => 1/Sqrt(x),
            x => 4*Sqrt(1 - x*x),
            x => Log(x)/Sqrt(x),
            x => Pow(x,-2),
            x => x*Exp(-x*x),
            x => Sqrt(x)*Exp(-x)
        };
        double[] lower = new double[7]{0,0,0,0,1,double.NegativeInfinity,0};
        double[] upper = new double[7]{1,1,1,1,double.PositiveInfinity,double.PositiveInfinity,double.PositiveInfinity};
        double[] correct = new double[7]{2.0/3,2.0,PI,-4.0,1.0,0.0,Sqrt(PI)/2};
        string[] text = new string[7]{
            "sqrt(x)",
            "1/sqrt(x)",
            "4sqrt(1-x^2)",
            "ln(x)/sqrt(x)",
            "1/x**2",
            "x*exp(-x*x)",
            "Sqrt(x)*Exp(-x)"
        };

        WriteLine("Function:".PadRight(15) + "Estimate".PadRight(20) + 
        "Tabulated:".PadRight(20) + "Est. error:".PadRight(20) +
         "Actual error:".PadRight(20) + "N-evaluations:".PadRight(20));
        for(int i = 0; i<functions.Length; i++){
            (integral,error, neval) = Integ3.integ(functions[i],lower[i],upper[i]);
            string line = $"{text[i]}".PadRight(15);
            line += $"{Round(integral,4)}".PadRight(20);
            line += $"{Round(correct[i],4)}".PadRight(20);
            line += $"{Round(error,4)}".PadRight(20);
            line += $"{Round(Abs(integral-correct[i]),4)}".PadRight(20);
            line += $"{neval}".PadRight(20);
            WriteLine(line);
        }

        WriteLine("");

        WriteLine("#################### Comparing integrator with homework-integrator: #############################");

        WriteLine("Function:".PadRight(15) + "Estimate".PadRight(20) + 
        "Tabulated:".PadRight(20) + "Est. error:".PadRight(20) +
         "Actual error:".PadRight(20) + "N-evaluations:".PadRight(20));
        for(int i = 0; i<functions.Length; i++){
            (integral,error, neval) = Integ.integ(functions[i],lower[i],upper[i]);
            string line = $"{text[i]}".PadRight(15);
            line += $"{Round(integral,4)}".PadRight(20);
            line += $"{Round(correct[i],4)}".PadRight(20);
            line += $"{Round(error,4)}".PadRight(20);
            line += $"{Round(Abs(integral-correct[i]),4)}".PadRight(20);
            line += $"{neval}".PadRight(20);
            WriteLine(line);
        }

        WriteLine("");
        WriteLine("###################### Comments: #################################");
        WriteLine(" - It appears that the homework-integrator that only subdivides into 2 has a lower actual error.");
        WriteLine(" - The homework integrator makes many more evaluations for some integrals, while we seem \n" +
                    "     to mitigate this by subdividing in 3 instead of 2.");
        WriteLine(" - An issue with the program is that we reach Stack Overflow if we require too high an accuracy.");
        


        
        
    }//Main

}//main