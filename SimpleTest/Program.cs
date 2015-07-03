using System;
using System.Collections.Generic;
using DiffProcessor;

namespace SimpleTest
{
    class Program
    {
        //static Processor diffProcessor = new Processor(1);
        //static SortedLimitedList<Double> sortedList1 = new SortedLimitedList<Double>(1);
        //static SortedLimitedList<Double> sortedList2 = new SortedLimitedList<Double>(1);
        //static SortedLimitedList<Double> sortedList1_ = new SortedLimitedList<Double>(1);
        //static SortedLimitedList<Double> sortedList2_ = new SortedLimitedList<Double>(1);

        //static Processor diffProcessor = new Processor(3);
        //static SortedLimitedList<Double> sortedList1 = new SortedLimitedList<Double>(3);
        //static SortedLimitedList<Double> sortedList2 = new SortedLimitedList<Double>(3);
        //static SortedLimitedList<Double> sortedList1_ = new SortedLimitedList<Double>(3);
        //static SortedLimitedList<Double> sortedList2_ = new SortedLimitedList<Double>(3);

        static Processor diffProcessor = new Processor(10);
        static SortedLimitedList<Double> sortedList1 = new SortedLimitedList<Double>(10);
        static SortedLimitedList<Double> sortedList2 = new SortedLimitedList<Double>(10);
        static SortedLimitedList<Double> sortedList1_ = new SortedLimitedList<Double>(10);
        static SortedLimitedList<Double> sortedList2_ = new SortedLimitedList<Double>(10);
        static Int64 test = 0;
        static void DoTest(Int32 operations)
        {
            try
            {
                diffProcessor.DoProcess(sortedList1, sortedList2);
                if (!sortedList1.Equals(sortedList2) || !sortedList1.Equals(sortedList2_) || sortedList1.PerformedOperations != operations)
                {
                    Console.WriteLine("Test case: " + ++test + " Failed. Inputs: mustBeEqual: [" + sortedList1_ + "] expected: [" + sortedList2_ + "]");
                    Console.WriteLine("Your output " + sortedList1);
                    Console.WriteLine("Performed operations: " + sortedList1.PerformedOperations + ", expected " + operations);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Test case: " + ++test + " Succeed. Inputs: mustBeEqual: [" + sortedList1_ + "] expected: [" + sortedList2_ + "]");
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test case: " + ++test + " Exception. Inputs: mustBeEqual: [" + sortedList1_ + "] expected: [" + sortedList2_ + "]");
                Console.WriteLine();
            }
        }

        static void Test(Double[] array1, Double[] array2, Int32 operations)
        {
            sortedList1.FromArray(array1);
            sortedList2.FromArray(array2);
            sortedList1_.FromArray(array1);
            sortedList2_.FromArray(array2);
            DoTest(operations);
        }

        static void Test(List<Double> list1, List<Double> list2, Int32 operations)
        {
            sortedList1.FromList(list1);
            sortedList2.FromList(list2);
            sortedList1_.FromList(list1);
            sortedList2_.FromList(list2);
            DoTest(operations);
        }

        static void Main(String[] args)
        {
            Double[] needToBeEqual_0 = { 0, 1, 2, 3, 4, 6, 7 };
            Double[] expected_0 = { 0, 1, 2, 3, 4, 5, 6, 7 };
            Test(needToBeEqual_0, expected_0, 1);

            Double[] needToBeEqual_1 = { 0, 1, 2, 3, 4, 6, 7 };
            Double[] expected_1 = { 1, 2, 3, 3 };
            Test(needToBeEqual_1, expected_1, 5);

            Double[] needToBeEqual_2 = { 0 };
            Double[] expected_2 = { 7 };
            Test(needToBeEqual_2, expected_2, 2);

            Double[] needToBeEqual_3 = { 0, 1, 1, 1, 1, 1, 1 };
            Double[] expected_3 = { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            Test(needToBeEqual_3, expected_3, 17);

            Double[] needToBeEqual_4 = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 3 };
            Double[] expected_4 = { 0, 2, 2, 2, 2, 2, 2, 2, 2, 3 };
            Test(needToBeEqual_4, expected_4, 16);

            Double[] needToBeEqual_5 = { 0, 1, 2, 3, 4, 6, 7 };
            Double[] expected_5 = { };
            Test(needToBeEqual_5, expected_5, 7);

            Double[] needToBeEqual_6 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            Double[] expected_6 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Test(needToBeEqual_6, expected_6, 2);

            Double[] needToBeEqual_7 = { 0, 0 };
            Double[] expected_7 = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            Test(needToBeEqual_7, expected_7, 10);

            Double[] needToBeEqual_8 = { 1 };
            Double[] expected_8 = { 0 };
            Test(needToBeEqual_8, expected_8, 2);

            Double[] needToBeEqual_9 = { 1, 2, 3 };
            Double[] expected_9 = { };
            Test(needToBeEqual_9, expected_9, 3);

            Double[] needToBeEqual_10 = { };
            Double[] expected_10 = { 0, 1, 2 };
            Test(needToBeEqual_10, expected_10, 3);

            Double[] needToBeEqual_11 = { };
            Double[] expected_11 = { };
            Test(needToBeEqual_11, expected_11, 0);

            ////limit3
            //Double[] needToBeEqual_12 = { 1, 1, 2 };
            //Double[] expected_12 = { 0, 1, 2 };
            //Test(needToBeEqual_12, expected_12, 2);

            ////limit1
            //Double[] needToBeEqual_13 = { };
            //Double[] expected_13 = { 0 };
            //Test(needToBeEqual_13, expected_13, 1);

            ////limit1
            //Double[] needToBeEqual_14 = { 0};
            //Double[] expected_14 = {  };
            //Test(needToBeEqual_14, expected_14, 1);

            ////limit1
            //Double[] needToBeEqual_15 = { };
            //Double[] expected_15 = { };
            //Test(needToBeEqual_15, expected_15, 0);

        }
    }
}
