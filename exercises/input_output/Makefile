CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)

all: Out_std_error.txt Out.txt Makefile outputfile
	cat Out.txt Out_std_error.txt outputfile


Out_std_error.txt: read_from_std_input.exe 
	mono read_from_std_input.exe < input.txt 2> Out_std_error.txt


Out.txt: read_from_command_line.exe
	mono read_from_command_line.exe -numbers:1,2,3,4,5 1> Out.txt


outputfile: read_from_inputfile.exe
	mono read_from_inputfile.exe -input:inputfile -output:outputfile

read_from_std_input.exe: read_from_std_input.cs; $(MKEXE)

read_from_command_line.exe: read_from_command_line.cs; $(MKEXE)

read_from_inputfile.exe: read_from_inputfile.cs; $(MKEXE)

clean:
	$(RM) *.exe [Oo]ut*
