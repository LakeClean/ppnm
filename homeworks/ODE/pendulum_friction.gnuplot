set terminal svg background "white"
set output "pendulum_friction.svg"
set key left 
set xlabel "x" 
set ylabel "y"
set tics out 
set grid 
set title "Pendulum with friction" 
plot\
"pendulum_friction.txt" using 1:2 with lines title 'theta(t)', \
"pendulum_friction.txt" using 1:3 with lines title 'omega(t)' \