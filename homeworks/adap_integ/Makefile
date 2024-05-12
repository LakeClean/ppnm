CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)



PRINT: Out.txt Makefile main.exe Out.erf.gnuplot.svg
	eog Out.erf.gnuplot.svg &
	cat Out.txt 

#Plotting Error function
Out.erf.gnuplot.svg : approx_erf.txt out_erf.txt
				echo '\
								set terminal svg background "white";\
								set out "$@" ;\
								set xlabel "x" ;\
								set ylabel "erf(x)" ;\
								set title "Plot of errorfunction" ;\
								set key left ;\
								plot[-3:3] [-1:1] \
										"approx_erf.txt" using 1:2 with lines title "Erf(x) with sfuns" lc rgb "blue"\
										,"approx_erf.txt" using (-($$1)):(-($$2)) with lines notitle lc rgb "blue"\
										,"out_erf.txt" using 1:2 with lines title "Erf(x) with addaptive integ." lc rgb "red"\
										,"out_erf.txt" using (-($$1)):(-($$2)) with lines notitle lc rgb "red"\
										,;\
				'| tee log.gpi | gnuplot

Out.txt: main.exe
		mono main.exe > Out.txt

integ.dll: integ.cs ; $(MKDLL)

main.exe:  main.cs integ.dll ; $(MKEXE)

clean:
		$(RM) *.exe *.dll [Oo]ut* log.*

######################## Plotting: ##########################



