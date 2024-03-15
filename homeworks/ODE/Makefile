CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)

all: Out.txt; cat $<

Out.txt: main.exe Makefile
		mono main.exe > Out.txt

ODE_solver.dll: ODE_solver.cs matrix.dll vector.dll genlist.dll; $(MKDLL)

genlist.dll: genlist.cs  ; $(MKDLL)

matrix.dll: matrix.cs vector.dll; $(MKDLL)

vector.dll: vector.cs ; $(MKDLL)

main.exe: vector.dll matrix.dll ODE_solver.dll main.cs genlist.dll ; $(MKEXE)

clean:
		$(RM) *.exe [Oo]ut*.txt *.dll