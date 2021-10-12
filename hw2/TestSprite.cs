using System;
using System.Collections.Generic;

public class TestSprite {

    public static uint TestAddItem(Sprite start, Sprite expected, string[] args) {
        return TestSpriteInternal.TestWrapper(args);
    }

    public static uint TestHasItem(Sprite start, Sprite expected, string[] args) {
        return TestSpriteInternal.TestWrapper(args);
    }

    public static uint TestPutItemInQuickSlot(Sprite start, Sprite expected, string[] args) {
        return TestSpriteInternal.TestWrapper(args);
    }

    public static uint TestGetItemInQuickSlot(Sprite start, Sprite expected, string[] args) {
        return TestSpriteInternal.TestWrapper(args);
    }

    public static uint TestPrintInventory(Sprite start, Sprite expected, string[] args) {
        return TestSpriteInternal.TestWrapper(args);
    }

    public static uint TestPrintQuickSlots(Sprite start, Sprite expected, string[] args) {
        return TestSpriteInternal.TestWrapper(args);
    }

    public class TestSpriteInternal
    {
        //test argument counts
        static int[] argCounts = {18, 19, 19, 19, 18, 18};

        Sprite test;
        Sprite expected;
        uint testNumber;

        //Test specific variables:
        string testItem;
        uint testSlot;
        bool testRet;
        string expectedOutputFile;

        public TestSpriteInternal(Sprite test, Sprite expected, uint testNumber, string testInventory, string expectedInventory) {
            this.test = test;
            this.expected = expected;
            this.testNumber = testNumber;
            loadInventory(test, testInventory);
            loadInventory(expected, expectedInventory);


            // Console.WriteLine("Test sprite: " + test.ToString() + "\n\t Inventory:");
            // test.PrintInventory();
            // Console.WriteLine("\tQuickSlots:");
            // test.PrintQuickSlots();
            // Console.WriteLine("Expected sprite: " + expected.ToString() + "\n\t Inventory:");
            // expected.PrintInventory();
            // Console.WriteLine("\tQuickSlots:");
            // expected.PrintQuickSlots();
        }

        private void loadInventory(Sprite target, string file) {
            string[] lines = System.IO.File.ReadAllLines(file);
            foreach(string line in lines) {
                string[] words = line.Split(' ');
                if(words.Length < 3) {
                    Console.WriteLine("Bad input line in " + file + "on line:\n\t" + line);
                    continue;
                }
                string item = words[0];
                int count = 0;
                uint slot = 6;
                try {
                    count = int.Parse(words[1]);
                    slot = uint.Parse(words[2]);
                } catch (FormatException e) {
                    Console.WriteLine("Bad input line in " + file + "on line:\n\t" + line);
                    Console.WriteLine(e.Message);
                    continue;
                }
                while(count-- > 0) target.AddItem(item);
                if(slot < 6) {
                    target.PutItemInQuickSlot(item, slot);
                }
            }
        }

        /* Runs the test that this TestSprite object has been configured to run.
        * Precondtion: test and expected are initialized, testNumber is set, and
        * appropriate test-specific fields are set.
        */
        public uint runTest() {
            bool retBool = false;
            string retStr = "";
            switch(testNumber) {
                case 0:
                    test.AddItem(testItem);
                    break;
                case 1:
                    retBool = test.HasItem(testItem);
                    break;
                case 2:
                    test.PutItemInQuickSlot(testItem, testSlot);
                    break;
                case 3:
                    retStr = test.GetItemInQuickSlot(testSlot);
                    break;
                case 4:
                    test.PrintInventory();
                    break;
                case 5:
                    test.PrintQuickSlots();
                    break;
            }

            if(!test.Equals(expected)) {
                Console.WriteLine("Error: Test had unexpected side effects. Expected:\n\t" + expected.ToString() + "\nGot:\n\t" + test.ToString());
                test.PrintInventory();
                expected.PrintInventory();
                return 0;
            }
            if(testNumber == 1 && retBool != testRet) {
                Console.WriteLine("Error: HasItem returned " + retBool + " but expected " + testRet);
                return 0;
            }
            if(testNumber == 3) {
                if(retStr == null) {
                    if (!testItem.Equals("null")) {
                        Console.WriteLine("Error: HasItem returned null but expected " + testItem);
                        return 0;
                    }
                } else if(!(retStr.Equals(testItem))) {
                    Console.WriteLine("Error: HasItem returned " + retStr + " but expected " + testItem);
                    return 0;
                }
            }
            if(testNumber == 4 || testNumber == 5) {
                Console.WriteLine("Expected Output:\n" + System.IO.File.ReadAllText(expectedOutputFile));
            }
            Console.WriteLine("Test no. " + testNumber + " success!");
            return 1;
        }


        /* Main test function as before, but creates a TestSprite object loaded with
        * information needed to run the tests, and then runs that test.
        */
        public static uint TestWrapper(string[] args)
        {
            uint testNumber = 2;
            Sprite testSprite = new Sprite();
            Sprite expectedSprite = new Sprite();

            // make sure there are enough arguments
            if (args.Length < 15)
            {
                Console.WriteLine("Too few arguments: "+args.Length);
                Console.WriteLine("Usage: TestSprite.exe start_state "
                +"expected_end_state testNumber inputs "
                +"expected_ret_val");
                System.Environment.Exit(0);
            }

            // get the starting state, ending state, and test number
            try
            {
                testSprite.SetState(
                int.Parse(args[0]),
                int.Parse(args[1]),
                int.Parse(args[2]),
                uint.Parse(args[3]),
                uint.Parse(args[4]),
                uint.Parse(args[5]),
                uint.Parse(args[6]));
                expectedSprite.SetState(
                int.Parse(args[8]),
                int.Parse(args[9]),
                int.Parse(args[10]),
                uint.Parse(args[11]),
                uint.Parse(args[12]),
                uint.Parse(args[13]),
                uint.Parse(args[14]));
                testNumber = uint.Parse(args[16]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Could not read arguments");
                Console.WriteLine(e.Message);
                System.Environment.Exit(0);
            }

            if(args.Length != argCounts[testNumber]) {
                Console.WriteLine("Incorrect argument count provided for the given test. Expected " + argCounts[testNumber] + ", got " + args.Length);
                return 0;
            }

            TestSpriteInternal tester = new TestSpriteInternal(testSprite, expectedSprite, testNumber, args[7], args[15]);

            try {
                switch(testNumber) {
                    case 1:
                        tester.testRet = bool.Parse(args[18]);
                        tester.testItem = args[17];
                        break;
                    case 0:
                        tester.testItem = args[17];
                        break;
                    case 2:
                        tester.testItem = args[17];
                        tester.testSlot = uint.Parse(args[18]);
                        break;
                    case 3:
                        tester.testSlot = uint.Parse(args[17]);
                        tester.testItem = args[18];
                        break;
                    case 4:
                    case 5:
                        tester.expectedOutputFile = args[17];
                        break;
                }
            }
            catch (FormatException e) {
                Console.WriteLine("Could not read arguments");
                Console.WriteLine(e.Message);
                System.Environment.Exit(0);
            }

            //Finally, run the test that we've configured tester to run.
            return tester.runTest();
        }
    }

    public static void Main(string[] args) {
        TestSpriteInternal.TestWrapper(args);
    }
}
