set terminal svg background "white"
set output "A.svg"
set key left 
set xlabel "x" 
set ylabel "g(x)"
set tics out 
set grid 
set title "g(x)=Cos(5*x-1)*Exp(-x*x)" 
plot\
"Out.txt" using 1:2 with lines title 'g(x)',\
"Out.txt" using 1:3 with points title 'Interpolated'\