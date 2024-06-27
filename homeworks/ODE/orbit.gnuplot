set terminal svg background "white"
set output "orbit.svg"
set key left 
set xlabel "x" 
set ylabel "y"
set tics out 
set grid 
set title "Orbit" 
plot "orbit.txt" using (1/$2)*cos($1):(1/$2)*sin($1) with lines notitle