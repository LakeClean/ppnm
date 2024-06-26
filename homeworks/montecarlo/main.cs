using static System.Console;
using static System.Math;
public static class main{

    public static double circle(vector a){
        return a[0];
    }//circle

    public static double sphere_surface(vector a){
        return Sin(a[0]); //Surface of unit sphere
    }//sphere_surface 


    public static double difficult_singular_integral(vector a){
        return 1/((1-Cos(a[0])*Cos(a[1])*Cos(a[2]))*(PI*PI*PI));
    }

    public static void Main(){
        // We try to calculate the difficult integral: as defined
        vector a = new vector("0 0 0");
        vector b = new vector($"{PI} {PI} {PI}");
        (double x, double y) = monte_carlo.plain(difficult_singular_integral,a,b,1000000);
        WriteLine("Calculating the difficult singular integral gives:");
        WriteLine($"value: {x}");
        WriteLine($"Correct value is: {1.3932039296856768591842462603255}");
        WriteLine($"Estimated error is: {y}");
        WriteLine($"Actual error is: {Abs(x-1.3932039296856768591842462603255)}");

        // Writing out circle:
        string outfile_circle = "out_circle.txt";
        var outstream_circle=new System.IO.StreamWriter(outfile_circle,append:false);

        for(int N = 0; N<20000; N+=100 ){
            (double result, double error) = monte_carlo.plain(circle,new vector("0 0"),new vector($"{1} {2*PI}"),N);
            outstream_circle.WriteLine($"{N} {result} {Abs(result-PI)} {error} {1/Sqrt(N)}");
        }
        outstream_circle.Close();

        // Writing out surface of sphere:
        string outfile_sphere = "out_sphere.txt";
        var outstream_sphere=new System.IO.StreamWriter(outfile_sphere,append:false);

        for(int N = 0; N<20000; N+=100){
            (double result, double error) = monte_carlo.plain(sphere_surface,new vector("0 0"),new vector($"{PI} {2*PI}"),N);
            outstream_sphere.WriteLine($"{N} {result} {Abs(result-4*PI)} {error} {1/Sqrt(N)}");
            }
        outstream_sphere.Close();

        }//Main

}//main