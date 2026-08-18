using System;
using System.Collections.Generic;

public class DeliveryAgentRoster
{
	private readonly LinkedList<DeliveryAgent> agents =
		new LinkedList<DeliveryAgent>();


	public int Count
	{
		get
		{
			return agents.Count;
		}
	}


	public void AddAgent(DeliveryAgent agent)
	{
		if (agent == null)
		{
			throw new ArgumentNullException(nameof(agent));
		}

		agents.AddLast(agent);
	}


	public DeliveryAgent GetNextAvailableAgent()
	{
		if (agents.Count == 0)
		{
			throw new InvalidOperationException(
				"No delivery agents are registered."
			);
		}

		LinkedListNode<DeliveryAgent> first =
			agents.First;

		DeliveryAgent agent = first.Value;

		agents.RemoveFirst();

		if (agent.IsAvailable)
		{
			return agent;
		}

		// Rotate unavailable agent to the back.
		agents.AddLast(agent);

		// Try again.
		return GetNextAvailableAgent();
	}


	public void ReturnAgentToBack(
		DeliveryAgent agent)
	{
		agent.IsAvailable = true;

		agents.AddLast(agent);
	}


	public void ReturnAgentToFront(
		DeliveryAgent agent)
	{
		agent.IsAvailable = true;

		agents.AddFirst(agent);
	}


	public void CompleteDelivery(
		DeliveryAgent agent)
	{
		agent.IsAvailable = true;

		agents.AddLast(agent);
	}


	public IEnumerable<DeliveryAgent> GetAgents()
	{
		return agents;
	}
}
