class main{
static void Main(){

//Section A:	
	if (false){
	// Generating tall random matrix:

	matrix A = new matrix(10,2);
	matrix.random(A);
	A.print("Originale matrix A:");


	//Factorizing into QR:
	matrix Q;
	matrix R;
	(Q,R) = matrix.decomp(A);
	Q.print("Q:");
	R.print("R:");
	matrix Q_transpose = Q.transpose();

	matrix iden = Q*Q_transpose;

	iden.print("Identity matrix:");

	matrix QR = Q*R;

	QR.print("Q*R:");

	matrix QR_A = QR - A;

	QR_A.print("QR-A:");
	}

	
	if (false){
	// Generating square Matrix:
	int sq_size = 10;
	matrix A = new matrix(sq_size,sq_size);
	matrix.random(A);
	A.print("Originale matrix A:");


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

	vector test = Q*R*x;
	test.print("Checking QRx=b:");

	}



// Section B:
	if (false){
	int sq_size = 10;
	matrix A = new matrix(sq_size,sq_size);
	matrix.random(A);
	A.print("Originale matrix A:");

	matrix Q;
	matrix R;
	(Q,R) = QRGS.decomp(A);

	matrix B = QRGS.inverse(Q,R);

	B.print();


	matrix iden = A*B;
	iden.print();
	}
	
	
}
}
