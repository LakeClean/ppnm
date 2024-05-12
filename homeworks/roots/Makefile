CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)

PRINT: Out.txt Makefile main.exe roots.dll
	cat Out.txt 

Out.txt: main.exe
		mono main.exe > Out.txt

#monte_carlo.dll: monte_carlo.cs ../../resources/vector.dll; $(MKDLL)


main.exe: main.cs vector.dll roots.dll
	$(MKEXE)

roots.dll: roots.cs vector.dll QRGS.dll matrix.dll; $(MKDLL)

vector.dll: vector.cs ; $(MKDLL)

QRGS.dll: QRGS.cs matrix.dll vector.dll ; $(MKDLL)

matrix.dll: matrix.cs vector.dll; $(MKDLL)


clean:
		$(RM) *.exe *.dll [Oo]ut* log.*

######################## Plotting: ##########################



