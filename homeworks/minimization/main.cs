using static System.Console;
using static System.Math;
public static class main{

    public static double polynomial(vector v){
        double x = v[0];
        return 2*x*x + 2*x + 3;
    }


    public static double Rosenbrock_valley(vector v){
        double x = v[0];
        double y = v[1];

        return Pow((1-x),2) + 100*Pow((y-x*x),2);
    }

    public static double Himmelblau(vector v){
        double x = v[0];
        double y = v[1];

        return Pow((x*x + y -11),2) + Pow((x + y*y -7),2);
    }


    public static void Main(){
        vector in_guess; vector min; double steps;
        // Himmelblau:
        in_guess = new vector("4 4");
        (steps, min) = minimization.Newton(Himmelblau,in_guess);
        WriteLine("Finding a minimum of Himmelblau function:");
        WriteLine($"initial guess [x={in_guess[0]} y ={in_guess[1]}]");
        WriteLine($"Result [x={min[0]} y ={min[1]}]");
        WriteLine($"Number of steps: {steps}");

        WriteLine("################################");
        //Rosenbrock
        in_guess = new vector("2 2");
        (steps, min) = minimization.Newton(Rosenbrock_valley,in_guess);
        WriteLine("Finding a minimum of Rosenbrock valley function:");
        WriteLine($"initial guess [x={in_guess[0]} y ={in_guess[1]}]");
        WriteLine($"Result [x={min[0]} y ={min[1]}]");
        WriteLine($"Number of steps: {steps}");

        WriteLine("################################");
        //Pol
        in_guess = new vector("2");
        (steps, min) = minimization.Newton(polynomial,in_guess);
        WriteLine("Finding a minimum of Polynomial function[2*x*x + 2*x + 3]:");
        WriteLine($"initial guess [x={in_guess[0]}]");
        WriteLine($"Result [x={min[0]}]");
        WriteLine($"Number of steps: {steps}");
        

        
        
    }//Main
}//main