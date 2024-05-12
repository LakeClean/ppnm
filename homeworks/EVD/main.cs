class main{
	public static void Main(){

		int n = 2;
		matrix A = new matrix(n,n);
		matrix.random(A);
		A.print("Original matrix A:");
		vector w;
		matrix V;
		(w,V) = jacobi.cyclic(A);

		V.print("The ortognal matrix of eigenvectors V:");
		matrix V_T = V.transpose();
		V_T.print("V transposed:");


		matrix V_TAV = V_T * A * V;
		V_TAV.print("V_Transposed * A * V = D:");

		matrix V_TV = V_T*V;
		V_TV.print();

		matrix VV_T = V*V_T;
		VV_T.print();
	}//Main
}//main
