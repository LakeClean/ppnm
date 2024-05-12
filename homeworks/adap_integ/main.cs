using System;
using static System.Math;
using static System.Console;
public class main{
    // Implementing the error function
    public static double erf(double z,double acc=0.01,double eps=0.01){
            double integral;
            double error;
            int neval;

            if(z<0){return -erf(-z,acc,eps);}
            //return 2/Sqrt(PI) * Integ.integ(x=>Exp(-x*x),0,z,acc,eps) ;
            if( 0<= z && z<=1){
                (integral,error, neval) = Integ.integ(x=>Exp(-x*x),0,z) ;
                return 2/Sqrt(PI) * integral ; }

            (integral, error, neval) = Integ.integ(x=> Exp(-Pow(z + (1-x)/x,2) )/x /x, 0, 1,acc,eps);
            return 1 - 2/Sqrt(PI) * integral;
            
            //if(1<z){return 1 - 2/Sqrt(PI) * Integ.integ(x=> Exp(-Pow((z+ (1-x)/x),2)/x /x), 0, 1);}
        }//err

    public static void Main(){
        //Checking some integrals:
        WriteLine("Calculating integral for the following functions in interval [0,1]: ");
        double acc = 1e-10;
        double eps = 1e-10;
        WriteLine($"sqrt(x): {Integ.integ(x => Sqrt(x),0,1,acc,eps)}, {2.0/3}");
        WriteLine($"1/sqrt(x): {Integ.integ(x => 1/Sqrt(x),0,1,acc,eps)}, {2.0}");
        WriteLine($"4sqrt(1-x^2): {Integ.integ(x => 4*Sqrt(1 - x*x),0,1,acc,eps)}, {PI}");
        WriteLine($"ln(x)/sqrt(x): {Integ.integ(x => Log(x)/Sqrt(x),0,1,acc,eps)}, {-4.0}");

        //Calculating values for the errorfunction
        for(double i = 0;i<3;i+=0.02){
            WriteLine(erf(i,1e-8,1e-8));
        }

        //Using Clenshaw-Curtis variable transformation:
        WriteLine($"1/sqrt(x): {Integ.Clenshaw_Curtis(x => 1/Sqrt(x),0,1,acc,eps)}, {2.0}");
        //WriteLine($"ln(x)/sqrt(x): {Integ.Clenshaw_Curtis(x => Log(x)/Sqrt(x),0,1,acc,eps)}, {-4.0}");
        /*
        WriteLine("Notice that we go from ~1million evaluation of the integral to less than 200 evaluations");
        WriteLine($"{Integ.integ(x=>Exp(-Pow(x,2)),-1.1/0,1.1/0)} {Sqrt(PI)}");
        WriteLine($"{Integ.integ(x=>Exp(-Pow(x,2)),-1.1/0,0)} {Sqrt(PI)/2}");
        WriteLine($"{Integ.integ(x=>Exp(-Pow(x,2)),0,1.1/0)} {Sqrt(PI)/2}");
        */

        // Outputting to out_erf.txt:
        /*
        string outfile="out_erf.txt";
        var outstream=new System.IO.StreamWriter(outfile,append:false);

        for(double x = 0; x<3.6; x+=0.02){
            outstream.WriteLine($"{x} {erf(x,acc,eps)}");
                                }
        outstream.Close();
        */


    }//Main

}//main