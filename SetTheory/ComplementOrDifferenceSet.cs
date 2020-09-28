using SetTheory;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class ComplementOrDifferenceSet
{
	private RangeSet LowerValues;
    private HashedSet MiddleValues;
	private RangeSet UpperValues;


	public ComplementOrDifferenceSet(RangeSet lowerValues, HashedSet middleValues, RangeSet upperValues)
    {
        LowerValues = lowerValues;
        MiddleValues = middleValues;
        UpperValues = upperValues;
    }


}
