using System;

public class Lab1SampleFunctions{

	/**** up here are example functions ****/

	/* print_stuff: prints several variables of different types
	 * purpose is to illustrate printf and the types C provides
	 * void means it doesn't return a value - it does something instead
	 * inputs:
	 *    int ival - integer value that will be printed out as an integer
	 *    float fval - floating-point value that will be printed out as a float
	 *    char cval - char value that will be printed out as a character
	 *    string sval - string that will be printed out
	 */
	public void PrintStuff(int ival, float fval, char cval, string sval)
	{
		Console.WriteLine("You can use + operator on strings to print"
			+ " multiple types: " + ival + ", " + fval + ", "
			+ cval + ", " + sval);
	}

	/* ReturnAValue: purpose is to show how to declare values,
	 * calculate a result, and return that result to the caller
	 * inputs:
	 * 	int ival - integer value we will multiply by 5
	 * outputs:
	 *      int result - the original input multiplied by 5
	 */
	public int ReturnAValue(int ival)
	{
		int result = ival*5;
		return result;
	}

	/* fact : compute Factorial of given number
	 * This illustrates how to write recursive code in C
	 * inputs:
	 * 	uint - we will calculate n!
	 * outputs:
	 * 	uint - n!
	 */
	public uint Factorial(uint n)
	{
	  // base case
	  if (n==0)
	  {
	    return 1;
	  }
	  else
	  {
	    // call the recursive case
	    uint smaller_result = Factorial(n-1);
	    // modify the result from recursive case and return our result
	    return n * smaller_result;
	  }
	}

	/* add_ages: compute the sum of the ages of two Puppy objects
	 * inputs:
	 *   Puppy p1 - the first puppy
	 *   Puppy p2 - the second puppy
	 * outputs:
	 *   uint result: the sum of the ages of p1 and p2
	 */
	public uint SumAges(Puppy p1, Puppy p2)
	{
		uint a1 = p1.getAge();
		uint a2 = p2.getAge();
		return a1 + a2;
	}

	/***** TODO: Below here is your assignment *****/

	/* DogYears: compute the dog's age in "dog years" - multipled by 7
	 * inputs:
	 *   Puppy p1 - the first puppy
	 * outputs:
	 *   uint result: the product of p1's age times 7
	 */
	public uint DogYears(Puppy p1)
	{
		// TODO: Remove WriteLine and fill in proper code
		return 7 * p1.getAge();
	}

} // end of class Lab1SampleFunctions
