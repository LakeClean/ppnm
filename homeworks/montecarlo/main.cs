using static System.Console;
using static System.Math;
public static class main{

    public static double circle(vector a){
        return a[0];
    }//circle

    public static double semi_circle_with_hole(vector a){

        return (3 * a[0]*Cos(a[1])+4*a[0]*a[0]*Sin(a[1])*Sin(a[1]))*a[0];
    }//semi_circle_with_hole

    public static double threeD_parabola(vector a){
        return a[0]*a[1] + a[2]*a[1];
    }//threeD_parabola

    public static double difficult_singular_integral(vector a){
        return 1/((1-Cos(a[0])*Cos(a[1])*Cos(a[2]))*(PI*PI*PI));
    }

    public static void Main(){
        double end = PI;
        vector a = new vector("0 0 0");
        vector b = new vector($"{PI} {PI} {PI}");
        //var result = monte_carlo.plain(circle,a,b,100000);
        //WriteLine(PI);
        //WriteLine(PI*15/2 );
        WriteLine(1.3932039296856768591842462603255);
        var result = monte_carlo.plain(difficult_singular_integral,a,b,1000000);
        WriteLine(result);
        
    }//Main
}//main