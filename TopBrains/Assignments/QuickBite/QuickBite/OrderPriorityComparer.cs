using System;
using System.Collections.Generic;

public class OrderPriorityComparer :
	IComparer<Order>
{
	public int Compare(
		Order x,
		Order y)
	{
		if (ReferenceEquals(x, y))
		{
			return 0;
		}

		if (x == null)
		{
			return 1;
		}

		if (y == null)
		{
			return -1;
		}


		// ----------------------------------------------------
		// 1. Express orders first
		// ----------------------------------------------------

		int expressComparison =
			y.IsExpress.CompareTo(x.IsExpress);

		if (expressComparison != 0)
		{
			return expressComparison;
		}


		// ----------------------------------------------------
		// 2. VIP customers first
		// ----------------------------------------------------

		int vipComparison =
			y.Customer.IsVip.CompareTo(
				x.Customer.IsVip
			);

		if (vipComparison != 0)
		{
			return vipComparison;
		}


		// ----------------------------------------------------
		// 3. Earlier orders first
		// ----------------------------------------------------

		int placedComparison =
			x.PlacedAt.CompareTo(y.PlacedAt);

		if (placedComparison != 0)
		{
			return placedComparison;
		}


		// ----------------------------------------------------
		// Final tie-breaker
		// ----------------------------------------------------

		return x.Id.CompareTo(y.Id);
	}
}
