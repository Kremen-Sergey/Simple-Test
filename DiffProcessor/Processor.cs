using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiffProcessor
{
	public class Processor
	{
		public Processor(long limit)
		{
			// TODO: initialize.
		    this.limit = limit;
		}

	    private long limit;
		public void DoProcess(SortedLimitedList<Double> mustBeEqualTo, SortedLimitedList<Double> expectedOutput)
		{
		    if ((limit != mustBeEqualTo.Limit) || (limit != expectedOutput.Limit))
		    {
		        throw new ArgumentException("Processor and both collections must have same limit");
		    }
			// TODO: make "mustBeEqualTo" list equal to "expectedOutput".
			// 0. Processor will be created once and then will be used billion times. 
			// 1. Use methods: AddFirst, AddLast, AddBefore, AddAfter, Remove to modify list.
			// 2. Do not change expectedOutput list.
			// 3. At any time number of elements in list could not exceed the "Limit". 
			// 4. "Limit" will be passed into Processor's constructor. All "mustBeEqualTo" and "expectedOutput" lists will have the same "Limit" value.
			// 5. At any time list elements must be in non-descending order.
			// 6. Implementation must perform minimal possible number of actions (AddFirst, AddLast, AddBefore, AddAfter, Remove).
			// 7. Implementation must be fast and do not allocate excess memory.

            SortedLimitedList<Double>.Entry current1 = mustBeEqualTo.First;
            SortedLimitedList<Double>.Entry current2 = expectedOutput.First;
            SortedLimitedList<Double>.Entry temp;
		    if ((mustBeEqualTo.Limit == 1) && (expectedOutput.First != mustBeEqualTo.First))
		    {
		        mustBeEqualTo.Remove(mustBeEqualTo.First);
                mustBeEqualTo.AddFirst(expectedOutput.First.Value);
		    }
            while ((current1 != null)&&(current2!=null))
            {  
                if (current1.Value.CompareTo(current2.Value) == 0)
                {
                    current1 = current1.Next;
                    current2 = current2.Next;
                    continue;
                }
                if (current1.Value.CompareTo(current2.Value) < 0)
                {
                    temp = current1;
                    current1 = current1.Next;
                    mustBeEqualTo.Remove(temp);
                    continue;
                }
                if (current1.Value.CompareTo(current2.Value) > 0)
                {
                    if (mustBeEqualTo.Count == mustBeEqualTo.Limit)
                    {
                        if (current1 == mustBeEqualTo.Last)
                        {
                            current1 = current1.Previous;
                            mustBeEqualTo.Remove(mustBeEqualTo.Last);
                            mustBeEqualTo.AddAfter(current1, current2.Value);
                            current1 = current1.Next.Next;
                            current2 = current2.Next;
                            continue;
                        }
                        else
                        {
                            mustBeEqualTo.Remove(mustBeEqualTo.Last);
                            mustBeEqualTo.AddBefore(current1, current2.Value);
                            current2 = current2.Next;
                        }
                    }
                    else
                    {
                        mustBeEqualTo.AddBefore(current1, current2.Value);
                        current2 = current2.Next;
                    }
                }
            }
		    if ((current1 == null) && (current2 != null))
		    {
		        while (current2!=null)
		        {
                    mustBeEqualTo.AddLast(current2.Value);
		            current2 = current2.Next;
		        }
		    }
            if ((current1 != null) && (current2 == null))
            {
                while (current1 != null)
                {
                    temp = current1;
                    current1 = current1.Next;
                    mustBeEqualTo.Remove(temp);
                }
            }
        }
	}
}
