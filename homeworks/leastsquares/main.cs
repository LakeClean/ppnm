using static System.Console;
using static System.Math;
using System;
public static class main{

    public static void Main(){
        WriteLine("hello");
        vector t = new vector("1 2 3 4 6 9 10 13 15");
        vector y = new vector("117 100 88 72 53 29.5 25.2 15.2 11.1");
        for(int i=0;i<y.size; i++){
            y[i] = Log(y[i]);
        }
        vector dy = new vector("6 5 4 4 4 3 3 2 2");

        Func<double,double>[] fs = {z => 1 , z => z};
        /*
        vector result = least_squares.lsfit(fs, t, y, dy);
        */
        int n = t.size;
        int m = fs.Length;

        matrix A = new matrix(n,m);
        vector b = new vector(n);

        for(int i=0; i<n;i++){
            b[i] = y[i] / dy[i];
            for(int k=0; k<m; k++){
                A[i,k] = fs[k](t[i])/ dy[i];
            }
        }
        matrix R, Q;

        (Q,R) = QRGS.decomp(A);

        WriteLine(Q.size1);
        WriteLine(Q.size2);
        WriteLine(R.size1);
        WriteLine(R.size2);
        WriteLine(b.size);
        R.print();
        //vector c = QRGS.solve(Q,R,b);

    }
}