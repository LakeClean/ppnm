class main{

	public class harmdata {public int a,b; public double sum;}//data

	public static void harm(object obj){
		//Method that calculates the harmonic sum
		harmdata arg = (harmdata)obj;
		arg.sum=0;
		System.Console.Write($"harm: a={arg.a} b={arg.b}\n");
		for (int i =arg.a;i<=arg.b;i++){arg.sum+=1.0/i;}
		System.Console.Write($"harm: sum={arg.sum}\n");
		}//harm


	public static int Main(string[] args){
		int nterms = (int)1e8, nthreads = 1; //Default values if nothing is passed to Main
		
		foreach(string arg in args){
		var words = arg.Split(':');
		if(words[0]=="-nthreads") nthreads=(int)double.Parse(words[1]);
		if(words[0]=="-nterms"  ) nterms  =(int)double.Parse(words[1]);
		}
		System.Console.Write($"Main: nterms={nterms} nthreads={nthreads}\n");
		harmdata[] data = new harmdata[nthreads]; // Notice params is a keyword
		int chunk = nterms/nthreads;
		for (int i=0; i<nthreads;i++){
			data[i] = new harmdata();
			data[i].a = i*chunk+1;
			data[i].b = data[i].a + chunk;
		}
		
		data[nthreads-1].b=nterms; // considering that nterms/nthreads might be odd and so rounded
		
		var threads = new System.Threading.Thread[nthreads];
		for (int i=0; i<nthreads; i++) {
			threads[i] = new System.Threading.Thread(harm); //creating thread
			threads[i].Start(data[i]); // Starting thread
		}

		foreach(var thread in threads)thread.Join();
		double total=0;
		foreach(harmdata p in data) total+=p.sum;
		System.Console.Write($"Total sum = {total}\n");
	return 0;
	}//Main


}//main
