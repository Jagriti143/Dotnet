# QuickBite — Real-Time Food Delivery & Dispatch Engine

## 1. Overview

QuickBite is a food delivery dispatch engine implemented in C# using generic collections, custom generic types, interfaces, comparers, and collection-specific data structures.

The goal is to replace loosely typed collections such as `ArrayList` with strongly typed generic collections that provide better type safety, performance, and maintainability.

---

## 2. Collection Choices

### Repository<T> — Dictionary<int, T>

The generic repository uses:

`Dictionary<int, T>`

The integer entity ID is used as the dictionary key.

This is appropriate because the repository frequently needs to retrieve an entity using its ID.

Average lookup, insertion, update, and removal are O(1).

The repository is constrained using:

`where T : class, IEntity`

This ensures that every stored object is a reference type implementing `IEntity`.

The repository also implements `IEnumerable<T>`, allowing:

`foreach`

to be used directly on a repository.

---

## 3. Restaurant Menu — Dictionary<int, MenuItem>

A restaurant's menu uses:

`Dictionary<int, MenuItem>`

The menu item ID is unique, so it naturally works as a dictionary key.

For example:

`restaurant.Menu[101]`

can directly retrieve menu item 101.

`TryGetValue()` can be used when the item may not exist.

---

## 4. Order Items — List<OrderItem>

An order uses:

`List<OrderItem>`

because an order contains a collection of items and the order of items is not important for lookup.

The collection also allows duplicate menu items if required, although a production implementation could consolidate duplicate items.

---

## 5. Dispatch Queue — Three Queue<Order> Instances

The dispatch engine uses three queues:

* Express orders
* VIP orders
* Normal orders

This design provides FIFO ordering within each priority tier.

When dispatching:

1. Express queue is checked first.
2. VIP queue is checked second.
3. Normal queue is checked last.

`Queue<T>` provides O(1) enqueue and dequeue operations.

This design is simpler and more efficient for the stated requirements than repeatedly sorting all pending orders.

The `OrderPriorityComparer` is still implemented separately for cases such as an administrator dashboard requiring a complete sorted view.

---

## 6. OrderPriorityComparer — IComparer<Order>

`OrderPriorityComparer` implements:

`IComparer<Order>`

Orders are ranked using:

1. Express flag
2. VIP customer
3. Earlier `PlacedAt`
4. Order ID as a final tie-breaker

This allows a collection such as a `List<Order>` to be sorted according to business priority.

The comparer is deliberately separate from the dispatch queue because the queue does not need to sort the entire pending collection for every operation.

---

## 7. Delivery Agent Roster — LinkedList<DeliveryAgent>

Delivery agents are stored in:

`LinkedList<DeliveryAgent>`

The roster behaves like a rotating queue.

The first available agent is removed from the front and returned to the back after completing a delivery.

Operations such as:

* `RemoveFirst()`
* `AddLast()`
* `AddFirst()`

are O(1).

A `List<T>` would be less suitable because removing the first element requires shifting remaining elements.

---

## 8. Undo Dispatch — Stack<DispatchRecord>

Dispatch history uses:

`Stack<DispatchRecord>`

Undo operations naturally follow LIFO behavior.

The most recent dispatch is always the first one that should be undone.

Therefore:

`Push()` records a dispatch.

`Pop()` retrieves the most recent dispatch.

When a dispatch is undone, the order status is changed back to `Queued` and the delivery agent is returned to the front of the roster.

---

## 9. Today's Unique Customers — HashSet<int>

Today's customer IDs are stored in:

`HashSet<int>`

The requirement is to identify unique customers.

A customer may place multiple orders today, but their ID should appear only once.

`HashSet<T>` automatically handles duplicates and provides efficient membership operations.

---

## 10. Low Availability Restaurants — Dictionary<int, int>

The low-availability report returns:

`Dictionary<int, int>`

where:

* Key = Restaurant ID
* Value = Number of menu items

A dictionary is appropriate because the report associates one restaurant ID with one count.

---

## 11. Top Ordered Items — Dictionary + List

The top-item report uses:

`Dictionary<string, int>`

as an accumulator.

The key is the item name and the value is the total quantity ordered.

After aggregation, the dictionary entries are converted into a:

`List<(string ItemName, int TotalOrdered)>`

The list is then sorted by total quantity in descending order and limited to the requested top N results.

This separates two responsibilities:

* Dictionary: fast aggregation
* List: final ordered output

---

## 12. Customer Restaurant History — HashSet<int>

A customer's restaurant history is represented using:

`HashSet<int>`

Each restaurant ID is stored only once, even if the customer placed multiple orders at the same restaurant.

To determine whether the customer ordered from both requested restaurants, another set containing the two restaurant IDs is created.

`IsSubsetOf()` is then used to determine whether both restaurants exist in the customer's history.

---

## 13. Why Generic Collections?

Generic collections provide:

* Compile-time type safety
* No unnecessary boxing/unboxing
* Better performance
* Clearer code
* Reusable components
* Stronger APIs

Instead of:

`ArrayList`

the application uses strongly typed collections such as:

* `List<T>`
* `Dictionary<TKey,TValue>`
* `Queue<T>`
* `Stack<T>`
* `HashSet<T>`
* `LinkedList<T>`

---

## 14. Overall Architecture

The major flow is:

Customer → Order → DispatchQueue → DeliveryAgent → Delivered

The repository layer manages persistent-style entity lookup:

Restaurant Repository
Customer Repository
Order Repository

The dispatch engine coordinates the operational workflow while specialized collections handle the individual responsibilities.

---

## 15. Complexity Summary

| Responsibility         | Collection               | Main Operation        | Typical Complexity |
| ---------------------- | ------------------------ | --------------------- | ------------------ |
| Entity lookup          | Dictionary<int,T>        | GetById               | O(1) average       |
| Restaurant menu lookup | Dictionary<int,MenuItem> | Find item             | O(1) average       |
| Order items            | List<OrderItem>          | Add                   | O(1) amortized     |
| Dispatch               | Queue<Order>             | Enqueue/Dequeue       | O(1)               |
| Agent rotation         | LinkedList<T>            | Front/back operations | O(1)               |
| Undo                   | Stack<T>                 | Push/Pop              | O(1)               |
| Unique customers       | HashSet<int>             | Add/lookup            | O(1) average       |
| Item aggregation       | Dictionary<string,int>   | Accumulate            | O(1) average       |
| Final top-N ranking    | List<T>                  | Sort                  | O(n log n)         |
| Priority dashboard     | List + IComparer         | Sort                  | O(n log n)         |

---

## 16. Key Design Principle

The application does not use `List<T>` for everything.

Each collection is selected according to the operation that the application performs most frequently.

The design therefore demonstrates not only how to use C# collections, but also how to choose the appropriate data structure for a real backend problem.

