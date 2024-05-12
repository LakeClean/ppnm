using System;
using static System.Math;
public class minimization{

    public static vector gradient(Func<vector,double> f,vector x){
        double dim = x.size;
        vector grad_f = new vector(dim);
        for(int i=0; i<dim; i++){
            vector temp = x.copy();
            double step = Abs(x[i])*Pow(2,-26);
            temp[i] = x[i] + step;
            grad_f[i] = (f(temp) - f(x))/(step)
        }
        return grad_f;
    }
    
    public static vector qNewton(Func<vector,double> f,vector start, double acc=1e-2){
        // Quasi-Newton minimization method with numerical gradient and backtracking linesearch and rank-1 update //
        // f: the objective function                                                                  //
        // start: guess for position of minimum                                                                   //
        vector x = start.copy();

        // Set the inverse Hesian matrix to the identity matrix:
        int dim = start.size;
        matrix B = new matrix(dim);
        B.setid();


        // Repeating the following until the norm of the gradient of the objective function is less than tolerance:
        while(gradient(f,x).norm() > acc){
            // Calculate the Newton step:
            vector Delta_x = -B*gradient(f,x);

            // Doing linesearch:
            double lambda = 1;
            while(True){

                vector s = lambda* Delta_x;
                vector y = gradient(x+s) - gradient(x);
                vector u = s - B*y;
                vector B_step = 

                if(f(x+lambda*Delta_x)<f(x)){ // Accept step and update B:
                    x = x + Delta_x;
                    B = B + B_step;
                    break
                }

                lambda *= 1/2;

                if(lambda < 1/1024){ // Accept step and reset B to identity matrix
                    x = x + Delta_x;
                    B.setid();
                    break
                }

            }
            

        }

        return x;

    }//qNewton


}//roots

