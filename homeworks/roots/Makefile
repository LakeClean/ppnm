CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)
resources = ~/repos/ppnm/resources/matrix.cs ~/repos/ppnm/resources/vector.cs ~/repos/ppnm/resources/QRGS.cs

all: Out.txt Makefile main.exe roots.dll
	cat Out.txt 

Out.txt: main.exe
		mono main.exe > Out.txt


main.exe: main.cs roots.dll
	$(MKEXE)

roots.dll: roots.cs $(resources); $(MKDLL)

clean:
		$(RM) *.exe *.dll [Oo]ut* log.*




