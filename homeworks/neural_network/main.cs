using System;
using static System.Console;
using static System.Math;
using System.IO;
using static System.Random;
//using linalg;
//using calculus;
public static class main{


    public static void Main(){


    vector x = new vector(50);
    vector y = new vector(50);
    double k = -0.9;
    for(int i = 0; i<x.size;i++){
        x[i] = k;
        y[i] = Cos(5*k-1)*Exp(-k*k);
        //y[i] = Cos(k);
        k += 0.04;
    }
    var ann3 = new ann(3);
    ann3.train(x,y);
    vector parameters = ann3.get_params();

    k = -0.8; // Starting from a different point than trainging data.
    for(int i = 0; i<x.size;i++){
        double value = ann3.predict(k);
        WriteLine($"{k} {Cos(5*k-1)*Exp(-k*k)} {value}");
        k += 0.04;

    }

    /*
    var ann3 = new ann(3);
    ann3.fit(x,y);
    vector parameters = ann3.get_params();
    //parameters.print();

    
    for(int i = 0; i<x.size;i++){
        double value = ann3.predict(x[i]);
        WriteLine($"{x[i]} {y[i]} {value}");
    }
    */
        
        

        
        
    }//Main
}//main