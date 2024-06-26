using static System.Console;
using System;
using static System.Math;
class main{
    static void Main(){
        //importing original data:
        string infile = "input.txt";
        var instream = new System.IO.StreamReader(infile);
        int index = 0;
        vector x = new vector(9);
        vector y = new vector(9);
        vector dy = new vector(9);
        for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
            var value = line.Split(" ");
            x[index] = double.Parse(value[0]);
            y[index] = double.Parse(value[1]);
            dy[index] = double.Parse(value[2]);
            index += 1;
            
        }
        instream.Close();

        //Defining linear function: ln(y) = ln(a) - lambda*t
        var fs = new Func<double,double>[] {z => 1, z=> z};

        // Rewriting y and dy 
        for(int i=0; i<y.size; i++) {
            y[i] = Log(y[i]);
            dy[i] = dy[i]/y[i]; // uncertainty for y = f(x) is found from propagation of errors: [dy**2 = (∂f/∂x)**2 dx**2]
        }


        (vector c, matrix C) = least_squares.lsfit(fs,x,y,dy);
        WriteLine("Fitting the following data with linear function:");
        x.print("t: ");
        y.print("y: ");
        dy.print("Uncertainty in y: ");
        c.print("We find the resulting coefficients ln(a) and -lambda: ");
        C.print("The covariant matrix: ");
        WriteLine($"The diagonal element sqrt(C[1,1])={Sqrt(C[1,1])} gives uncertainty in lambda ");
        WriteLine($"Halflife of Ra-224 is then T_1/2 = ln(2)/lambda = {-Log(2)/c[1]} +/- {Log(2)*Sqrt(C[1,1])/Pow(c[1],2)} days");
        WriteLine("The modern value is 3.6319(23) d [https://en.wikipedia.org/wiki/Isotopes_of_radium]");
        WriteLine("Our result is therefore within the modern value given the estimated uncertainties.");

        // Writing some datapoints to output.txt for plotting of result:
        string outfile = "output.txt";
        var outstream=new System.IO.StreamWriter(outfile,append:false);

        for(int i = 0; i<y.size; i++ ){
            double fit = x[i]*c[1] + c[0];
            outstream.WriteLine($"{x[i]} {y[i]} {dy[i]} {fit}");
            
        }
        outstream.Close();

    }
}

