using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        // Defining cosine data and writing it to out_cosine.txt:
        string outfile_cos = "out_cosine.txt";
        var outstream_cos=new System.IO.StreamWriter(outfile_cos, append:false);
        double[] x = new double[10];
        double[] y = new double[10];
        for (int i=0;i<x.Length;i++){
            x[i]=i;
            y[i]= Cos(i);
            outstream_cos.WriteLine($"{i} {y[i]}");

            }
        outstream_cos.Close();


        //Writing interpolation to out_cosine_interpolation.txt:
        string outfile_interpolation = "out_cosine_interpolation.txt";
        var outstream_interpolation=new System.IO.StreamWriter(outfile_interpolation,append:false);

        for(double i = 0; i<9; i+=0.1 ){
            outstream_interpolation.WriteLine($"{i} {spline.linenterp(x,y,i)} {spline.linterpInteg(x, y, i)}");
        }
        outstream_interpolation.Close();


        // Testing quadratic spline:
        for (int i=0;i<x.Length;i++){
            x[i]=i;
            y[i]= Sin(i);
        }
        spline.qspline abc = new spline.qspline(x,y);
        

    }//Main

    

}//main