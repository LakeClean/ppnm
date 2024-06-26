set terminal svg background "white"
set output "circle.svg"
set key left
set xlabel "N [Number of sampling points]"
set ylabel "Error"
set tics out
set grid
set title "Error for area of circle"
plot [0:20000] [0:0.08]\
"out_circle.txt" using 1:3 with points title 'Estimated', \
"out_circle.txt" using 1:4 with points title 'actual', \
"out_circle.txt" using 1:5 with lines title '1/sqrt(N)' \