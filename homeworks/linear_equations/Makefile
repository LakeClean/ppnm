CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)

all: Out.txt; cat $<


Out.txt: main.exe Makefile
		mono main.exe > Out.txt

QRGS.dll: QRGS.cs matrix.dll vector.dll ; $(MKDLL)

matrix.dll: matrix.cs vector.dll; $(MKDLL)

vector.dll: vector.cs ; $(MKDLL)

main.exe: QRGS.dll matrix.dll vector.dll main.cs ; $(MKEXE)

clean:
		$(RM) *.exe [Oo]ut*.txt *.dll