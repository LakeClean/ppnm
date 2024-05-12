CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)

PRINT: Out.txt Makefile main.exe monte_carlo.dll
	cat Out.txt 

Out.txt: main.exe
		mono main.exe > Out.txt

#monte_carlo.dll: monte_carlo.cs ../../resources/vector.dll; $(MKDLL)


main.exe: main.cs vector.dll monte_carlo.dll
	$(MKEXE)

monte_carlo.dll: monte_carlo.cs vector.dll
	$(MKDLL)

vector.dll: vector.cs
	$(MKDLL)

clean:
		$(RM) *.exe *.dll [Oo]ut* log.*

######################## Plotting: ##########################



