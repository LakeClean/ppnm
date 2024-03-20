CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE) 

showoutput: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt

cmath.dll : cmath.cs complex.cs
	mcs -target:library -out:./cmath.dll $^

main.exe : main.cs cmath.dll
	mcs -reference:cmath.dll -target:exe -out:main.exe main.cs


