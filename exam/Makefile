CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)
resources = ~/repos/ppnm/resources/vector.cs ~/repos/ppnm/resources/sfuns.cs ~/repos/ppnm/resources/integ.cs ~/repos/ppnm/resources/genlist.cs


all: Out.txt Makefile main.exe
	cat Out.txt 


Out.txt: main.exe
		mono main.exe > Out.txt

integ.dll: integ.cs $(resources); $(MKDLL)

main.exe:  main.cs integ.dll ; $(MKEXE)

clean:
		$(RM) *.exe *.dll [Oo]ut* log.* *.svg




