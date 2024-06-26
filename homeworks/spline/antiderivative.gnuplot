set terminal svg background "white";\
set out "cosine_integral.svg" ;\
set xlabel "x" ;\
set ylabel "y" ;\
set title "Linear Spline Integral" ;\
set key left ;\
plot[-1:11] [0:10]\
"out_cosine_interpolation.txt" using 1:3 with line lc "blue" pt "o" ps 12.0 title "Integral",\
"out_cosine.txt" using 1:2 with points lc "orange" pt "o" ps 12.0 title "Data"\