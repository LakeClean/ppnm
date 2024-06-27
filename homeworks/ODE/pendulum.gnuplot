set terminal svg background "white"
set output "pendulum.svg"
set key left 
set xlabel "x" 
set ylabel "y"
set tics out 
set grid 
set title "Pendulum" 
plot\
"pendulum.txt" using 1:2 with lines title 'theta(t)', \
"pendulum.txt" using 1:3 with lines title 'omega(t)' \