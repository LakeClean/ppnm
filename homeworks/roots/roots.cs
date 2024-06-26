using System;
using static System.Math;
public class roots{

    public static matrix jacobian
        (Func<vector,vector> f,vector x,vector fx=null,vector dx=null){
	    if(dx == null) dx = x.map(xi => Abs(xi)*Pow(2,-26));
	    if(fx == null) fx = f(x);
	    matrix J=new matrix(x.size);
	    for(int j=0;j < x.size;j++){
		    x[j]+=dx[j];
		    vector df=f(x)-fx;
		    for(int i=0;i < x.size;i++) {J[i,j]=df[i]/dx[j];}
		    x[j]-=dx[j];
		}
	    return J;
    }//jacobian



    public static (vector, double) Newton(
        Func<vector,vector> f,
        vector start, 
        double epsilon=1e-10){
        
        vector x = start.copy();
        int dim = x.size;
        vector fx=f(x),z,fz;
        double count = 0;
        while(true){

            if(fx.norm() < epsilon) break;
            count += 1;
            if(count>1000) break;
            ///////////  Calculating the Jacobian matrix /////////////
            matrix J = new matrix(dim);
            J = jacobian(f,x,fx);

            // First we decompose J and then we solve:
            matrix Q;
            matrix R; 
            (Q,R) = QRGS.decomp(J);
            vector delta_x = QRGS.solve(Q,R,-fx);

            double lambda = 1;

            while( true){
                z = x + lambda*delta_x;
                fz = f(z);
                if (fz.norm() < (1-lambda/2)*fx.norm()) break;
                if (lambda<1/64) break;

                lambda = lambda* 1/2;
            }

            x = z;
            fx = fz;
        }

        return (x ,count);

    }//Newton


}//roots

