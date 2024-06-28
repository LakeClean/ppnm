CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:,$(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
resources = ~/repos/ppnm/resources/matrix.cs ~/repos/ppnm/resources/vector.cs

all: Out.txt cosine_interpolation.svg cosine_integral.svg;
	cat Out.txt

#Plotting cosine and interpolation
cosine_interpolation.svg : cosine.gnuplot
	gnuplot $<

#Plotting cosine and integral
cosine_integral.svg : antiderivative.gnuplot
	gnuplot $<

# Writing data to file
Out.txt: main.exe
	mono $< > $@

spline.dll : spline.cs $(resources); $(MKLIB)

main.exe : main.cs spline.dll; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og* *.svg
