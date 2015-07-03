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

        //static Processor diffProcessor = new Processor(8);
        //static SortedLimitedList<Double> sortedList1 = new SortedLimitedList<Double>(10);
        //static SortedLimitedList<Double> sortedList2 = new SortedLimitedList<Double>(10);
        //static SortedLimitedList<Double> sortedList1_ = new SortedLimitedList<Double>(10);
        //static SortedLimitedList<Double> sortedList2_ = new SortedLimitedList<Double>(10);

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

            //Double[] needToBeEqual_9 = {-1, 0, 1, 3, 3, 4, 6, 7, 8 };
            //Double[] expected_9 = { 0, 1, 2, 4, 5, 6, 7 };

            //Double[] needToBeEqual_9 = {  1};
            //Double[] expected_9 = { 1, 1, 1, 1 };


            //SortedLimitedList<Double> list9=new SortedLimitedList<double>(10);
            //SortedLimitedList<Double> expectedList9 = new SortedLimitedList<double>(10);
            //list9.FromArray(needToBeEqual_9);
            //expectedList9.FromArray(expected_9);
            //Console.WriteLine(diffProcessor.Contains(list9, 3));
            //Console.WriteLine(diffProcessor.Contains(list9, 33));
            //diffProcessor.DeleteElementsNotExistingInEtalon(list9, expectedList9);
            //Console.WriteLine(list9.ToString());
            //Console.WriteLine(expectedList9.ToString());
        }
    }
}
