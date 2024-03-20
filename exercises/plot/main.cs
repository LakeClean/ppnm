using static System.Console;
using static System.Math;
using System;
class main{
        public static int Main(){

                // Outputting to out_erf.txt:
                string outfile="out_erf.txt";
                var outstream=new System.IO.StreamWriter(outfile,append:false);

                for(double x = 0; x<3.6; x+=0.02){
                        outstream.WriteLine($"{x} {sfuns.erf(x)}");
                                }
                outstream.Close();


                // Outputting to out_gamma.txt:
                outfile="out_gamma.txt";
                outstream=new System.IO.StreamWriter(outfile,append:false);

                for(double x = -4; x<4; x+=0.02){
                        outstream.WriteLine($"{x} {sfuns.gamma(x)}");
                                }
                outstream.Close();

                // Outputting to out_lngamma.txt:
                outfile="out_lngamma.txt";
                outstream=new System.IO.StreamWriter(outfile,append:false);

                for(double x = 1; x<4; x+=0.02){
                        outstream.WriteLine($"{x} {sfuns.lngamma(x)}");
                                }
                outstream.Close();
        return 0;
        }//Main
}//main
