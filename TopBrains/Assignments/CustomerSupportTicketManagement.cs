using System;

class Ticket
{
    public int Id;
    public string CustomerName;
    public string IssueType;
    public string Status;

    public Ticket(int id, string customerName, string issueType)
    {
        Id = id;
        CustomerName = customerName;
        IssueType = issueType;
        Status = "Pending";
    }
}

class TicketQueue
{
    private Ticket[] queue;
    private int front;
    private int rear;
    private int count;

    public TicketQueue(int size)
    {
        queue = new Ticket[size];
        front = 0;
        rear = -1;
        count = 0;
    }


    public void Enqueue(Ticket ticket)
    {
        if (count == queue.Length)
        {
            Console.WriteLine("Queue Overflow!");
            return;
        }

        rear++;
        queue[rear] = ticket;
        count++;

        Console.WriteLine($"Ticket {ticket.Id} added.");
    }

    
    public void DisplayTickets()
    {
        Console.WriteLine("\nAll Tickets:");

        if (count == 0)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        for (int i = front; i <= rear; i++)
        {
            Console.WriteLine(
                $"ID: {queue[i].Id}, Customer: {queue[i].CustomerName}, Issue: {queue[i].IssueType}, Status: {queue[i].Status}");
        }
    }

   
    public Ticket Dequeue()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue Underflow!");
            return null;
        }

        Ticket ticket = queue[front];
        ticket.Status = "Processed";

        front++;
        count--;

        Console.WriteLine($"\nProcessed Ticket ID: {ticket.Id}");
        return ticket;
    }

    
    public void Peek()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        Console.WriteLine(
            $"\nNext Ticket: ID {queue[front].Id}, Customer {queue[front].CustomerName}");
    }

  
    public void QueueCount()
    {
        Console.WriteLine($"\nTotal Tickets: {count}");
    }

   
    public void SearchTicket(int id)
    {
        for (int i = front; i <= rear; i++)
        {
            if (queue[i].Id == id)
            {
                Console.WriteLine(
                    $"\nTicket Found: ID {queue[i].Id}, Customer {queue[i].CustomerName}");
                return;
            }
        }

        Console.WriteLine("\nTicket Not Found.");
    }

    
    public void CountByIssueType(string issueType)
    {
        int total = 0;

        for (int i = front; i <= rear; i++)
        {
            if (queue[i].IssueType.Equals(issueType,
                StringComparison.OrdinalIgnoreCase))
            {
                total++;
            }
        }

        Console.WriteLine($"\n{issueType}: {total} ticket(s)");
    }

  
    public void RemoveProcessedTickets()
    {
        Ticket[] temp = new Ticket[queue.Length];
        int index = 0;

        for (int i = front; i <= rear; i++)
        {
            if (queue[i].Status != "Processed")
            {
                temp[index++] = queue[i];
            }
        }

        queue = temp;
        front = 0;
        rear = index - 1;
        count = index;

        Console.WriteLine("\nProcessed tickets removed.");
    }
}

class Program
{
    static void Main()
    {
        TicketQueue supportQueue = new TicketQueue(10);

      
        supportQueue.Enqueue(new Ticket(101, "Rahul", "Login"));
        supportQueue.Enqueue(new Ticket(102, "Priya", "Payment"));
        supportQueue.Enqueue(new Ticket(103, "Amit", "Login"));

        supportQueue.DisplayTickets();

        supportQueue.Peek();

        supportQueue.QueueCount();

        supportQueue.SearchTicket(102);

        supportQueue.CountByIssueType("Login");

        supportQueue.Dequeue();

        supportQueue.DisplayTickets();

        supportQueue.RemoveProcessedTickets();

        supportQueue.DisplayTickets();
    }
}