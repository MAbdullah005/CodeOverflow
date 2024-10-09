using System;
using System.ComponentModel.DataAnnotations;
public interface Add
{
    void add();
}
public class Bank
{
    string name;
    string location;
    static private int index = 0;
    private readonly Customer[] customer;
    public Bank()
    {
       customer=new Customer[100];
    }
    public Bank(string name, string location)
    {
        this.name = name;
        this.location = location;
        customer = new Customer[100];
    }

    public void chose_bank()
    {
        
        Console.WriteLine("       ...enter a customer data... ");
        customer[index] = new Customer();
        customer[index].customer_Data();
        index++;
    }
    public void info()
    {
        Console.WriteLine("       ........Heae are the bank Bank Data.........");
        Console.WriteLine("bank name " + this.name + " bank location " + this.location);
        int count = 0;
        while(100-(customer.Length-index)!=count)
        {
           
            customer[count].info(count);
            count++;
        }
        Console.WriteLine("all done");
    }
}
public class Customer
{
    string customer_name;
    string cinc;
    string adress;
    string phone_num;
    static int index = 0;
    Bank_account[] bank_account = new Bank_account[100];
    public Customer()
    {

    }
    public Customer(string name, string cinc, string adress, string phone)
    {
        this.customer_name = name;
        this.cinc = cinc;
        this.adress = adress;
        this.phone_num = phone;
    }
    public void info(int count)
    {
        Console.WriteLine("           .........Customer Data...........");
        Console.WriteLine("customer name "+this.customer_name+" cinc "+this.cinc+" adress "+this.adress+" phone num "+this.phone_num);
        bank_account[count].info();
    }
    public void customer_Data()
    {
        Console.Write("enter a name ");
        this.customer_name = Console.ReadLine()!;
        Console.Write("enter a cinc ");
        this.cinc = Console.ReadLine()!;
        Console.Write("enter a adress ");
        this.adress = Console.ReadLine()!;
        Console.Write("enter a phone num ");
        this.phone_num = Console.ReadLine()!;
        Console.WriteLine("enter a bnak account data ");
        bank_account[index] = new Bank_account();
        bank_account[index++].create_account();
    }
}
public class Bank_account
{
    string account_name;
    string account_id;
    int balance;
    bool status;
    DateTime created;
    public Bank_account()
    {
        status = false;
    }
    public Bank_account(string name, string id, int balance, bool status, DateTime dateTime)
    {
        this.account_name = name;
        this.account_id = id;
        this.balance = balance;
        this.status = status;
        this.created = dateTime;
    }
    public void create_account()
    {
        Console.Write("enter a account name ");
        this.account_name = Console.ReadLine()!;
        Console.Write("enter a account ID ");
        this.account_id= Console.ReadLine()!;
        Console.Write("enter a account balance ");
        this.balance=Convert.ToInt32(Console.ReadLine()!);
        status = true;
        this.created= DateTime.Now;
    }
    public void info()
    {
        Console.WriteLine("         .....Account Data......");
        Console.WriteLine("accoutn name "+this.account_name+" accoud ID "+this.account_id+" balance "+this.balance+" status "+this.status+" created time "+this.created);
    }
}
public class Class1
{
    static void Main()
    {
        Bank ubl_bank = new Bank("ubl","gt road");

        ubl_bank.chose_bank();
        ubl_bank.chose_bank();
        ubl_bank.chose_bank();
        ubl_bank.info();
        Bank hbl_bank = new Bank("hbl","GT Road");

    }
}   