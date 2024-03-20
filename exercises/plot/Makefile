CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:,$(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

RUN_ALL: Out.erf.gnuplot.svg Out.gamma.gnuplot.svg Out.lngamma.gnuplot.svg Makefile #Out.lambda.gnuplot.svg 
	eog Out.erf.gnuplot.svg &
	eog Out.gamma.gnuplot.svg &

#Plotting Error function
Out.erf.gnuplot.svg : out_erf.txt tabulated_erf.txt
		echo '\
				set terminal svg background "white";\
				set out "$@" ;\
				set xlabel "x" ;\
				set ylabel "erf(x)" ;\
				set title "Plot of errorfunction" ;\
				set key left ;\
				plot[-3:3] [-1:1] \
					"out_erf.txt" using 1:2 with lines title "Erf(x) with sfuns" lc rgb "blue"\
					,"out_erf.txt" using (-($$1)):(-($$2)) with lines notitle lc rgb "blue"\
					,"tabulated_erf.txt" using (-($$1)):(-($$2)) with points title "Tabulated" lc "orange" pt "o" ps 6.0 \
					,"tabulated_erf.txt" using 1:2 with points lc "orange" pt "o" ps 6.0 notitle;\
		'| tee log.gpi | gnuplot

#Plotting gamma function
Out.gamma.gnuplot.svg : out_gamma.txt
		echo '\
				set terminal svg background "white";\
				set out "$@" ;\
				set xlabel "x" ;\
				set ylabel "gamma(x)" ;\
				set title "Plot of gamma function" ;\
				set key left ;\
				plot[-4:4] [-4:4] \
					"out_gamma.txt" using 1:2 with lines title "gamma(x) with sfuns" lc rgb "blue";\
		'| tee log.gpi | gnuplot


#Plotting lngamma function
Out.lngamma.gnuplot.svg : out_lngamma.txt
		echo '\
				set terminal svg background "white";\
				set out "$@" ;\
				set xlabel "x" ;\
				set ylabel "lngamma(x)" ;\
				set title "Plot of lngamma function" ;\
				set key left ;\
				plot[-4:4] [-4:4] \
					"out_lngamma.txt" using 1:2 with lines title "lngamma(x) with sfuns" lc rgb "blue";\
		'| tee log.gpi | gnuplot


out_erf.txt out_gamma.txt out_lngamma.txt: main.exe
	mono $<

sfuns.dll : sfuns.cs; $(MKLIB)

main.exe : main.cs sfuns.dll; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
