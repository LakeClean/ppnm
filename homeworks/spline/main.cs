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
            y[i]= Cos(i) + 1;
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
        
        double[] test_x = new double[10];
        double[] test_y = new double[10];
        double[] test_z = new double[10];
        for (int i=0;i<test_x.Length;i++){
            test_x[i]=i;
            test_y[i]= Cos(i);
            test_z[i] = Sin(i);
            }

        for(int i = 0; i <test_x.Length; i++){
            double k = spline.linterpInteg(test_x, test_y, i);
            WriteLine($"{test_x[i]} {test_y[i]} {test_z[i]} {k}");
        }
    }//Main

    

}//main