set terminal svg background "white"
set output "precession.svg"
set key left 
set xlabel "x" 
set ylabel "y"
set tics out 
set grid 
set title "Precessing orbit" 
plot "precession.txt" using (1/$2)*cos($1):(1/$2)*sin($1) with lines notitle