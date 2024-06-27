set terminal svg background "white"
set output "multibody_8figure.svg"
set key left 
set xlabel "x" 
set ylabel "y"
set tics out 
set grid 
set title "Multibody 8 figure" 
plot\
"multibody_8figure.txt" using 8:9 with lines title 'Body 1', \
"multibody_8figure.txt" using 10:11 with lines title 'Body 2', \
"multibody_8figure.txt" using 12:13 with lines title 'Body 3' \