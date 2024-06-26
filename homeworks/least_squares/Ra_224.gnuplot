set terminal svg background "white"
set output "Ra_224.svg"
set key left 
set xlabel "t [days]" 
set ylabel "ln(Activity) [relative units]"
set tics out 
set grid 
set title "Decay of Ra-224" 
plot [0:16]\
"output.txt" using 1:2:3 with yerrorbars title 'Data', \
"output.txt" using 1:4 with lines title 'fit' \

