CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)
resources = ~/repos/ppnm/resources/matrix.cs ~/repos/ppnm/resources/vector.cs

all: Out.txt; 
	cat $^

Out.txt: main.exe Makefile EVD.cs
		mono main.exe > Out.txt

# Mains:
main.exe: EVD.dll main.cs ; $(MKEXE)

# Libraries:
EVD.dll: EVD.cs $(resources) ; $(MKDLL)

# Cleaning:
clean:
		$(RM) *.exe [Oo]ut*.txt *.dll