CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
TIME = time --portability --append --output $@

run_all: Out_pitfal.txt Out.txt


N=1e8

Out_pitfal.txt: main_pitfal.exe Makefile
	$(TIME) mono $< -nterms:$N >$@


Out.txt: main.exe Makefile
	>$@
	$(TIME) mono $< -nterms:$N -nthreads:1 >>$@
	$(TIME) mono $< -nterms:$N -nthreads:2 >>$@
	$(TIME) mono $< -nterms:$N -nthreads:3 >>$@
	$(TIME) mono $< -nterms:$N -nthreads:4 >>$@



main.exe: main.cs; $(MKEXE)
main_pitfal.exe: main_pitfal.cs Makefile; $(MKEXE)

clean:
	$(RM) *.exe [Oo]ut*
