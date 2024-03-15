CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)


Out.txt: 


genlist.dll: genlist.cs; $(MKLIB)
	
main.exe: main.cs; $(MKEXE)
