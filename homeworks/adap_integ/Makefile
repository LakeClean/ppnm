CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)



PRINT: Out.txt Makefile main.cs
	cat $<

Out.txt: main.exe
		mono main.exe > Out.txt

integ.dll: integ.cs ; $(MKDLL)

main.exe:  main.cs integ.dll ; $(MKEXE)

clean:
		$(RM) *.exe [Oo]ut*.txt *.dll
