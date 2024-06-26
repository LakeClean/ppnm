set terminal svg background "white"
set output "sphere.svg"
set key left
set xlabel "N [Number of sampling points]"
set ylabel "Error"
set tics out
set grid
set title "Error for area of surface of sphere"
plot [0:20000] [0:1]\
"out_sphere.txt" using 1:3 with points title 'Estimated', \
"out_sphere.txt" using 1:4 with points title 'actual', \
"out_sphere.txt" using 1:5 with lines title '1/sqrt(N)' \