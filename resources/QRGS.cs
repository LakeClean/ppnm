
public static class QRGS{

   //Decomposing A into orthogonal Q and upper/right R
   public static (matrix,matrix) decomp(matrix A){
      matrix Q = A.copy();
		int m = A.size2;
		matrix R = new matrix(m,m);
      
		for(int i=0; i<m;i++){
			R[i,i]=Q[i].norm();
			Q[i]/=R[i,i];
			for(int j=i+1;j<m;j++){
				R[i,j]=Q[i].dot(Q[j]);
				Q[j]-=Q[i] * R[i,j] ;
			}
		}
   return (Q,R);
   }


   //Solving upper triangular matrix by backsubstitution for QRx=b
   public static vector solve(matrix Q, matrix R, vector b){
      
         vector c = Q.transpose()*b; 
			for (int i=c.size-1; i>=0; i--){
			   double sum = 0;
			   for (int k=i+1;k<c.size; k++){
				   sum += R[i,k]*c[k];
			   }
			   c[i] = (c[i] - sum)/R[i,i];
		   }
      return c;
	}//solve

   //Finding the determinant for matrix R. (product of the diagonals)
   public static double det(matrix R){
      double sum = 0;
      for(int i=0; i<R.size1;i++){
         sum*=R[i,i];
      }
   return sum;
   }


   //Finding inverse of the square matrix A = QR:
   public static matrix inverse(matrix A){
      (matrix Q, matrix R) = decomp(A);
      int n = Q.size1;

      matrix inverse_A = new matrix(n,n);
      for(int i=0; i<n; i++){
         vector e = vector.unit_vector(n,i);
         vector x  = solve(Q,R,e);

         for(int j=0; j<n; j++){
            inverse_A[j,i] = x[j];
         }

      }
   return inverse_A;
   }
} //QRGS
