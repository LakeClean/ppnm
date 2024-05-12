using static System.Console;
class main{
    static void Main(){
    WriteLine("#################### TASK A: QR decomposition #########################");
    

	// Generating tall random matrix:
	matrix A = new matrix(10,2);
	matrix.random(A);
	A.print("Original matrix A:");

	//Factorizing into QR:
	matrix Q;
	matrix R;
	(Q,R) = matrix.decomp(A);
	Q.print("Q:");
	R.print("R:");
	matrix Q_transpose = Q.transpose();

	matrix iden = Q_transpose*Q;

	iden.print("Identity matrix:");

	matrix QR = Q*R;

	QR.print("Q*R:");

	matrix QR_A = QR - A;

	QR_A.print("QR-A:");
	

	
	
    }//Main
}//main
