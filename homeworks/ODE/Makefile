CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)
resources = ~/repos/ppnm/resources/matrix.cs ~/repos/ppnm/resources/vector.cs

all: Out.txt; cat $<

Out.txt: main.exe Makefile
		mono main.exe > Out.txt

ODE_solver.dll: ODE_solver.cs genlist.cs $(resources); $(MKDLL)

main.exe: main.cs ODE_solver.dll; $(MKEXE)


clean:
		$(RM) *.exe [Oo]ut*.txt *.dll *.svg