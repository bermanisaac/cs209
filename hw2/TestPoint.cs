using System;

public class TestPoint {
    private static int[] argCounts = {10, 8, 8, 8, 8, 8, 8, 11, 11};

    //Tests the SetLocation method for the Point class.
    //Takes in test and expected end Points, and new coordinates.
    public static void TestSetLocation(Point test, Point expected, int x, int y, int z) {
        test.SetLocation(x, y, z);
        if(!test.Equals(expected)) {
            Console.WriteLine("SetLocation method had unexpected outcome. Got " + test.ToString() + ", expected " + expected.ToString());
            return;
        }

        Console.WriteLine("SetLocation test success");
    }

    //Tests any of the getters and setters for the Point class.
    //Takes in test number, test Point and expected end Point, and value to get/set
    public static void TestSetGet(uint testNumber, Point test, Point expected, int val) {
        int ret = 0;
        switch(testNumber) {
            case 1:
                test.SetX(val);
                break;
            case 2:
                test.SetY(val);
                break;
            case 3:
                test.SetZ(val);
                break;
            case 4:
                ret = test.GetX();
                break;
            case 5:
                ret = test.GetY();
                break;
            case 6:
                ret = test.GetZ();
                break;
        }
        if(!test.Equals(expected)) {
            Console.WriteLine("Getter/Setter method had unexpected outcome. Got " + test.ToString() + ", expected " + expected.ToString());
            return;
        }
        if(testNumber > 3 && ret != val) {
            Console.WriteLine("Unexpected return value from Getter. Got " + ret + ", expected " + val);
            return;
        }

        Console.WriteLine("Getter/Setter test success");
    }

    //Tests the CalculateDistance method for the Point class
    //Takes in test and expected Points, coordinates for other point and actual distance
    public static void TestCalculateDistance(Point test, Point expected, int x, int y, int z, float distance) {
        float ret = test.CalculateDistance(new Point(x, y, z));

        if(!test.Equals(expected)) {
            Console.WriteLine("CalculateDistance method had unexpected outcome. Got " + test.ToString() + ", expected " + expected.ToString());
            return;
        }

        Console.WriteLine("Distance was " + ret + ", expected : " + distance + ". Difference: " + (ret - distance));
    }

    //Tests the Equals method for the Point class. Passing the above tests for points with distance 0 is equivalent to passing this test.
    //Takes in test and expected Points, coordinates for other point and expected result.
    public static void TestEquals(Point test, Point expected, int x, int y, int z, bool equal) {
        bool ret = test.Equals(new Point(x, y,z));
        if(!test.Equals(expected)) {
            Console.WriteLine("Equals method had unexpected outcome. Got " + test.ToString() + ", expected " + expected.ToString());
            return;
        }
        if(ret != equal) {
            Console.WriteLine("Equals method had unexpected result. Got " + ret + ", expected " + equal);
            return;
        }

        Console.WriteLine("Equals test success");
    }

    public static void Main(string[] args)
    {
        uint testNumber = 2;
        Point test = new Point();
        Point expected = new Point();

        // make sure there are enough arguments
        if (args.Length < 8)
        {
            Console.WriteLine("Too few arguments: "+args.Length);
            Console.WriteLine("Usage: TestPoint.exe start_state "
                +"expected_end_state testNumber inputs "
                +"expected_ret_val");
            System.Environment.Exit(0);
        }

        // get the starting state, ending state, and test number
        try
        {
            test.SetLocation(
                int.Parse(args[0]),
                int.Parse(args[1]),
                int.Parse(args[2]));
            expected.SetLocation(
                int.Parse(args[3]),
                int.Parse(args[4]),
                int.Parse(args[5]));
            testNumber = uint.Parse(args[6]);
        }
        catch (FormatException e)
        {
            Console.WriteLine("Could not read arguments");
            Console.WriteLine(e.Message);
            System.Environment.Exit(0);
        }

        if(args.Length != argCounts[testNumber]) {
            Console.WriteLine("Incorrect argument count provided for the given test. Expected " + argCounts[testNumber] + ", got " + args.Length);
            return;
        }

        int x = 0, y = 0, z = 0;
        // use the testnumber to choose a test function
        switch (testNumber)
        {
            case (0):
                int newX = 0, newY = 0, newZ = 0;
                try {
                    newX = int.Parse(args[7]);
                    newY = int.Parse(args[8]);
                    newZ = int.Parse(args[9]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Could not read arguments");
                    Console.WriteLine(e.Message);
                    System.Environment.Exit(0);
                }
                TestSetLocation(test, expected, newX, newY, newZ);
                break;
            case (1):
            case (2):
            case (3):
            case (4):
            case (5):
            case (6):
                int val = 0;
                try {
                    val = int.Parse(args[7]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Could not read arguments");
                    Console.WriteLine(e.Message);
                    System.Environment.Exit(0);
                }
                TestSetGet(testNumber, test, expected, val);
                break;
            case (7):
                float distance = 0;
                try {
                    x = int.Parse(args[7]);
                    y = int.Parse(args[8]);
                    z = int.Parse(args[9]);
                    distance = float.Parse(args[10]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Could not read arguments");
                    Console.WriteLine(e.Message);
                    System.Environment.Exit(0);
                }
                TestCalculateDistance(test, expected, x, y, z, distance);
                break;
            case (8):
                bool equal = false;
                try {
                    x = int.Parse(args[7]);
                    y = int.Parse(args[8]);
                    z = int.Parse(args[9]);
                    equal = bool.Parse(args[10]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Could not read arguments");
                    Console.WriteLine(e.Message);
                    System.Environment.Exit(0);
                }
                TestEquals(test, expected, x, y, z, equal);
                break;
        }
    }
}