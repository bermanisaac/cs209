using System;

public class Puppy{
	private uint age;
	public string name;



	public Puppy(){
		age = 0;
		name = "Fido";
	}





	public Puppy(uint a, string n)
	{
		age = a;
		name = n;
	}


	public void setName(string n)
	{  name = n; }

	public void setAge(uint a)
	{ age = a; }

	public String getName()
	{ return name; } // return name;

	public uint getAge()
	{ return age;}   // return age;
} // end of class Puppy


