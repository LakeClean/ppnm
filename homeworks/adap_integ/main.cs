using System;
using static System.Math;
using static System.Console;
public class main{
    // Implementing the error function
    public static double erf(double z,double acc=0.01,double eps=0.01){
            double integral;
            double error;

            if(z<0){return -erf(-z,acc,eps);}

            if( 0<= z && z<=1){
                (integral,error) = Integ.integ(x=>Exp(-x*x),0,z) ;
                return 2/Sqrt(PI) * integral ; }

            (integral, error) = Integ.integ(x=> Exp(-Pow(z + (1-x)/x,2) )/x /x, 0, 1,acc,eps);
            return 1 - 2/Sqrt(PI) * integral;
        }//err

    public static void Main(){

        WriteLine("################## Part A:##########################");
        //Checking some integrals:
        WriteLine("Calculating integral for the following functions in interval [0,1]: ");
        double acc = 1e-2;
        double eps = 1e-10;
        double integral;
        double error;
        int neval = 0;

        neval = 0;
        (integral,error) = Integ.integ(x => {neval++;return Sqrt(x);},0,1,1e-3,eps);
        WriteLine($" - sqrt(x) with limits [0,1]: estimate = {integral} +/-{error}, Correct value = {2.0/3}. Abs. accuracy goal: {1e-3}. Number of evaluation: {neval}");
        neval = 0;
        (integral,error) = Integ.integ(x => {neval++;return 1/Sqrt(x);},0,1,acc,eps);
        WriteLine($" - 1/sqrt(x) with limits [0,1]: estimate = {integral} +/-{error}, Correct value = {2.0}. Abs. accuracy goal: {acc}. Number of evaluation: {neval}");
        neval = 0;
        (integral,error) = Integ.integ(x => {neval++;return 4*Sqrt(1 - x*x);},0,1,acc,eps);
        WriteLine($" - 4sqrt(1-x^2) with limits [0,1]: estimate = {integral} +/-{error}, Correct value = {PI} Abs. accuracy goal: {acc}. Number of evaluation: {neval}");
        neval = 0;
        (integral,error) = Integ.integ(x => {neval++;return Log(x)/Sqrt(x);},0,1,acc,eps);
        WriteLine($" - ln(x)/sqrt(x) with limits [0,1]: estimate = {integral} +/-{error}, Correct value = {-4.0}. Abs. accuracy goal: {acc}. Number of evaluation: {neval}");
        neval = 0;
        (integral,error) = Integ.integ(x => {neval++;return Pow(x,-2);},1,double.PositiveInfinity,acc,eps);
        WriteLine($" - 1/x**2 with limits [1,inf]: estimate = {integral} +/-{error}, Correct value = {1}. Abs. accuracy goal: {acc}. Number of evaluation: {neval}");
        neval = 0;
        (integral,error) = Integ.integ(x => {neval++;return x*Exp(-x*x);},double.NegativeInfinity,double.PositiveInfinity,acc,eps);
        WriteLine($" - x*exp(-x*x) with limits [-inf,inf]: estimate = {integral} +/-{error}, Correct value = {0}. Abs. accuracy goal: {acc}. Number of evaluation: {neval}");

    

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
            integral_value = erf(k[i],1e-15,1e-15);
            if(Abs(tabulated_value - approx_value )>Abs(tabulated_value - integral_value )){N+=1;}

            outstream.WriteLine($"{k[i]} {tabulated_value} {approx_value} {integral_value}");
        }
        outstream.Close();
        WriteLine($"The Number of times the integral approximation is better than sfuns {N}/{k.size}");

        WriteLine(" ");
        WriteLine("################## Part B:##########################");
        WriteLine("We use Clenshaw-Curtis variable transformation: ");
        //Using Clenshaw-Curtis variable transformation:
        neval = 0;
        (integral,error ) = Integ.Clenshaw_Curtis(x => {neval++;return Log(x)/Sqrt(x);},0,1,0.01,eps);
        WriteLine($" - x*exp(-x*x) with limits [0,1]: estimate = {integral} +/-{error}, Correct value = {-4}. Abs. accuracy goal: {acc}. Number of evaluation: {neval}");

        neval = 0;
        (integral,error) = Integ.Clenshaw_Curtis(x => {neval++;return 1/Sqrt(x);},0,1,acc,eps);
        WriteLine($" - x*exp(-x*x) with limits [0,1]: estimate = {integral} +/-{error}, Correct value = {2}. Abs. accuracy goal: {acc}. Number of evaluation: {neval}");

        WriteLine($"We find that the above equations evaluate the integrals in 52 and 8 evaluations respectively.");
        WriteLine("I don't think numpy has a well known integrator but scipy does: 'scipy.integrate.quad'.");
        WriteLine("The python integrator with the same abs. and rel accuracy does 231 and 271 evaluations respectively.");



    }//Main

}//main