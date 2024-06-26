using System;
using static System.Math;
public class minimization{

    
    public static vector gradient(Func<vector,double> f,vector x){
        int dim = x.size;
        vector grad_f = new vector(dim);
        double fx = f(x);
        
        for(int i=0; i<dim; i++){
            vector temp = x.copy();
            double delta_x = Abs(x[i])*Pow(2,-26);
            temp[i] = x[i] + delta_x;
            grad_f[i] = (f(temp) - fx)/(delta_x);
        }
        return grad_f;
    }//gradient
    

    
    public static matrix Hessian(Func<vector,double> f,vector x){
        int dim = x.size;
        matrix H = new matrix(dim);
        vector grad_fx = gradient(f,x);

        for(int j=0; j<dim; j++){
            double delta_x = Abs(x[j])*Pow(2,-13);
            vector temp = x.copy();
            temp[j]+= delta_x;
            vector delta_grad_f = gradient(f,temp) - grad_fx;

            for(int i=0; i<dim; i++){
                H[i,j] = delta_grad_f[i]/delta_x;
            }
        }
        return (H+H.T)/2;

    }//Hessian
    
    
    /*
    public static vector gradient(Func<vector,double> f,vector x){
	    vector grad_f = new vector(x.size);
	    double fx = f(x); 
	    for(int i=0;i<x.size;i++){
		    double dx=Max(Abs(x[i]),1)*Pow(2,-26);
		    x[i]+=dx;
		    grad_f[i]=(f(x)-fx)/dx;
		    x[i]-=dx;
	    }
	    return grad_f;
    }*/
    
    /*
    public static matrix Hessian(Func<vector,double> f,vector x){
	matrix H=new matrix(x.size);
	vector grad_f=gradient(f,x);
	for(int j=0;j<x.size;j++){
		double dx=Max(Abs(x[j]),1)*Pow(2,-13); 
		x[j]+=dx;
		vector delta_grad_f=gradient(f,x)-grad_f;
		for(int i=0;i<x.size;i++) H[i,j]=delta_grad_f[i]/dx;
		x[j]-=dx;
	}
	//return H;
	return (H+H.T)/2; // you think?
}*/
    
    
    public static (double, vector) Newton(Func<vector,double> f,vector start, double acc=1e-3){
        vector x = start;

        // Iterative Newtons method 
        int count = 0;
        while(true){
            if(count>1000) break;
            count+=1;
            vector grad_f = gradient(f,x);
            if(grad_f.norm() < acc) break;

            matrix H = Hessian(f,x);

            // First we decompose H and then we solve:
            matrix Q;
            matrix R; 
            (Q,R) = QRGS.decomp(H);

            vector delta_x = QRGS.solve(Q,R,-grad_f);

            // linesearch
            double lambda = 1;
            double fx = f(x);

            int count2 = 0;
            while(true){
                if(count2>1000) break;
                count2+=1;
                
                if (f(x+ lambda*delta_x) < fx) break;
                if (lambda < Pow(2,-13)) break;

                lambda /= 2;
            }
            
            x += lambda*delta_x;
        }

        return (count, x);

    }//Newton
    

    /*
    public static vector Newton(
	Func<vector,double> f,
	vector x,              
	double acc=1e-3       
){
	do{ 
		var grad_f = gradient(f,x);
		if(grad_f.norm() < acc) break;
		var H = Hessian(f,x);
		matrix Q;
        matrix R; 
        (Q,R) = QRGS.decomp(H);

        vector dx = QRGS.solve(Q,R,-grad_f);


		double lambda=1,fx=f(x);
		do{ 
			if( f(x+lambda*dx) < fx ) break; 
			if( lambda < 1/1024 ) break; 
			lambda/=2;
		}while(true);
		x+=lambda*dx;
	}while(true);
	return x;
}//newton
*/
    


}//roots

