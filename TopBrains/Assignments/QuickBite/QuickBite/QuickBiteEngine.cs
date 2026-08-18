using System;
using System.Collections.Generic;
using System.Linq;

public class QuickBiteEngine
{
	public Repository<Restaurant> Restaurants { get; }

	public Repository<Customer> Customers { get; }

	public Repository<Order> Orders { get; }

	public DispatchQueue DispatchQueue { get; }

	public DeliveryAgentRoster AgentRoster { get; }

	private readonly Stack<DispatchRecord> dispatchHistory;

	private readonly int maxDispatchHistory;


	public QuickBiteEngine(
		int maxDispatchHistory = 10)
	{
		if (maxDispatchHistory <= 0)
		{
			throw new ArgumentException(
				"History size must be greater than zero."
			);
		}

		Restaurants =
			new Repository<Restaurant>();

		Customers =
			new Repository<Customer>();

		Orders =
			new Repository<Order>();

		DispatchQueue =
			new DispatchQueue();

		AgentRoster =
			new DeliveryAgentRoster();

		dispatchHistory =
			new Stack<DispatchRecord>();

		this.maxDispatchHistory =
			maxDispatchHistory;
	}


	// ========================================================
	// Place Order
	// ========================================================

	public void PlaceOrder(Order order)
	{
		if (order == null)
		{
			throw new ArgumentNullException(nameof(order));
		}

		if (!order.Restaurant.IsOpen)
		{
			throw new InvalidOperationException(
				$"Restaurant {order.Restaurant.Name} is closed."
			);
		}

		if (order.Items.Count == 0)
		{
			throw new InvalidOperationException(
				"An order must contain at least one item."
			);
		}

		Orders.Add(order);

		DispatchQueue.Enqueue(order);
	}


	// ========================================================
	// Dispatch
	// ========================================================

	public DispatchRecord DispatchNext()
	{
		Order order =
			DispatchQueue.DispatchNext();

		DeliveryAgent agent;

		try
		{
			agent =
				AgentRoster.GetNextAvailableAgent();
		}
		catch
		{
			// Put the order back into queued state.
			order.Status = OrderStatus.Queued;

			throw;
		}

		agent.IsAvailable = false;

		DispatchRecord record =
			new DispatchRecord(
				order,
				agent,
				DateTime.Now
			);

		dispatchHistory.Push(record);

		if (dispatchHistory.Count > maxDispatchHistory)
		{
			RemoveOldestDispatchRecord();
		}

		return record;
	}


	// ========================================================
	// Remove oldest history item
	// ========================================================

	private void RemoveOldestDispatchRecord()
	{
		if (dispatchHistory.Count == 0)
		{
			return;
		}

		DispatchRecord[] records =
			dispatchHistory.ToArray();

		dispatchHistory.Clear();

		for (int i = records.Length - 2;
			 i >= 0;
			 i--)
		{
			dispatchHistory.Push(records[i]);
		}
	}


	// ========================================================
	// Undo Last Dispatch
	// ========================================================

	public DispatchRecord UndoLastDispatch()
	{
		if (dispatchHistory.Count == 0)
		{
			throw new InvalidOperationException(
				"There is no dispatch to undo."
			);
		}

		DispatchRecord record =
			dispatchHistory.Pop();

		record.Order.Status =
			OrderStatus.Queued;

		// Return agent to the front so the agent who was
		// just involved becomes next available.
		AgentRoster.ReturnAgentToFront(
			record.Agent
		);

		// Put the order back into the appropriate queue.
		DispatchQueue.Enqueue(
			record.Order
		);

		return record;
	}


	// ========================================================
	// Complete Delivery
	// ========================================================

	public void CompleteDelivery(
		Order order,
		DeliveryAgent agent)
	{
		if (order.Status != OrderStatus.Dispatched)
		{
			throw new InvalidOperationException(
				"Only dispatched orders can be delivered."
			);
		}

		if (agent == null)
		{
			throw new ArgumentNullException(nameof(agent));
		}

		order.Status =
			OrderStatus.Delivered;

		AgentRoster.CompleteDelivery(agent);
	}


	// ========================================================
	// Today's Unique Customers
	// ========================================================

	public HashSet<int> TodaysUniqueCustomerIds()
	{
		HashSet<int> customerIds =
			new HashSet<int>();

		DateTime today =
			DateTime.Today;

		foreach (Order order in Orders)
		{
			if (order.PlacedAt.Date == today)
			{
				customerIds.Add(
					order.Customer.Id
				);
			}
		}

		return customerIds;
	}


	// ========================================================
	// Low Availability Restaurants
	// ========================================================

	public Dictionary<int, int>
		LowAvailabilityRestaurants(
			int minMenuItems)
	{
		Dictionary<int, int> result =
			new Dictionary<int, int>();

		foreach (Restaurant restaurant in Restaurants)
		{
			if (restaurant.Menu.Count < minMenuItems)
			{
				result[restaurant.Id] =
					restaurant.Menu.Count;
			}
		}

		return result;
	}


	// ========================================================
	// Top Ordered Items
	// ========================================================

	public List<(string ItemName, int TotalOrdered)>
		TopOrderedItems(int topN)
	{
		if (topN <= 0)
		{
			return new List<
				(string ItemName, int TotalOrdered)
			>();
		}

		Dictionary<string, int> totals =
			new Dictionary<string, int>(
				StringComparer.OrdinalIgnoreCase
			);

		foreach (Order order in Orders)
		{
			if (order.Status == OrderStatus.Cancelled)
			{
				continue;
			}

			foreach (OrderItem item in order.Items)
			{
				if (totals.TryGetValue(
					item.MenuItem.Name,
					out int current))
				{
					totals[item.MenuItem.Name] =
						current + item.Quantity;
				}
				else
				{
					totals[item.MenuItem.Name] =
						item.Quantity;
				}
			}
		}

		List<(string ItemName, int TotalOrdered)> result =
			totals
				.Select(
					pair =>
						(
							ItemName: pair.Key,
							TotalOrdered: pair.Value
						)
				)
				.OrderByDescending(
					pair => pair.TotalOrdered
				)
				.ThenBy(
					pair => pair.ItemName
				)
				.Take(topN)
				.ToList();

		return result;
	}


	// ========================================================
	// Customer ordered from both restaurants
	// ========================================================

	public bool CustomerOrderedFromBothRestaurants(
		int customerId,
		int restaurantIdA,
		int restaurantIdB)
	{
		HashSet<int> restaurantHistory =
			new HashSet<int>();

		foreach (Order order in Orders)
		{
			if (order.Customer.Id == customerId)
			{
				restaurantHistory.Add(
					order.Restaurant.Id
				);
			}
		}

		HashSet<int> requiredRestaurants =
			new HashSet<int>
			{
				restaurantIdA,
				restaurantIdB
			};

		return requiredRestaurants.IsSubsetOf(
			restaurantHistory
		);
	}


	// ========================================================
	// Admin Dashboard Priority View
	// ========================================================

	public List<Order> GetPendingOrdersPriorityView()
	{
		List<Order> pending =
			DispatchQueue
				.GetPendingOrders()
				.ToList();

		pending.Sort(
			new OrderPriorityComparer()
		);

		return pending;
	}
}
