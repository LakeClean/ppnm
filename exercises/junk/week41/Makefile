CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:,$(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

RUN_ALL: Out.erf.gnuplot.svg #Out.lambda.gnuplot.svg 

#Plotting Error function
Out.erf.gnuplot.svg : Out.erf.txt Makefile
		echo '\
				set terminal svg background "white";\
				set out "$@" ;\
				set xlabel "x" ;\
				set ylabel "erf(x)" ;\
				set title "Plot of errorfunction" ;\
				set key left ;\
				plot[-3:3]\
					"$<" with lines notitle\
						,"erf.data.txt" using 1:2 with points pointtype 6 notitle\
						,"erf.data.txt" using (-($$1)):(-($$2)) with points pointtype 6 notitle ;\
		'| tee log.gpi | gnuplot

#Plotting Lambda function
Out.lambda.gnuplot.svg : Out.lambda.txt Makefile
	echo '\
		set terminal svg background "white";\
		set out "$@" ;\
		set xlabel "x" ;\
		set ylabel "lambda(x)" ;\
		set title "Plot of Lambda function" ;\
		set key left ;\
		plot\
			"$<" with lines notitle;\
	' | tee log.gpi | gnuplot



Out.erf.txt: main.exe
	mono $< > $@

Out.lambda.txt: main.exe
	mono $< > $@


sfuns.dll : sfuns.cs; $(MKLIB)
main.exe : main.cs sfuns.dll; $(MKEXE)


clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
