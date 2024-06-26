
using static System.Math;

public static class jacobi{

    public static void timesJ(matrix A, int p, int q, double theta){
        double c = Cos(theta), s = Sin(theta);
		for(int i=0;i<A.size1;i++){
			double aip=A[i,p],aiq=A[i,q];
			A[i,p]=c*aip-s*aiq;
			A[i,q]=s*aip+c*aiq;
        }
    }//timesJ

    public static void Jtimes(matrix A, int p, int q, double theta){
        double c=Cos(theta),s=Sin(theta);
	    for(int j=0;j<A.size1;j++){
		    double apj=A[p,j],aqj=A[q,j];
		    A[p,j]= c*apj+s*aqj;
		    A[q,j]=-s*apj+c*aqj;
		}
    }//Jtimes


    public static (vector,matrix) cyclic(matrix M){
        matrix A=M.copy();
        matrix V=matrix.id(M.size1);
        vector w=new vector(M.size1);
        /* run Jacobi rotations on A and update V */
        /* copy diagonal elements into w */

        //we set criterion to be; no change in diagonal elements
        bool changed = true;
        while(changed){
        changed = false;
		for(int p=0; p<A.size1;p++){
			for(int q=p+1; q<A.size1;q++){
			    double apq=A[p,q], app=A[p,p], aqq=A[q,q];
			    double theta = 0.5*Atan2(2*apq,aqq-app);
			    double c = Cos(theta), s = Sin(theta);
			    double new_app = Pow(c,2)*app - 2*s*c*apq + Pow(s,2)*aqq;
			    double new_aqq = Pow(s,2)*app + 2*s*c*apq + Pow(c,2)*aqq;
			    if((new_app != app) || (new_aqq != aqq)){
                    changed = true;
				    timesJ(A,p,q,theta);
				    Jtimes(A,p,q,-theta);
                    timesJ(V,p,q, theta);
			    }
            }
        }}
        for(int i=0; i<A.size1; i++){w[i] = A[i,i];}
        return (w,V);

    }//cyclic  
}//jacobi
