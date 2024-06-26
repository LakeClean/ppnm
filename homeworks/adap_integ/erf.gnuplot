set terminal svg background "white"
set out "out_erf.svg"
set xlabel "x"
set ylabel "erf(x)"
set title "Plot of errorfunction"
set key left 
plot[-3:3] [-1:1] \
"out_erf.txt" using 1:2 with points title "Tabulated value" lc rgb "blue",\
"out_erf.txt" using (-($1)):(-($2)) with points notitle lc rgb "blue",\
"out_erf.txt" using 1:4 with lines title "Erf(x) with addaptive integ." lc rgb "red",\
"out_erf.txt" using (-($1)):(-($4)) with lines notitle lc rgb "red"\