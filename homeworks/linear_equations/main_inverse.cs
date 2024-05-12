using static System.Console;
class main{
	static void Main(){

		WriteLine("#################### TASK B: Inverse #########################");

		int sq_size = 5;
		matrix A = new matrix(sq_size,sq_size);
		matrix.random(A);
		A.print("Original matrix A:");

		matrix Q;
		matrix R;
		(Q,R) = QRGS.decomp(A);

		matrix B = QRGS.inverse(Q,R);

		B.print("The inverse matrix B: ");


		matrix iden = A*B;
		iden.print("Checking that A*B=1: A*B =");
	
	
	}
}
