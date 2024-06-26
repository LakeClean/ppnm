CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)

#For this project we use matrix and vector libraries from resources directory
resources = ~/repos/ppnm/resources/matrix.cs ~/repos/ppnm/resources/vector.cs

all: Out_decomp.txt Out_solve.txt Out_inverse.txt; 
	cat $^

Out_decomp.txt: main_decomp.exe Makefile
		mono main_decomp.exe > Out_decomp.txt

Out_solve.txt: main_solve.exe Makefile
		mono main_solve.exe > Out_solve.txt

Out_inverse.txt: main_inverse.exe Makefile
		mono main_inverse.exe > Out_inverse.txt


# Mains:
main_decomp.exe: QRGS.dll main_decomp.cs ; $(MKEXE)
main_solve.exe: QRGS.dll main_solve.cs ; $(MKEXE)
main_inverse.exe: QRGS.dll main_inverse.cs ; $(MKEXE)

# Libraries:
QRGS.dll: QRGS.cs $(resources) ; $(MKDLL)

# Cleaning:
clean:
		$(RM) *.exe [Oo]ut*.txt *.dll
