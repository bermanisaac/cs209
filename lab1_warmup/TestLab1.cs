using System;

public class TestLab1
{
	/* TestPrintStuff
	 * receives user input for testing one call of PrintStuff
	 * it first checks to make sure the input is well formed.
	 *
	 * inputs:
	 *  string[] args - it contains {"0", "int", "float", "char", "string"}
	 * outputs:
 	 *  no return value. Prints to the screen through function call
	 */
	public static void TestPrintStuff(string[] args)
	{
		int i;
		float f;
		if (args.Length < 5)
		{
			Console.WriteLine("Too few arguments for TestPrintStuff: "
				+args.Length);
			Console.WriteLine("Usage: TestLab1.exe 0 int float char string");
			System.Environment.Exit(0);
		}

		try
		{
			i = Int32.Parse(args[1]);
			f = float.Parse(args[2]);
		}
		catch (FormatException e)
		{
			Console.WriteLine("Could not read arguments for PrintStuff");
			Console.WriteLine(e.Message);
			return;
		}

		Lab1SampleFunctions lsf = new Lab1SampleFunctions();
		lsf.PrintStuff(i, f, args[3][0], args[4]);
	}

	/* TestReturnAValue
	 * receives user input for testing one call of ReturnAValue
	 * it first checks to make sure the input is well formed.
	 *
	 * inputs:
	 *  string[] args - it contains {"1", "int", "int"}
	 * outputs:
 	 *  uint - returns 1 if success, 0 if failure
	 */
	public static uint TestReturnAValue(string[] args)
	{
		int input, expectedOutput, output;
		if (args.Length < 3)
		{
			Console.WriteLine("Too few arguments for TestReturnAValue: "
				+args.Length);
			Console.WriteLine("Usage: TestLab1.exe 1 input expectedOutput");
			System.Environment.Exit(0);
		}

		try
		{
			input = Int32.Parse(args[1]);
			expectedOutput = Int32.Parse(args[2]);
		}
		catch (FormatException e)
		{
			Console.WriteLine("Could not read arguments for ReturnAValue");
			Console.WriteLine(e.Message);
			return 0;
		}

		Lab1SampleFunctions lsf = new Lab1SampleFunctions();
		output = lsf.ReturnAValue(input);
		if (output == expectedOutput)
		{
			Console.WriteLine("ReturnAValue("+input+") = "+
				output+" Success!");
			return 1;
		}
		else
		{
			Console.WriteLine("ReturnAValue("+input+") = "+
				output+". Did not match expected output: "+
				expectedOutput+".  FAIL!");
			return 0;
		}
	}

	/* TestFactorial
	 * receives user input for testing one call of Factorial
	 * it first checks to make sure the input is well formed.
	 *
	 * inputs:
	 *  string[] args - it contains {"2", "uint", "uint"}
	 * outputs:
 	 *  uint - returns 1 if success, 0 if failure
	 */
	public static uint TestFactorial(string[] args)
	{
		uint input, expectedOutput, output;
		if (args.Length < 3)
		{
			Console.WriteLine("Too few arguments for TestFactorial: "
				+args.Length);
			Console.WriteLine("Usage: TestLab1.exe 2 input expectedOutput");
			System.Environment.Exit(0);
		}

		try
		{
			input = uint.Parse(args[1]);
			expectedOutput = uint.Parse(args[2]);
		}
		catch (FormatException e)
		{
			Console.WriteLine("Could not read arguments for Factorial");
			Console.WriteLine(e.Message);
			return 0;
		}

		Lab1SampleFunctions lsf = new Lab1SampleFunctions();
		output = lsf.Factorial(input);
		if (output == expectedOutput)
		{
			Console.WriteLine("Factorial("+input+") = "+
				output+" Success!");
			return 1;
		}
		else
		{
			Console.WriteLine("Factorial("+input+") = "+
				output+". Did not match expected output: "+
				expectedOutput+".  FAIL!");
			return 0;
		}
	}

	/* TestSumAges
	 * receives user input for testing one call of Factorial
	 * it first checks to make sure the input is well formed.
	 *
	 * inputs:
	 *  string[] args - it contains {"2", "uint", "uint", "uint"}
	 *      these correspond to two ages and the expected outcome.
	 * outputs:
 	 *  uint - returns 1 if success, 0 if failure
	 */
	public static uint TestSumAges(string[] args)
	{
		uint input1, input2, expectedOutput, output;
		if (args.Length < 4)
		{
			Console.WriteLine("Too few arguments for TestFactorial: "
				+args.Length);
			Console.WriteLine("Usage: TestLab1.exe 3 input1 "+
				"input2 expectedOutput");
			System.Environment.Exit(0);
		}

		try
		{
			input1 = uint.Parse(args[1]);
			input2 = uint.Parse(args[2]);
			expectedOutput = uint.Parse(args[3]);
		}
		catch (FormatException e)
		{
			Console.WriteLine("Could not read arguments for Factorial");
			Console.WriteLine(e.Message);
			return 0;
		}

		Lab1SampleFunctions lsf = new Lab1SampleFunctions();

		Puppy p1 = new Puppy(input1, "Puppy1");
		Puppy p2 = new Puppy(input2, "Puppy2");
		output = lsf.SumAges(p1, p2);
		if (output == expectedOutput)
		{
			Console.WriteLine("SumAges("+input1+","+input2+
				") = "+ output+" Success!");
			return 1;
		}
		else
		{
			Console.WriteLine("SumAges("+input1+","+input2+
				") = "+output+
				". Did not match expected output: "+
				expectedOutput+".  FAIL!");
			return 0;
		}
	}

	/* TestDogYears
	 * receives user input for testing one call of DogYears
	 * it first checks to make sure the input is well formed.
	 *
	 * inputs:
	 *  string[] args - it contains {"2", "uint", "uint"}
	 *      these correspond to the age in years and the expected outcome.
	 * outputs:
 	 *  uint - returns 1 if success, 0 if failure
	 */
	public static uint TestDogYears(string[] args)
	{
		uint input1, expectedOutput, output;
		if (args.Length < 3)
		{
			Console.WriteLine("Too few arguments for TestDogYears: "
				+args.Length);
			Console.WriteLine("Usage: TestLab1.exe 4 input1 expectedOutput");
			System.Environment.Exit(0);
		}

		try
		{
			input1 = uint.Parse(args[1]);
			expectedOutput = uint.Parse(args[2]);
		}
		catch (FormatException e)
		{
			Console.WriteLine("Could not read arguments for Factorial");
			Console.WriteLine(e.Message);
			return 0;
		}

		Lab1SampleFunctions lsf = new Lab1SampleFunctions();

		Puppy p1 = new Puppy(input1, "Puppy1");
		output = lsf.DogYears(p1);
		if (output == expectedOutput)
		{
			Console.WriteLine("DogYears("+input1+") = "+ output+" Success!");
			return 1;
		}
		else
		{
			Console.WriteLine("DogYears("+input1+") = "+output+
				". Did not match expected output: "+
				expectedOutput+".  FAIL!");
			return 0;
		}
	}

	public static void Main(string[] args)
	{
		uint testnumber = 2;
		if (args.Length < 2)
		{
			Console.WriteLine("Too few arguments: "+args.Length);
			Console.WriteLine("Usage: TestLab1.exe testnumber argument");
			System.Environment.Exit(0);
		}

		try
		{
			testnumber = uint.Parse(args[0]);
		}
		catch (FormatException e)
		{
			Console.WriteLine("Could not read testnumber");
			Console.WriteLine(e.Message);
			System.Environment.Exit(0);
		}

		switch (testnumber)
		{
			case (0):
				TestPrintStuff(args);
				break;
			case (1):
				TestReturnAValue(args);
				break;
			case (2):
				TestFactorial(args);
				break;
			case (3):
				TestSumAges(args);
				break;
			case (4):
				TestDogYears(args);
				break;
		}
	}
}
