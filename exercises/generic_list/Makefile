CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)


Out.txt: main.exe genlist.dll
	mono main.exe < input.txt > Out.txt


genlist.dll: genlist.cs; $(MKLIB)
	
main.exe: main.cs genlist.dll ; $(MKEXE)

clean: 
	$(RM) Out.txt *.exe
