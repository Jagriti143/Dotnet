using System;
class Program{
    public static void Main(string[] args){
        string[] tickets =
        {
            "T001|John|Login Issue",
            "T002|Alice|Payment Failed",
            "T003|David|Account Locked",
            "T004|Emma|Refund Request",
            "T005|James|Password Reset"
        };
        //display only tickets
        for(int i=0;i<tickets.Length;i++){
            string[] data1=tickets[i].Split('|');
            Console.WriteLine(data1[0]);
        }

        //display all records

        for(int i=0;i<tickets.Length;i++){
            string[] data2=tickets[i].Split('|');
            Console.WriteLine(data2[0]+" "+data2[1]+" "+data2[2]);
        }

        //display first ticket
        string[] data3=tickets[0].Split('|');
        Console.WriteLine(data3[0]+" "+data3[1]+" "+data3[2]);

        //view next ticket
        string[] data4=tickets[1].Split('|');
        Console.WriteLine(data4[0]+" "+data4[1]+" "+data4[2]);

        //Total count of queue
        Console.WriteLine("Pending Tickets= "+(tickets.Length -1));

        //Search ticket by id
        string id="T004";
        bool found=false;
        for(int i=0;i<tickets.Length;i++){
            string[] data5=tickets[i].Split('|');
            if(data5[0]==id){
                found=true;
                Console.WriteLine("Ticket Found");
                Console.WriteLine("Customer: "+data5[1]+"\nIssue: "+data5[2]);
                break;
            }
        }
        if(!found){
            Console.WriteLine("Id not found");
        }

        //count tickets by issue type

        int login=0;
        int payment=0;
        int account=0;
        int refund=0;
        int password=0;
        for(int i=0;i<tickets.Length;i++){
            string[] data=tickets[i].Split('|');
            if(data[2]=="Login Issue"){
                login++;
            }else if(data[2]=="Payment Failed"){
                payment++;
            }else if(data[2]=="Account Locked"){
                account++;
            }else if(data[2]=="Refund Request"){
                refund++;
            }else if(data[2]=="Password Reset"){
                password++;
            }

        }
        Console.WriteLine("Login Issue = "+login);
        Console.WriteLine("Payment Failed = "+payment);
        Console.WriteLine("Account Locked = "+account);
        Console.WriteLine("Refund Request = "+refund);
        Console.WriteLine("Password Reset = "+password);

        //remove all processed tickets
        int front=3;
        for(int i=front;i<tickets.Length;i++){
            string[] data=tickets[i].Split('|');
            Console.WriteLine(data[0]+" "+data[1]+" "+data[2]);
        }




    }
}