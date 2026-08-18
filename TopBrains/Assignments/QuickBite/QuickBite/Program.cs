using System;

class Program
{
	static void Main()
	{
		Console.WriteLine(
			"=============================================="
		);

		Console.WriteLine(
			"       QUICKBITE DISPATCH ENGINE"
		);

		Console.WriteLine(
			"=============================================="
		);


		QuickBiteEngine engine =
			new QuickBiteEngine(
				maxDispatchHistory: 5
			);


		// ====================================================
		// RESTAURANTS
		// ====================================================

		Restaurant pizzaHouse =
			new Restaurant(
				1,
				"Pizza House"
			);

		pizzaHouse.AddMenuItem(
			new MenuItem(
				101,
				"Margherita Pizza",
				299
			)
		);

		pizzaHouse.AddMenuItem(
			new MenuItem(
				102,
				"Farmhouse Pizza",
				399
			)
		);

		pizzaHouse.AddMenuItem(
			new MenuItem(
				103,
				"Garlic Bread",
				149
			)
		);


		Restaurant burgerPoint =
			new Restaurant(
				2,
				"Burger Point"
			);

		burgerPoint.AddMenuItem(
			new MenuItem(
				201,
				"Classic Burger",
				199
			)
		);

		burgerPoint.AddMenuItem(
			new MenuItem(
				202,
				"Cheese Burger",
				249
			)
		);


		Restaurant smallCafe =
			new Restaurant(
				3,
				"Small Cafe"
			);

		smallCafe.AddMenuItem(
			new MenuItem(
				301,
				"Coffee",
				99
			)
		);


		engine.Restaurants.Add(
			pizzaHouse
		);

		engine.Restaurants.Add(
			burgerPoint
		);

		engine.Restaurants.Add(
			smallCafe
		);


		// ====================================================
		// CUSTOMERS
		// ====================================================

		Customer jagriti =
			new Customer(
				1,
				"Jagriti",
				false
			);

		Customer rahul =
			new Customer(
				2,
				"Rahul",
				true
			);

		Customer priya =
			new Customer(
				3,
				"Priya",
				false
			);


		engine.Customers.Add(jagriti);
		engine.Customers.Add(rahul);
		engine.Customers.Add(priya);


		// ====================================================
		// DELIVERY AGENTS
		// ====================================================

		DeliveryAgent agent1 =
			new DeliveryAgent(
				1,
				"Amit"
			);

		DeliveryAgent agent2 =
			new DeliveryAgent(
				2,
				"Rohit"
			);

		DeliveryAgent agent3 =
			new DeliveryAgent(
				3,
				"Neeraj"
			);


		engine.AgentRoster.AddAgent(agent1);
		engine.AgentRoster.AddAgent(agent2);
		engine.AgentRoster.AddAgent(agent3);


		// ====================================================
		// ORDERS
		// ====================================================

		DateTime now = DateTime.Now;


		// Normal order
		Order order1 =
			new Order(
				1001,
				jagriti,
				pizzaHouse,
				now.AddMinutes(-20),
				false
			);

		order1.AddItem(
			pizzaHouse.Menu[101],
			2
		);

		order1.AddItem(
			pizzaHouse.Menu[103],
			1
		);


		// VIP order
		Order order2 =
			new Order(
				1002,
				rahul,
				burgerPoint,
				now.AddMinutes(-15),
				false
			);

		order2.AddItem(
			burgerPoint.Menu[201],
			2
		);


		// Express order
		Order order3 =
			new Order(
				1003,
				priya,
				pizzaHouse,
				now.AddMinutes(-10),
				true
			);

		order3.AddItem(
			pizzaHouse.Menu[102],
			1
		);


		// Another normal order
		Order order4 =
			new Order(
				1004,
				jagriti,
				burgerPoint,
				now.AddMinutes(-5),
				false
			);

		order4.AddItem(
			burgerPoint.Menu[202],
			1
		);


		engine.PlaceOrder(order1);
		engine.PlaceOrder(order2);
		engine.PlaceOrder(order3);
		engine.PlaceOrder(order4);


		// ====================================================
		// DISPLAY PRIORITY ORDER
		// ====================================================

		Console.WriteLine(
			"\n--- Pending Orders: Priority View ---"
		);

		foreach (
			Order order
			in engine.GetPendingOrdersPriorityView())
		{
			Console.WriteLine(order);
		}


		// ====================================================
		// DISPATCH
		// ====================================================

		Console.WriteLine(
			"\n--- Dispatching Orders ---"
		);


		DispatchRecord dispatch1 =
			engine.DispatchNext();

		Console.WriteLine(dispatch1);


		DispatchRecord dispatch2 =
			engine.DispatchNext();

		Console.WriteLine(dispatch2);


		// ====================================================
		// UNDO LAST DISPATCH
		// ====================================================

		Console.WriteLine(
			"\n--- Undo Last Dispatch ---"
		);

		DispatchRecord undone =
			engine.UndoLastDispatch();

		Console.WriteLine(
			$"Undone: {undone}"
		);

		Console.WriteLine(
			$"Order #{undone.Order.Id} status: " +
			$"{undone.Order.Status}"
		);


		// ====================================================
		// DISPATCH AGAIN
		// ====================================================

		Console.WriteLine(
			"\n--- Dispatch After Undo ---"
		);

		DispatchRecord dispatch3 =
			engine.DispatchNext();

		Console.WriteLine(dispatch3);


		// ====================================================
		// COMPLETE DELIVERY
		// ====================================================

		Console.WriteLine(
			"\n--- Completing Delivery ---"
		);

		engine.CompleteDelivery(
			dispatch3.Order,
			dispatch3.Agent
		);

		Console.WriteLine(
			$"Order #{dispatch3.Order.Id}: " +
			$"{dispatch3.Order.Status}"
		);


		// ====================================================
		// TODAY'S UNIQUE CUSTOMERS
		// ====================================================

		Console.WriteLine(
			"\n--- Today's Unique Customers ---"
		);

		var customerIds =
			engine.TodaysUniqueCustomerIds();

		foreach (int id in customerIds)
		{
			Console.WriteLine(
				$"Customer ID: {id}"
			);
		}


		// ====================================================
		// LOW AVAILABILITY RESTAURANTS
		// ====================================================

		Console.WriteLine(
			"\n--- Low Availability Restaurants ---"
		);

		var lowRestaurants =
			engine.LowAvailabilityRestaurants(
				minMenuItems: 3
			);

		foreach (
			var restaurant
			in lowRestaurants)
		{
			Console.WriteLine(
				$"Restaurant #{restaurant.Key} " +
				$"has {restaurant.Value} menu items."
			);
		}


		// ====================================================
		// TOP ORDERED ITEMS
		// ====================================================

		Console.WriteLine(
			"\n--- Top Ordered Items ---"
		);

		var topItems =
			engine.TopOrderedItems(5);

		foreach (var item in topItems)
		{
			Console.WriteLine(
				$"{item.ItemName}: " +
				$"{item.TotalOrdered} ordered"
			);
		}


		// ====================================================
		// BOTH RESTAURANTS
		// ====================================================

		Console.WriteLine(
			"\n--- Customer Restaurant History ---"
		);

		bool orderedBoth =
			engine.CustomerOrderedFromBothRestaurants(
				customerId: 1,
				restaurantIdA: 1,
				restaurantIdB: 2
			);

		Console.WriteLine(
			$"Did Jagriti order from both " +
			$"Pizza House and Burger Point? " +
			$"{orderedBoth}"
		);


		// ====================================================
		// REPOSITORY FOREACH
		// ====================================================

		Console.WriteLine(
			"\n--- Restaurants From Generic Repository ---"
		);

		foreach (
			Restaurant restaurant
			in engine.Restaurants)
		{
			Console.WriteLine(restaurant);
		}


		Console.WriteLine(
			"\n=============================================="
		);

		Console.WriteLine(
			"        QUICKBITE DEMO COMPLETED"
		);

		Console.WriteLine(
			"=============================================="
		);
	}
}
