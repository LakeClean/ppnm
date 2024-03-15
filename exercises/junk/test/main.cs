
class main{
    public static void Main(){

        ///////////////// OUTPUT ////////////////////////////
        
        double x = 1.23;

        // There are two streams. The standard output
        System.Console.Out.WriteLine($"{x}"); /* or, equivalently */
        System.Console.WriteLine($"{x}"); /* or */
        System.IO.TextWriter /* or just var */ stdout = System.Console.Out;
        stdout.WriteLine($"{x}"); /* Console.Out is a TextWriter */

        // and the error output
        System.Console.Error.WriteLine($"{x}"); /* or */
        System.IO.TextWriter /* or just var */ stderr = System.Console.Error;
        stderr.WriteLine($"{x}");

        // Then you can write directly to a file
        var outfile = new System.IO.StreamWriter("out.txt",append:true);
        outfile.WriteLine($"{x}");
        outfile.Close(); /* do not forget this! */


        ///////////////// INPUT ////////////////////////////
        

        string s;
        //s = System.Console.In.ReadLine(); /* or s = System.Console.ReadLine(); */

        //x = double.Parse(s);
        /* or */
        System.IO.TextReader /* or just var */ stdin = System.Console.In;
        s = stdin.ReadLine();
        x = double.Parse(s);
        System.Console.Out.WriteLine($"{s}");
        System.Console.Out.WriteLine($"{s}");
        System.Console.Out.WriteLine($"{s}");
        
    }
}