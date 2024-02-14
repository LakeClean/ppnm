class main{
public static int Main(){
    genlist<double> list = new genlist<double>();
    list.add(1.2);
    list.add(2.0);
    for(int i=0;i<list.size;i+=1)System.Console.WriteLine(list[i]);

    double a=7,x=10;
    System.Func<double,double> f = delegate(double x){return 1;};
    
    System.Console.WriteLine($"{f(x)}");

    var flist = new genlist<System.Func<double,double>>();
    flist.add(f);
    flist.add(System.Math.Sin);
    flist.add(System.Math.Cos);



    return 0;
    }
}
