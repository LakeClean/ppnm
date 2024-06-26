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

            if( 0<= z && z<=1){
                (integral,error, neval) = Integ.integ(x=>Exp(-x*x),0,z) ;
                return 2/Sqrt(PI) * integral ; }

            (integral, error, neval) = Integ.integ(x=> Exp(-Pow(z + (1-x)/x,2) )/x /x, 0, 1,acc,eps);
            return 1 - 2/Sqrt(PI) * integral;
        }//err

    public static void Main(){

        WriteLine("################## Part A:##########################");
        //Checking some integrals:
        WriteLine("Calculating integral for the following functions in interval [0,1]: ");
        double acc = 1e-10;
        double eps = 1e-10;
        double integral;
        double error;
        int neval;

        (integral,error, neval) = Integ.integ(x => Sqrt(x),0,1,acc,eps);
        WriteLine($"sqrt(x): estimate = {integral} +/-{error}, Correct value = {2.0/3}. Abs. accuracy goal: {acc}. Rel. accuracy goal: {eps*integral}.");

        (integral,error, neval) = Integ.integ(x => 1/Sqrt(x),0,1,acc,eps);
        WriteLine($"1/sqrt(x): estimate = {integral} +/-{error}, Correct value = {2.0}. Abs. accuracy goal: {acc}. Rel. accuracy goal: {eps*integral}.");

        (integral,error, neval) = Integ.integ(x => 4*Sqrt(1 - x*x),0,1,acc,eps);
        WriteLine($"4sqrt(1-x^2): estimate = {integral} +/-{error}, Correct value = {PI} Abs. accuracy goal: {acc}. Rel. accuracy goal: {eps*integral}.");

        (integral,error, neval) = Integ.integ(x => Log(x)/Sqrt(x),0,1,acc,eps);
        WriteLine($"ln(x)/sqrt(x): estimate = {integral} +/-{error}, Correct value = {-4.0}. Abs. accuracy goal: {acc}. Rel. accuracy goal: {eps*integral}.");


        //Importing tabulated errorfunction found on wikipedia:
        string infile = "tabulated_erf.txt";
        var instream = new System.IO.StreamReader(infile);
        int index = 0;
        vector k = new vector(32);
        vector y = new vector(32);
        for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
            var value = line.Split(" ");
            k[index] = double.Parse(value[0]);
            y[index] = double.Parse(value[1]);
            index += 1;
        }
        instream.Close();

        
        //Calculating values for the errorfunction, writing it to file and comparing with tabulated values:
        string outfile = "out_erf.txt";
        var outstream=new System.IO.StreamWriter(outfile,append:false);
        double tabulated_value, approx_value, integral_value;
        int N = 0; // Number of times integral is more accurate
        for(int i = 0;i<k.size;i+=1){
            tabulated_value = y[i];
            approx_value = sfuns.erf(k[i]);
            integral_value = erf(k[i],1e-8,1e-8);
            if(Abs(tabulated_value - approx_value )>Abs(tabulated_value - integral_value )){N+=1;}

            outstream.WriteLine($"{k[i]} {tabulated_value} {approx_value} {integral_value}");
        }
        outstream.Close();
        WriteLine($"The Number of times the integral approximation is better than sfuns {N}/{k.size}");


        WriteLine("################## Part B:##########################");

        //Using Clenshaw-Curtis variable transformation:
        WriteLine($"1/sqrt(x): {Integ.Clenshaw_Curtis(x => 1/Sqrt(x),0,1,acc,eps)}, {2.0}");
        //WriteLine($"ln(x)/sqrt(x): {Integ.Clenshaw_Curtis(x => Log(x)/Sqrt(x),0,1,acc,eps)}, {-4.0}");
        /*
        WriteLine("Notice that we go from ~1million evaluation of the integral to less than 200 evaluations");
        WriteLine($"{Integ.integ(x=>Exp(-Pow(x,2)),-1.1/0,1.1/0)} {Sqrt(PI)}");
        WriteLine($"{Integ.integ(x=>Exp(-Pow(x,2)),-1.1/0,0)} {Sqrt(PI)/2}");
        WriteLine($"{Integ.integ(x=>Exp(-Pow(x,2)),0,1.1/0)} {Sqrt(PI)/2}");
        */



    }//Main

}//main