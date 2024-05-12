// (C) 2020 Dmitri Fedorov; License: GNU GPL v3+; no warranty.

using System;
using static System.Math;
using System.Runtime.CompilerServices;
public partial class matrix{

public readonly int size1, size2;
public double[][] data;

public matrix(int n, int m){
	size1=n; size2=m; data = new double[size2][];
	for(int j=0;j<size2;j++) data[j]=new double[size1];
	}
public matrix(int n) : this(n,n) {}

public double this[int r,int c]{
[MethodImpl(MethodImplOptions.AggressiveInlining)]
	get{return data[c][r];}
[MethodImpl(MethodImplOptions.AggressiveInlining)]
	set{data[c][r]=value;}
	}

public vector this[int c]{
	get{return (vector)data[c];}
	set{data[c]=(double[])value;}
	}

public matrix(string s){
        string[] rows = s.Split(';');
        size1 = rows.Length;
	char[] delimiters = {',',' '};
        var options = StringSplitOptions.RemoveEmptyEntries;
        size2 = rows[0].Split(delimiters,options).Length;
        data = new double[size2][];
	for(int j=0;j<size2;j++) data[j]=new double[size1];
        for(int i=0;i<size1;i++){
                string[] ws = rows[i].Split(delimiters,options);
                for(int j=0; j<size2; j++){
                        this[i,j]=double.Parse(ws[j]);
                        }
                }
        }

public static matrix operator+ (matrix a, matrix b){
	matrix c = new matrix(a.size1,a.size2);
	for(int j=0;j<a.size2;j++)
		for(int i=0;i<a.size1;i++)
			c[i,j]=a[i,j]+b[i,j];
	return c;
	}

public static matrix operator-(matrix a){
	matrix c = new matrix(a.size1,a.size2);
	for(int j=0;j<a.size2;j++)
		for(int i=0;i<a.size1;i++)
			c[i,j]=-a[i,j];
	return c;
	}

public static matrix operator-(matrix a, matrix b){
	matrix c = new matrix(a.size1,a.size2);
	for(int j=0;j<a.size2;j++)
		for(int i=0;i<a.size1;i++)
			c[i,j]=a[i,j]-b[i,j];
	return c;
	}

public static matrix operator/(matrix a, double x){
	matrix c=new matrix(a.size1,a.size2);
	for(int j=0;j<a.size2;j++)
		for(int i=0;i<a.size1;i++)
			c[i,j]=a[i,j]/x;
	return c;
}

public static matrix operator*(double x, matrix a){ return a*x; }
public static matrix operator*(matrix a, double x){
	matrix c=new matrix(a.size1,a.size2);
	for(int j=0;j<a.size2;j++)
		for(int i=0;i<a.size1;i++)
			c[i,j]=a[i,j]*x;
	return c;
}

public static matrix operator* (matrix a, matrix b){
        var c = new matrix(a.size1,b.size2);
        for (int k=0;k<a.size2;k++)
        for (int j=0;j<b.size2;j++)
		{
                double bkj=b[k,j];
                var cj=c.data[j];
                var ak=a.data[k];
		int n=a.size1;
                for (int i=0;i<n;i++){
                        //c[i,j]+=a[i,k]*b[k,j];
                      cj[i]+=ak[i]*bkj;
                	}
        	}
        return c;
        }

public static vector operator* (matrix a, vector v){
	var u = new vector(a.size1);
	for(int k=0;k<a.size2;k++)
	for(int i=0;i<a.size1;i++)
		u[i]+=a[i,k]*v[k];
	return u;
	}

public static vector operator% (matrix a, vector v){
	var u = new vector(a.size2);
	for(int k=0;k<a.size1;k++)
	for(int i=0;i<a.size2;i++)
		u[i]+=a[k,i]*v[k];
	return u;
	}

public matrix(vector e) : this(e.size,e.size) { for(int i=0;i<e.size;i++)this[i,i]=e[i]; }

public void set(int r, int c, double value){ this[r,c]=value; }
public static void set(matrix A, int i, int j, double value){ A[i,j]=value; }
public double get(int i, int j){ return this[i,j]; }
public static double get(matrix A, int i, int j){ return A[i,j]; }

public matrix rows(int a, int b){
  matrix m = new matrix(b-a+1,size2);
  for(int i=0;i<m.size1;i++)
	for(int j=0;j<m.size2;j++)
    		m[i,j]=this[i+a,j];
  return m;
}

public matrix cols(int a, int b){
  matrix m = new matrix(size1,b-a+1);
  for(int i=0;i<m.size1;i++)for(int j=0;j<m.size2;j++)
    m[i,j]=this[i,j+a];
  return m;
  }

public static matrix id(int n){
	var m = new matrix(n,n);
	for(int i=0;i<n;i++)m[i,i]=1;
	return m;
	}

public void set_identity(){ this.set_unity(); }
public void set_unity(){
	for(int i=0;i<size1;i++){
		this[i,i]=1;
		for(int j=i+1;j<size2;j++){
			this[i,j]=0;this[j,i]=0;
		}
	}
}
public void setid(){
	for(int i=0;i<size1;i++){
		this[i,i]=1;
		for(int j=i+1;j<size2;j++){ this[i,j]=0;this[j,i]=0; }
	}
	}

public void set_zero(){
	for(int j=0;j<size2;j++)
		for(int i=0;i<size1;i++)
			this[i,j]=0;
	}

public static matrix outer(vector u, vector v){
	matrix c = new matrix(u.size,v.size);
	for(int i=0;i<c.size1;i++)for(int j=0;j<c.size2;j++) c[i,j]=u[i]*v[j];
	return c;
}

public void update(vector u, vector v, double s=1){
	for(int i=0;i<size1;i++)
	for(int j=0;j<size2;j++)
		this[i,j]+=u[i]*v[j]*s;
	}

public matrix copy(){
	matrix c = new matrix(size1,size2);
	for(int j=0;j<size2;j++)
		for(int i=0;i<size1;i++)
			c[i,j]=this[i,j];
	return c;
	}


public matrix T{
		get{return this.transpose();}
		set{}
}

public matrix submatrix(int ia, int ib, int ja, int jb){
	matrix m = new matrix(ib-ia+1,jb-ja+1);
	for(int i=ia;i<=ib;i++)
	for(int j=ja;j<=jb;j++) m[i-ia,j-ja]=this[i,j];
	return m;
}

public matrix transpose(){
	matrix c = new matrix(size2,size1);
	for(int j=0;j<size2;j++)
		for(int i=0;i<size1;i++)
			c[j,i]=this[i,j];
	return c;
	}

public static void scale(matrix M,double x){
	for(int j=0;j<M.size2;j++)
	for(int i=0;i<M.size1;i++)
		M[i,j]*=x;
	}

public void print(string s="",string format="{0,10:g3} "){
	System.Console.WriteLine(s);
	for(int ir=0;ir<this.size1;ir++){
	for(int ic=0;ic<this.size2;ic++)
		System.Console.Write(format,this[ir,ic]);
		System.Console.WriteLine();
		}
	}

public static bool approx(double a, double b, double acc=1e-6, double eps=1e-6){
	if(Abs(a-b)<acc)return true;
	if(Abs(a-b)/Max(Abs(a),Abs(b)) < eps)return true;
	return false;
}

public bool approx(matrix B,double acc=1e-6, double eps=1e-6){
	if(this.size1!=B.size1)return false;
	if(this.size2!=B.size2)return false;
	for(int i=0;i<size1;i++)
		for(int j=0;j<size2;j++)
			if(!approx(this[i,j],B[i,j],acc,eps))
				return false;
	return true;
}


//////////////////////////// My implementations ///////////////////////////

//Solving upper triangular matrix by backsubstitution
	public static void solve_upper_triangular(matrix U , vector c){
		for (int i=c.size-1; i>=0; i--){
			double sum = 0;
			for (int k=i+1;k<c.size; k++){
				sum += U[i,k]*c[k];
			}
			c[i] = 1/U[i,i] * (c[i] - sum);
		}
	}//solve_upper_triangular


// Modify matrix to be random or a random symmetric (Needs to be square already)
	public static void random(matrix A,string s = "random"){
		var rnd = new System.Random();
		for(int i= 0;i<A.size1;i++){
			for(int j= 0;j<A.size2;j++){
				if (s=="random"){
					A[i,j] = rnd.Next(101);
				}
				else if (s="symmetric"){
					int temp = rnd.Next(101);
					A[i,j] = temp;
					A[j,i] = temp;
				}
				
			}
		}
	}//random


// Methods for EVD

	public static void timesJ(matrix A, intp, int q, double theta){
		double c = Cos(theta), s = Sin(theta);
		for(int i=0,i<A.size;i++){
			double aip=A[i,p],aiq=A[i,q];
			A[i,p]=c*aip-s*aiq;
			A[i,q]=s*aip+c*aiq;
		}

	}

	public static void Jtimes(matrix A, int p, int q, double theta){
	double c=Cos(theta),s=Sin(theta);
	for(int j=0;j<A.size1;j++){
		double apj=A[p,j],aqj=A[q,j];
		A[p,j]= c*apj+s*aqj;
		A[q,j]=-s*apj+c*aqj;
		}
}

// function for diagonalizing symmetric matrix
	public static void cyclic(matrix A){
		//we set criterion to be; no change in diagonal elements
		for(int p=0; p<A.size;p++){
			for(int q=p+1; q<A.size;q++){
			double apq=A[p,q], app=A[p,p], aqq=[q,q];
			double theta = 0.5*Atan2(2*apq,aqq-app);
			double c = Cos(theta), s = Sin(theta);
			double new_app = Exp(c,2)*app - 2*s*c*apq + Exp(s,2)*aqq;
			double new_aqq = Exp(s,2)*app + 2*s*c*apq + Exp(c,2)*aqq;
			if(new_app != app){
				timesJ(A,p,q,theta);
				Jtimes(A,p,q,-theta);
			}
			else if(new_aqq != aqq){
				timesJ(A,p,q,theta);
				Jtimes(A,p,q,-theta);
			}

			else {
				break;
			}



			}
		}
	}

}//matrix
