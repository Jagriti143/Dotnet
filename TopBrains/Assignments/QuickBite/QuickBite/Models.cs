using System;
using System.Collections.Generic;
using QuickBite;

public enum OrderStatus
{
	Placed,
	Queued,
	Dispatched,
	Delivered,
	Cancelled
}


// ============================================================
// MenuItem
// ============================================================

public class MenuItem : IEntity
{
	public int Id { get; }

	public string Name { get; set; }

	public decimal Price { get; set; }

	public MenuItem(int id, string name, decimal price)
	{
		Id = id;
		Name = name;
		Price = price;
	}

	public override string ToString()
	{
		return $"{Id}: {Name} - ₹{Price:F2}";
	}
}


// ============================================================
// Restaurant
// ============================================================

public class Restaurant : IEntity
{
	public int Id { get; }

	public string Name { get; set; }

	public bool IsOpen { get; set; }

	// Dictionary is appropriate because MenuItem IDs are unique
	// and we frequently need to find an item by ID.
	public Dictionary<int, MenuItem> Menu { get; }

	public Restaurant(
		int id,
		string name,
		bool isOpen = true)
	{
		Id = id;
		Name = name;
		IsOpen = isOpen;

		Menu = new Dictionary<int, MenuItem>();
	}

	public void AddMenuItem(MenuItem item)
	{
		Menu[item.Id] = item;
	}

	public bool RemoveMenuItem(int menuItemId)
	{
		return Menu.Remove(menuItemId);
	}

	public bool TryGetMenuItem(
		int menuItemId,
		out MenuItem item)
	{
		return Menu.TryGetValue(
			menuItemId,
			out item
		);
	}

	public override string ToString()
	{
		return $"{Id}: {Name} | Open: {IsOpen} | Menu items: {Menu.Count}";
	}
}


// ============================================================
// Customer
// ============================================================

public class Customer : IEntity
{
	public int Id { get; }

	public string Name { get; set; }

	public bool IsVip { get; set; }

	public Customer(
		int id,
		string name,
		bool isVip = false)
	{
		Id = id;
		Name = name;
		IsVip = isVip;
	}

	public override string ToString()
	{
		return $"{Id}: {Name} | VIP: {IsVip}";
	}
}


// ============================================================
// OrderItem
// ============================================================

public class OrderItem
{
	public MenuItem MenuItem { get; }

	public int Quantity { get; set; }

	public OrderItem(
		MenuItem menuItem,
		int quantity)
	{
		if (quantity <= 0)
		{
			throw new ArgumentException(
				"Quantity must be greater than zero."
			);
		}

		MenuItem = menuItem;
		Quantity = quantity;
	}

	public decimal LineTotal
	{
		get
		{
			return MenuItem.Price * Quantity;
		}
	}

	public override string ToString()
	{
		return $"{MenuItem.Name} x {Quantity}";
	}
}


// ============================================================
// Order
// ============================================================

public class Order : IEntity
{
	public int Id { get; }

	public Customer Customer { get; }

	public Restaurant Restaurant { get; }

	public List<OrderItem> Items { get; }

	public DateTime PlacedAt { get; }

	public bool IsExpress { get; }

	public OrderStatus Status { get; set; }

	public Order(
		int id,
		Customer customer,
		Restaurant restaurant,
		DateTime placedAt,
		bool isExpress)
	{
		Id = id;
		Customer = customer;
		Restaurant = restaurant;
		PlacedAt = placedAt;
		IsExpress = isExpress;

		Items = new List<OrderItem>();

		Status = OrderStatus.Placed;
	}

	public void AddItem(
		MenuItem menuItem,
		int quantity)
	{
		Items.Add(
			new OrderItem(menuItem, quantity)
		);
	}

	public decimal Total
	{
		get
		{
			decimal total = 0;

			foreach (OrderItem item in Items)
			{
				total += item.LineTotal;
			}

			return total;
		}
	}

	public override string ToString()
	{
		string priority;

		if (IsExpress)
		{
			priority = "EXPRESS";
		}
		else if (Customer.IsVip)
		{
			priority = "VIP";
		}
		else
		{
			priority = "NORMAL";
		}

		return
			$"Order #{Id} | Customer: {Customer.Name} | " +
			$"Restaurant: {Restaurant.Name} | " +
			$"Priority: {priority} | " +
			$"Status: {Status} | " +
			$"Placed: {PlacedAt:HH:mm:ss}";
	}
}


// ============================================================
// DeliveryAgent
// ============================================================

public class DeliveryAgent
{
	public int Id { get; }

	public string Name { get; }

	public bool IsAvailable { get; set; }

	public DeliveryAgent(
		int id,
		string name)
	{
		Id = id;
		Name = name;
		IsAvailable = true;
	}

	public override string ToString()
	{
		return $"{Id}: {Name} | Available: {IsAvailable}";
	}
}
