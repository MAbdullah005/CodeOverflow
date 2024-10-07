using System;
using System.ComponentModel.DataAnnotations;
public interface Add
{
    void add();
}
public class Bank
{
    public string name;
    public string location;

    public Bank()
    {
        
    }
    public Bank(string name, string location)
    {
        this.name = name;
        this.location = location;
    }

    public void chose_bank()
    {
        Console.WriteLine("enter a bank name ");
        this.name = Console.ReadLine()!;
        Console.WriteLine("enter a location name ");
        this.location += Console.ReadLine()!;
    }
}
public class Bank_account
{
    string account_name;
    string account_id;
    int balance;
    bool status;
    DateTime created;
    public Bank Bank;
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
        Console.WriteLine("enter a account name ");
        this.account_name = Console.ReadLine()!;
        Console.WriteLine("enter a account ID ");
        this.account_id= Console.ReadLine()!;
        Console.WriteLine("enter a account balance ");
        this.balance=Convert.ToInt32(Console.ReadLine()!);
        status = true;
        this.created= DateTime.Now;
    }
}
public class Customer
{
    string customer_name;
    string cinc;
    string adress;
    string phone_num;
    public Bank_account bank_account;
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
    public void customer_Data()
    {
        Console.WriteLine("enter a name ");
        this.customer_name = Console.ReadLine()!;
        Console.WriteLine("enter a cinc ");
        this.cinc= Console.ReadLine()!;
        Console.WriteLine("enter a adress ");
        this.adress = Console.ReadLine()!;
        Console.WriteLine("enter a phone num ");
        this.phone_num= Console.ReadLine()!;
    }
}
public class Class1
{
    static void Main()
    {
        Customer customer_Account = new Customer();
        customer_Account.customer_Data();
        customer_Account.bank_account = new Bank_account();
        customer_Account.bank_account.create_account();
        customer_Account.bank_account.Bank = new Bank();
        customer_Account.bank_account.Bank.chose_bank();
    }
}