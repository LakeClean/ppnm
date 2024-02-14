using static System.Console;

public static class main{
    static void Main(){
        // Lets first test if we can make a vector:
        var v = new vec(1,2,3);
	WriteLine($"Vector v=(1,2,3) is constructed: {v}");
	
	// Checking operators:
	WriteLine($"10*v: {10*v}, v*10: {v*10}");
	var u = new vec(4,5,6);
	WriteLine($"We define additional vector u: {u}");
	WriteLine($"v+u: {v+u}");
	WriteLine($"-v: {-v}");
	WriteLine($"v-u: {v-u}");

	//Checking print method
	v.print("v is equal to: ");
	Write("We test the v.print() with no argument: ");
	v.print();
	
	//Checking dot-product, vector-product, and norm methods:
	WriteLine($"v.dot(u): {v.dot(u)}, should be equal to: 32");
	WriteLine($"vec.dot(u,v): {vec.dot(u,v)}, should be equal to: 32");
	vec w = vec.cross(v,u);
	w.print("w is the cross product of u and v and is equal to: ");
	WriteLine($"vec.norm(v): {vec.norm(v)}");
	
	//Checking approx method:
	WriteLine($"vec.approx(u,v) is: {vec.approx(u,v)} and should be false");
	vec d1 = new vec(0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1,0,0);
	vec d2 = new vec(8*0.1,0,0);
	WriteLine($"vec.approx(d1,d2) is: {vec.approx(d1,d2)} and should be true");
	
	//Checking ToString Method
	WriteLine($"ToString of v returns: {v.ToString()}");
    }//Main
}//main
