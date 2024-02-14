Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs
	mcs main.cs

clean:
	$(RM) main.exe main.out
