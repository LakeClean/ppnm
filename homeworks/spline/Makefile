CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:,$(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

#Plotting Error function
Out.gnuplot.svg : Out.txt Makefile
				echo '\
                set terminal svg background "white";\
                set out "$@" ;\
                set xlabel "x" ;\
                set ylabel "y" ;\
                set title "Linear Spline Interpolation" ;\
                set key left ;\
                plot[-1:11]\
                        "$<" with lines notitle\
                        ,"Out.txt" using 0:10 with points pointtype 6 notitle\
                        ,"Out.txt" using (-($$0)):(-($$1)) with points pointtype 6 notitle ;\
        '| tee log.gpi | gnuplot
# Writing data to file
Out.txt: main.exe
		mono $< > $@

spline.dll : spline.cs; $(MKLIB)

main.exe : main.cs spline.dll; $(MKEXE)

clean:
		$(RM) *.exe *.dll [Oo]ut* [Ll]og*