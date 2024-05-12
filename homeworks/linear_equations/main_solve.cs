using System;
using static System.Math;
using static System.Console;
class main{
    static void Main(){
    WriteLine("#################### TASK A: solve decomposition #########################");
	// Generating square Matrix:
	
	int sq_size = 5;
	matrix A = new matrix(sq_size,sq_size);
	matrix.random(A);
	A.print("Original matrix A:");


	vector b = new vector(sq_size);
	vector.random(b);
	b.print("vector b:");

	matrix Q;
	matrix R;
	(Q,R) = QRGS.decomp(A);
	R.print("R:");
	Q.print("Q:");
	matrix QR = Q*R;
	QR.print("Q*R:");
	//Solving QRx=b:

	vector x = QRGS.solve(Q,R,b);
	x.print("Solution x:");

	vector test = Q*R*x - b;
	test.print("Checking QRx - b = 0: QRx - b = ");
	/*
	vector t = new vector("1 2 3 4 6 9 10 13 15");
        vector y = new vector("117 100 88 72 53 29.5 25.2 15.2 11.1");
        for(int i=0;i<y.size; i++){
            y[i] = Log(y[i]);
        }
        vector dy = new vector("6 5 4 4 4 3 3 2 2");

        Func<double,double>[] fs = {z => 1 , z => z};

        //vector result = least_squares.lsfit(fs, t, y, dy);

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
	A.print("A:");
	Q.print("Q:");
	R.print("R:");
	b.print("b:");
	//vector c = QRGS.solve(Q,R,b);
	*/
	
	
    }
}
