CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^)) #REMOVE THIS?
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE) #REMOVE THIS?
TIME = time --portability --append --output $@ #REMOVE THIS?




Out.txt: main.exe
	mono main.exe -numbers:1,2,3,4,5 > Out.txt


main.exe: main.cs; $(MKEXE)

clean:
	$(RM) *.exe [Oo]ut*
