CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)
resources = ~/repos/ppnm/resources/matrix.cs ~/repos/ppnm/resources/vector.cs

all: Out.txt circle.svg sphere.svg
	cat Out.txt 

Out.txt: main.exe
		mono main.exe > Out.txt

circle.svg: circle.gnuplot out_circle.txt
		gnuplot $<

sphere.svg: sphere.gnuplot out_sphere.txt
		gnuplot $<

main.exe: main.cs monte_carlo.dll; $(MKEXE)

monte_carlo.dll: monte_carlo.cs $(resources); $(MKDLL)


clean:
		$(RM) *.exe *.dll [Oo]ut* log.* *.svg



