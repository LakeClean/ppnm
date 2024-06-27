CODE = $(filter %.cs,$^)
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKDLL = mcs -target:library -out:$@ $(DLLS) $(CODE)
resources = ~/repos/ppnm/resources/matrix.cs ~/repos/ppnm/resources/vector.cs ~/repos/ppnm/resources/vector.cs

all: Out.txt multibody_8figure.svg pendulum.svg pendulum_friction.svg orbit.svg precession.svg;
	cat Out.txt

Out.txt: main.exe Makefile
		mono main.exe > Out.txt

ODE_solver.dll: ODE_solver.cs genlist.cs $(resources); $(MKDLL)

main.exe: main.cs ODE_solver.dll; $(MKEXE)

######################## Plotting: ############################
multibody_8figure.svg: multibody_8figure.gnuplot
	gnuplot $<

pendulum.svg: pendulum.gnuplot
	gnuplot $<

pendulum_friction.svg: pendulum_friction.gnuplot
	gnuplot $<

orbit.svg: orbit.gnuplot
	gnuplot $<

precession.svg: precession.gnuplot
	gnuplot $<

###############################################################
clean:
		$(RM) *.exe *.txt *.dll *.svg