CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)

Out.txt: main.exe Makefile
	mono main.exe > Out.txt

vec.dll: vec.cs ; $(MKDLL)

main.exe: vec.dll main.cs ; $(MKEXE)

clean:
	$(RM) main.exe Out.txt vec.dll
