using System;
using static System.Math;
public class monte_carlo{


    
    public static (double, double) plain(Func<vector,double> f,vector a,vector b,int N ){
        double V = 1;
        int dimension = a.size;
        for(int i=0; i<dimension; i++){
            V *= b[i] - a[i];
        }

        double sum1 = 0;
        double sum2 = 0;

        for(int i=0; i<N; i++){
            //Creating a random point p_i 
            vector p_i = new vector(dimension);
            var rnd = new System.Random();
            for(int j=0; j<p_i.size; j++) p_i[j]= a[j] + rnd.NextDouble()*(b[j]-a[j]);

            double f_i = f(p_i);
            sum1 += f_i;
            sum2 += f_i*f_i;
        }
        double Q = V * sum1/N;
        double var = sum2/N - sum1/N/N;
        double error = V * Sqrt(var/N);

        return (Q,error);

    }//plain


}//monte_carlo