class main{
	public static void Main(){
		int n = 3;
		matrix A = new matrix(n);

		matrix.random(A,"symmetric");
		A.print("Original matrix A:");
		
		(vector w, matrix V) = jacobi.cyclic(A);

		w.print("Vector of eigenvalues w: ");
		V.print("The ortognal matrix of eigenvectors V:");
		matrix V_T = V.transpose();


		matrix V_TAV = V_T * A * V;
		V_TAV.print("V_T * A * V = D:");

		matrix D = new matrix(A.size1);
		for(int i=0; i<A.size1; i++){D[i,i] = w[i];}
		matrix VDV_T = V * D * V_T;
		VDV_T.print("V * D * V_T = A:");

		matrix V_TV = V_T*V;
		V_TV.print("V *V_T =");

		matrix VV_T = V*V_T;
		VV_T.print("V_T *V =");
		
	}//Main
}//main
