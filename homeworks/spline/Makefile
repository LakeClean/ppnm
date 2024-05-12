CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:,$(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

all: Out.txt Out.gnuplot.svg Makefile;
	cat $<

#Plotting Error function
Out.gnuplot.svg : Out.txt
		echo '\
                set terminal svg background "white";\
                set out "$@" ;\
                set xlabel "x" ;\
                set ylabel "y" ;\
                set title "Linear Spline Interpolation" ;\
                set key left ;\
                plot[-1:11] [-1:1]\
                        "Out.txt" using 1:2 with points lc "orange" pt "o" ps 6.0 title "Data";\
        '| tee log.gpi | gnuplot
# Writing data to file
Out.txt: main.exe
	mono $< > $@

spline.dll : spline.cs; $(MKLIB)

main.exe : main.cs spline.dll; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*
