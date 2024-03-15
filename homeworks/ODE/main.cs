using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
class main{

public static void Main(){


	//Defining a pendulum: u'' = -K*u
	double K = 50; // Force konstant of restoring force
	Func<double,vector,vector> pend = delegate(double t,vector y){
		double theta = y[0];
        double omega = y[1];
		return new vector(omega, -K*theta); //-b*omega - c*Sin(theta)
	}; // pend

	//Defining equatorial orbit:
	double epsilon=0.00;
	Func<double,vector,vector> orbit = delegate(double t, vector y){
		double theta = y[0];
		double omega = y[1];
		return new vector(omega, 1-theta+epsilon*theta*theta);
	}; //orbit

	//Defining planar multi body:
	Func<double,vector,vector> multi_body = delegate(double t, vector z){
		// Expecting z to be on the form: z = {x'1, y'1, x'2, y'2, x'3, y'3, x1, y1, x2, y2, x3, y3}
		string output = "";

		for(int i = z.size/2; i<z.size; i+=2){
			double x_i = z[i];
			double y_i = z[i+1];
			double z_diff_x = 0;
			double z_diff_y = 0;

			for(int j=z.size/2; j<z.size; j+=2){
				if(i != j){
					double x_j = z[j];
					double y_j = z[j+1];
					double norm = Sqrt(Pow((x_j -x_i),2) + Pow((y_j -y_i),2));

					z_diff_x += (x_j - x_i)/norm;
					z_diff_y += (y_j - y_i)/norm;
				};
			}
			output += $"{z_diff_x} {z_diff_y} ";
		}

		for(int i = 0; i<z.size/2; i++){
			output += $"{z[i]} ";
		}
		return new vector(output); //new vector(output);
	}; // multi_body
	
	
	/*
	//Initial values of pendulum
	double start=0, stop=10;
	vector ystart = new vector(PI-0.1,0.0);
	*/
	
	//Initial values of orbit
	/*
	double start=0;
	double stop=10;
	vector ystart = new vector(1,0);
	*/

	//Initial values of three body 8-figure:
	double start = 0;
	double stop = 10;
	vector ystart = new vector(1,0);
	vector test = new vector(0,0,0,0,0.3471128135672417,0.532726851767674, -1, 0, 0,0, 1,0);


	//Solving ODE
	var (xlist,ylist) = ODE_solver.driver(multi_body,(start,stop),test);

	//Printing each step
	for(int i=0;i<xlist.size;i++){
		WriteLine($"{xlist[i]} {ylist[i][0]} {ylist[i][1]}");
		}
    


	}//Main

}//main










/*

			for(int j=z.size/2; i<z.size; j+=2){
				if(i != j){
					WriteLine(i);
					WriteLine(j);
					
					double x_j = z[j];
					double y_j = z[j+1];
					double norm = Sqrt(Pow((x_j -x_i),2) + Pow((y_j -y_i),2));

					z_diff_x += (x_j - x_i)/norm;
					z_diff_y += (y_j - y_i)/norm;
					


				};
				}

*/
