CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)
resources = ~/repos/ppnm/resources/matrix.cs ~/repos/ppnm/resources/vector.cs ~/repos/ppnm/resources/QRGS.cs ~/repos/ppnm/resources/minimization.cs

all: Out.txt A.svg main.cs ann.cs
	cat Out.txt 

Out.txt: main.exe
		mono main.exe > Out.txt

main.exe: main.cs ann.dll
	$(MKEXE)

#Plotting:
A.svg: A.gnuplot Out.txt
	gnuplot $<

ann.dll: ann.cs $(resources); $(MKDLL) 

clean:
		$(RM) *.exe [Oo]ut* log.* *.dll *.svg





