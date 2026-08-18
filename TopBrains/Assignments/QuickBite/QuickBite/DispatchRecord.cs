using System;

public class DispatchRecord
{
	public Order Order { get; }

	public DeliveryAgent Agent { get; }

	public DateTime DispatchedAt { get; }

	public DispatchRecord(
		Order order,
		DeliveryAgent agent,
		DateTime dispatchedAt)
	{
		Order = order;
		Agent = agent;
		DispatchedAt = dispatchedAt;
	}

	public override string ToString()
	{
		return
			$"Order #{Order.Id} → {Agent.Name} " +
			$"at {DispatchedAt:HH:mm:ss}";
	}
}
