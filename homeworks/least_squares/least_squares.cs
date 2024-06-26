
using System;

public static class least_squares{
    public static (vector,matrix) lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
        int n = x.size, m=fs.Length;
        var A = new matrix(n,m);
        var b = new vector(n);

        for(int i=0; i<n; i++){
            b[i]=y[i]/dy[i];
            for(int k=0; k<m; k++){
                A[i,k] = fs[k](x[i])/dy[i];
            }

        }

        (matrix Q, matrix R) = QRGS.decomp(A);
        vector c =  QRGS.solve(Q,R,b);
        matrix CI = R.transpose() * R;
        matrix C = QRGS.inverse(CI);
        //matrix AI = QRGS.inverse(Q,R);
        //matrix covariance = AI*AI.transpose();


        return (c,C);
    }


}