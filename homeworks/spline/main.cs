using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        
        double[] test_x = new double[10];
        double[] test_y = new double[10];
        for (int i=0;i<test_x.Length;i++){
            test_x[i]=i;
            test_y[i]=Sin(i);
            WriteLine($"{test_x[i]},{test_y[i]}");
        }
        double z = 7.5;

        double z_y = spline.linenterp(test_x, test_y, z);

        WriteLine($"{z},{z_y}");


//linenterp
    }//Main

    

}//main