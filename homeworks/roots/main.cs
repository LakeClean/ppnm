using static System.Console;
using static System.Math;
public static class main{

    public static vector linear(vector v){
        vector x = v.copy();
        double a = 2;
        double b = 2;
        for(int i= 0; i<v.size; i++){
            x[i] = a*x[i] + b;
        }
        return x;
    }

    public static vector second_order_pol(vector v){
        vector x = v.copy();
        double a = 1;
        double b = 0;
        double c = 0;
        for(int i= 0; i<v.size; i++){
            x[i] = a*x[i]*x[i] + b*x[i] + c;
        }
        return x;
    }

    public static vector Rosenbrock_valley(vector v){
        vector w = v.copy();
        double x = w[0];
        double y = w[1];

        w[0] = 2*(-1 + x + 200*x*x*x -200*x*y);
        w[1] = 200*(y-x*x);
        return w;
    }

    public static vector Himmelblau(vector v){
        vector w = v.copy();
        double x = w[0];
        double y = w[1];

        w[0] = 4*x*(x*x + y - 11) + 2* (x+ y*y -7);
        w[1] = 2*(x*x + y - 11) + 4*y* (x+ y*y -7);
        return w;
    }


    public static void Main(){

        //Finding the roots of the above defined functions:
        vector root; double count; vector in_guess;

        //Linear function
        in_guess = new vector("1");
        (root, count) = roots.Newton(linear, in_guess);
        WriteLine($"We find a root of the linear function [f(x) = 2*x + 2] at x ={root[0]} with {count} iterations");
        
        //Second order polynomial
        in_guess = new vector("4");
        (root, count) = roots.Newton(second_order_pol, in_guess);
        WriteLine($"We find a root of the second order pol function at x ={root[0]} with {count} iterations");
        
        //Himmelblau:
        in_guess = new vector("4 4");
        (root, count) = roots.Newton(Himmelblau, in_guess);
        WriteLine($"We find a root of the Himmelblau function at x ={root[0]}, y={root[1]} with {count} iterations");

        //Rosenbrock Valley
        in_guess = new vector("2 1.1");
        (root, count) = roots.Newton(Rosenbrock_valley, in_guess);
        WriteLine($"We find a root of the Rosenbrock valley function at x ={root[0]}, y={root[1]} with {count} iterations");

    }//Main
}//main