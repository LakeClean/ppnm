using System.Linq;
class main{


	public static int Main(string[] args){
		int nterms = (int)1e7; //Default values if nothing is passed to Main
		
		foreach(string arg in args){
		var words = arg.Split(':');
		if(words[0]=="-nterms"  ) nterms  =(int)double.Parse(words[1]);
		}
		
		System.Console.Write($"Main: nterms={nterms}\n");
		var sum = new System.Threading.ThreadLocal<double>( ()=>0, trackAllValues:true);
		System.Threading.Tasks.Parallel.For( 1, nterms+1, (int i)=>sum.Value+=1.0/i );
		double totalsum=sum.Values.Sum();

		//double sum = 0;
		//System.Threading.Tasks.Parallel.For( 1, nterms+1, (int i) => sum+=1.0/i );
		
		System.Console.Write($"Total sum = {totalsum}\n");
	return 0;
	}//Main


}//main
