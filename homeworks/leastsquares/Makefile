CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)

#For this project we use matrix and vector libraries from resources directory
resources = ~/repos/ppnm/resources/matrix.cs ~/repos/ppnm/resources/vector.cs ~/repos/ppnm/resources/QRGS.cs

all: Out.txt least_squares.dll main.cs
	cat $^

Out.txt: main.exe
		mono main.exe > Out.txt

# Mains:
main.exe: matrix.dll vector.dll QRGS.dll least_squares.dll main.cs ; $(MKEXE)

# Libraries:
# extlib.dll: matrix.cs vector.cs QRGS.cs ; $(MKDLL)

matrix.dll: matrix.cs vector.dll ; $(MKDLL)
QRGS.dll: QRGS.cs matrix.dll vector.dll ; $(MKDLL)
vector.dll: vector.cs ; $(MKDLL)

least_squares.dll: least_squares.cs vector.dll QRGS.dll matrix.dll; $(MKDLL)

# Cleaning:
clean:
		$(RM) *.exe [Oo]ut*.txt *.dll
