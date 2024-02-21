using static System.Console;
class main{
	public static int Main(){
		for(double x=-3; x<=3;x+=0.125){
			WriteLine($"{x} {sfuns.erf(x)}");
		}
	return 0;
	}//Main

}//main
