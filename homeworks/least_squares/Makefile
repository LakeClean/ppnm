CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)
resources = ~/repos/ppnm/resources/matrix.cs ~/repos/ppnm/resources/vector.cs ~/repos/ppnm/resources/QRGS.cs 

all: Out.txt Ra_224.svg;
	cat Out.txt

Out.txt: main.exe
		mono main.exe > Out.txt

# Main:
main.exe: main.cs  least_squares.dll ; $(MKEXE)

#Plotting:
Ra_224.svg: Ra_224.gnuplot output.txt
	gnuplot $<

# Libraries:
least_squares.dll: least_squares.cs $(resources); $(MKDLL)

# Cleaning:
clean:
		$(RM) *.exe [Oo]ut*.txt *.dll *.svg