using static System.Console;
using System;
using static System.Math;
public static class main{


    public static void Main(){

    // Importing tabulated function:
    string infile = "input.txt";
    var instream = new System.IO.StreamReader(infile);
    int index = 0;
    vector x = new vector(39);
    vector y = new vector(39);
    for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
        var value = line.Split(" ");
        x[index] = double.Parse(value[0]);
        y[index] = double.Parse(value[1]);
        index += 1;
    }

    instream.Close();


    vector result = ann.train(x,y);
    
    for(int i=0; i<x.size; i+= 1){
        double g = Cos(5*x[i]-1)*Exp(-x[i]*x[i]);
        double value = ann.response(x[i],result);
        WriteLine($"{g} {value} {y[i]}");
    }
        
        

        
        
    }//Main
}//main