using static System.Console;
using static System.Math;
public static class main{

    public static vector linear(vector x){
        double a = 10;
        vector b =  new vector(1);
        b[0] = -30;
        return a*x + b;
    }

    public static vector second_order_pol(vector v){
        double x = v[0];
        double a = 10;
        double b = 1;
        double c = -1;
        v[0] = a*x*x + b*x + c;
        return v;
    }

    public static vector Rosenbrock_valley(vector v){
        vector w = v.copy();
        double x = w[0];
        double y = w[1];

        v[0] = 2*(-1 + x + 200*x*x*x -200*x*y);
        v[1] = 200*(y-x*x);
        return v;
    }


    public static void Main(){
        

        vector result;
        vector temp = new vector("0.1");
        temp.print();
        result  = roots.Newton(second_order_pol,  temp);
        result.print();
        
    }//Main
}//main