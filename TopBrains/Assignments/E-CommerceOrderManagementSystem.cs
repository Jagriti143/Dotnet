using System;
public class Program
{
    public static void Main(string[] args)
    {
        string[] orders =
        {
            "ORD1001|John Smith|Laptop|2|$1200|Delivered",
            "ORD1002|Alice Brown|Mobile|1|$800|Pending",
            "ORD1003|David Wilson|Keyboard|3|$150|Shipped",
            "ORD1004|Emma Davis|Monitor|2|$350|Delivered",
            "ORD1005|James Miller|Mouse|5|$50|Pending"
        };

        //Display all orders
        foreach (string order in orders)
        {
            string[] details = order.Split('|');

            Console.WriteLine($"Order ID : {details[0]}");
            Console.WriteLine($"Customer : {details[1]}");
            Console.WriteLine($"Product  : {details[2]}");
            Console.WriteLine($"Quantity : {details[3]}");
            Console.WriteLine($"Price    : {details[4]}");
            Console.WriteLine($"Status   : {details[5]}");
            Console.WriteLine();
        
        }

        //display names in uppercase
        foreach(string order in orders)
        {
            string[] upper=order.Split('|');
            Console.WriteLine(upper[1].ToUpper());
        }

        //Display first letters of names
        foreach(string order in orders)
        {
            string[] first=order.Split('|');
            string[] name=first[1].Split(' ');
            Console.WriteLine(first[1]+"->"+ name[0][0]+name[1][0]);

        }

        //Display Delivered orders
        foreach(string order in orders)
        {
            string[] data=order.Split('|');
            if (order.EndsWith("Delivered"))
            {
                Console.WriteLine($"{data[0]}");
            }
        }

        //Display total order count
        int cnt=0;
        foreach(string order in orders)
        {
            cnt++;
        }
        Console.WriteLine($"Total Orders= {cnt}");


        //Search order by ID
        string id=Console.ReadLine();
        bool found=false;
        foreach(string order in orders)
        {
            string[] data=order.Split('|');
            if (data[0] == id)
            {
                Console.WriteLine($"Customer: {data[1]}");
                Console.WriteLine($"Product: {data[2]}");
                Console.WriteLine($"Status: {data[5]}");
                found=true;
                break;
            }

        }
        if (!found)
        {
            Console.WriteLine("Id not found");
        }
        

        //Extract price details
        foreach(string order in orders)
        {
            string[] data=order.Split('|');
            int price=int.Parse(data[4].Replace("$",""));
            Console.WriteLine(price);
        }

        

    }
}