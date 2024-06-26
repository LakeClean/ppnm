
set terminal svg background "white";\
set out "cosine_interpolation.svg" ;\
set xlabel "x" ;\
set ylabel "y" ;\
set title "Linear Spline Interpolation" ;\
set key left ;\
plot[-1:11] [0:2]\
"out_cosine_interpolation.txt" using 1:2 with points lc "blue" pt "o" ps 12.0 title "Interpolation",\
"out_cosine.txt" using 1:2 with points lc "orange" pt "o" ps 12.0 title "Data"\