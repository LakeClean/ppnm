using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;
class main{

public static void print_to_file(string outfile, genlist<double> x_data, genlist<vector> y_data){
		//string outfile = "outfile.txt";
        var outstream=new System.IO.StreamWriter(outfile,append:false);

        for(int i = 0;i<x_data.size;i+=1){
			string line = $"{x_data[i] } ";
			for(int j= 0; j<y_data[i].size; j++){line += $"{y_data[i][j]} ";}
            outstream.WriteLine(line);
        }
        outstream.Close();
}

public static void Main(){




	//Defining a pendulum: u'' = -K*u
	double K = 50; // Force konstant of restoring force
	Func<double,vector,vector> pend = delegate(double t,vector y){
		double theta = y[0];
        double omega = y[1];
		return new vector(omega, -K*theta); //-b*omega - c*Sin(theta) [Returns veloc, accel.]
	}; // pend

	//Defining a pendulum with friction: theta''(t) + b*theta'(t) + c*sin(theta(t)) = 0
	Func<double,vector,vector> pend_friction = delegate(double t,vector y){
		double theta = y[0];
        double omega = y[1];
		return new vector(omega, -0.25*omega - 5*Sin(theta)); //-b*omega - c*Sin(theta)
	}; // pend

	//Defining equatorial orbit: u''(theta) + u(theta) = 1
	Func<double,vector,vector> orbit = delegate(double t, vector y){
		double dy0 = y[1];
		double dy1 = 1-y[0];
		return new vector(dy0, dy1);
	}; //orbit

	//Defining equatorial orbit with precession: u''(theta) + u(theta) = 1 + eps * u(theta)**2 ,
	double epsilon=0.01;
	Func<double,vector,vector> precession = delegate(double t, vector y){
		double dy0 = y[1];
		double dy1 = 1-y[0]+ epsilon*y[0]*y[0];
		return new vector(dy0, dy1);
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
	
	
	
	//Initial values of pendulum
	double start=0, stop=10;
	vector ystart = new vector(PI-0.1,0.0);
	var (xlist,ylist) = ODE_solver.driver(pend,(start,stop),ystart);
	print_to_file("pendulum.txt", xlist, ylist);

	//Pendulum with friction
	(xlist,ylist) = ODE_solver.driver(pend_friction,(start,stop),ystart, 0.125, 0.00001, 0.000001, 999);
	print_to_file("pendulum_friction.txt", xlist, ylist);
	
	//Initial values of orbit
	ystart = new vector(1,-0.5);
	(xlist,ylist) = ODE_solver.driver(orbit,(0,2*PI),ystart, 0.125, 1e-5, 1e-5, 999);
	print_to_file("orbit.txt", xlist, ylist);

	//Precession of orbit:
	(xlist,ylist) = ODE_solver.driver(precession,(0,12*PI),ystart, 0.125, 1e-5, 1e-5, 999);
	print_to_file("precession.txt", xlist, ylist);
	

	//Initial values of three body 8-figure:
	start = 0;
	stop = 10;
	ystart = new vector(0.4662036850, 0.4323657300, -0.93240737, -0.86473146, 0.4662036850, 0.4323657300,-0.97000436, 0.24308753, 0 ,0, 0.97000436, -0.24308753 );
	//Solving ODE
	(xlist,ylist) = ODE_solver.driver(multi_body,(start,stop),ystart, 0.0125, 1e-5, 1e-5, 999);
	print_to_file("multibody_8figure.txt", xlist, ylist);


	}//Main

}//main












	// Other interesting orbits:
	/*
	vx = 0.2554309326049807,
	vy = 0.516385834327506.

	vx = 0.464445237398184,
	vy = 0.396059973403921.

	vx = 0.513938054919243,
	vy = 0.304736003875733.

	vx = 0.0833000564575194,
	vy = 0.127889282226563.
	*/
