set terminal svg background "white";\
set out "cosine_integral.svg" ;\
set xlabel "x" ;\
set ylabel "y" ;\
set title "Linear Spline Integral" ;\
set key left ;\
plot\
"out_cosine_interpolation.txt" using 1:3 with lines  title "Integral",\
"out_cosine_interpolation.txt" using 1:2 with lines title "Interpolation",\
"out_cosine.txt" using 1:2 with points title "Data"\