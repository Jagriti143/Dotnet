using System;
using System.Collections.Generic;

public class DispatchQueue
{
	private readonly Queue<Order> expressQueue =
		new Queue<Order>();

	private readonly Queue<Order> vipQueue =
		new Queue<Order>();

	private readonly Queue<Order> normalQueue =
		new Queue<Order>();


	public int Count
	{
		get
		{
			return
				expressQueue.Count +
				vipQueue.Count +
				normalQueue.Count;
		}
	}


	public void Enqueue(Order order)
	{
		if (order == null)
		{
			throw new ArgumentNullException(nameof(order));
		}

		order.Status = OrderStatus.Queued;

		if (order.IsExpress)
		{
			expressQueue.Enqueue(order);
		}
		else if (order.Customer.IsVip)
		{
			vipQueue.Enqueue(order);
		}
		else
		{
			normalQueue.Enqueue(order);
		}
	}


	public Order DispatchNext()
	{
		Order order;

		if (expressQueue.Count > 0)
		{
			order = expressQueue.Dequeue();
		}
		else if (vipQueue.Count > 0)
		{
			order = vipQueue.Dequeue();
		}
		else if (normalQueue.Count > 0)
		{
			order = normalQueue.Dequeue();
		}
		else
		{
			throw new InvalidOperationException(
				"There are no orders waiting for dispatch."
			);
		}

		order.Status = OrderStatus.Dispatched;

		return order;
	}


	public IEnumerable<Order> GetPendingOrders()
	{
		foreach (Order order in expressQueue)
		{
			yield return order;
		}

		foreach (Order order in vipQueue)
		{
			yield return order;
		}

		foreach (Order order in normalQueue)
		{
			yield return order;
		}
	}
}
