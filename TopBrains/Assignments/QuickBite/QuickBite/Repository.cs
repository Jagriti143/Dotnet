using System;
using System.Collections;
using System.Collections.Generic;
using QuickBite;

public class Repository<T> :
	IEnumerable<T>
	where T : class, IEntity
{
	private readonly Dictionary<int, T> entities =
		new Dictionary<int, T>();


	// ========================================================
	// Add
	// ========================================================

	public void Add(T entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException(nameof(entity));
		}

		if (entities.ContainsKey(entity.Id))
		{
			throw new InvalidOperationException(
				$"Entity with ID {entity.Id} already exists."
			);
		}

		entities.Add(entity.Id, entity);
	}


	// ========================================================
	// Update
	// ========================================================

	public void Update(T entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException(nameof(entity));
		}

		if (!entities.ContainsKey(entity.Id))
		{
			throw new KeyNotFoundException(
				$"Entity with ID {entity.Id} was not found."
			);
		}

		entities[entity.Id] = entity;
	}


	// ========================================================
	// Remove
	// ========================================================

	public bool Remove(int id)
	{
		return entities.Remove(id);
	}


	// ========================================================
	// GetById
	// ========================================================

	public T GetById(int id)
	{
		if (entities.TryGetValue(id, out T entity))
		{
			return entity;
		}

		throw new KeyNotFoundException(
			$"Entity with ID {id} was not found."
		);
	}


	// ========================================================
	// TryGetById
	// ========================================================

	public bool TryGetById(
		int id,
		out T entity)
	{
		return entities.TryGetValue(
			id,
			out entity
		);
	}


	// ========================================================
	// GetAll
	// ========================================================

	public IEnumerable<T> GetAll()
	{
		return entities.Values;
	}


	// ========================================================
	// IEnumerable<T>
	// ========================================================

	public IEnumerator<T> GetEnumerator()
	{
		return entities.Values.GetEnumerator();
	}


	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}


	public int Count
	{
		get
		{
			return entities.Count;
		}
	}
}
