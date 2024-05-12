using System;
using static System.Math;
public class roots{

    public static matrix jacobian(
        Func<vector,vector> f, 
        vector x, 
        vector fx = null, 
        vector dx = null){

        }//jacobian
    
    public static vector Newton(
        Func<vector,vector> f,
        vector start, 
        double epsilon=1e-2){
        
        vector x = start.copy();
        int dim = x.size;
        while(f(x).norm() > epsilon){
            ///////////  Calculating the Jacobian matrix /////////////
            matrix J = new matrix(dim,dim);
            
            for(int i=0; i<dim; i++){
                double delta_x_i = Abs(x[i])*Pow(2,-26);
                vector temp = x.copy();

                for(int k=0; k<dim; k++){
                    temp[k] += delta_x_i;
                    J[i,k] = (f(temp)[i] - f(x)[i]) / delta_x_i ; 
                }
            }

            ////////////  Solving J∆x = -f(x) with previously developed process //////////////

            // First we decompose J and then we solve:
            matrix Q;
            matrix R; 
            (Q,R) = QRGS.decomp(J);
            vector delta_x = QRGS.solve(Q,R,-f(x));

            double lambda = 1;

            while( (f(x+lambda*delta_x).norm() > (1-lambda/2)*f(x).norm()) && lambda >= 1/1024 ){
                lambda *= 1/2;
            }

            x = x + lambda*delta_x;
        }

        return x;

    }//Newton


}//roots

