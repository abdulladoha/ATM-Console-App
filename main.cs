using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder 
{
  String cardNum;
  int pin;
  String firstName;
  String lastName;
  double balance;


  public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
  {
    this.cardNum = cardNum;
    this.pin = pin;
    this.firstName = firstName;
    this.lastName = lastName;
    this.balance = balance;
  }

  public String getNum()
  {
    return cardNum;
  }
  
  public int getPin()
  {
    return pin;
  }
  
  public String getFirstName()
  {
    return firstName;
  }

  public String getLastName()
  {
    return lastName;
  }

  public double getBalance()
  {
    return balance;
  }

  public void setNum(String newCardNum)
  {
    cardNum = newCardNum;
  }

  public void setPin(int newPin)
  {
    pin = newPin;
  }

  public void setFirstName(String newFirstName)
  {
    firstName = newFirstName;
  }

  public void setLastName(String newLastName)
  {
    lastName = newLastName;
  }

  public void setBalance(double newBalance)
  {
    balance = newBalance;
  }

  public static void Main(String[] args)
  {
    void printOptions()
    {
      Console.WriteLine("Please choose from one of the following options...");
      Console.WriteLine("1. Deposit");
      Console.WriteLine("2. Withdraw");
      Console.WriteLine("3. Show Balance");
      Console.WriteLine("4. Exit");
    }

    void deposit(cardHolder currentUser)
    {
      Console.WriteLine("How much $$ would you like to deposit");
      double deposit = Double.Parse(Console.ReadLine());
      currentUser.setBalance(currentUser.getBalance() + deposit);
      Console.WriteLine("Thank you for $$. Your new balance is: " + currentUser.getBalance());
    }

    void withdraw(cardHolder currentUser)
    {
      Console.WriteLine("How much $$ would you like to withdraw: ");
      double withdrawal = Double.Parse(Console.ReadLine());
      //Check if the user has enough money
      if(currentUser.getBalance() < withdrawal)
      {
        Console.WriteLine("Insufficient balance :(");
      }
      else
      {
        currentUser.setBalance(currentUser.getBalance() - withdrawal);
        Console.WriteLine("You're good to go! Thank you :)");
      }
    }

    void balance(cardHolder currentUser)
    {
      Console.WriteLine("Current balance: " + currentUser.getBalance());
    }

    List<cardHolder> cardHolders = new List<cardHolder>();
    cardHolders.Add(new cardHolder("463798642388312", 1234, "John", "Griffith", 1240.21));
    cardHolders.Add(new cardHolder("463790123328412", 4231, "Joe", "Marvin", 18713.28));
    cardHolders.Add(new cardHolder("173628378237121", 3361, "Johnny", "Grey", 8932312.12));
    cardHolders.Add(new cardHolder("897697898213831", 7876, "Jessie", "Gravel", 87912.83));
    cardHolders.Add(new cardHolder("5354568050297289", 1234, "Matimba", "Baker", 0.83));

    // Prompt user
    Console.WriteLine("Welcome to SimpleATM");
    Console.WriteLine("Please insert your debit card: ");
    String debitCardNum = "";
    cardHolder currentUser;

    while(true)
    {
      try
      {
        debitCardNum = Console.ReadLine();
        // Check against our db
        currentUser = cardHolders.FirstOrDefault(a => a.getNum() == debitCardNum);
        if (currentUser != null) {break;}
        else {Console.WriteLine("Card not recognised. Please try again");}
      }
      catch { Console.WriteLine("Card not recognised. Please try again"); }
    }

    Console.WriteLine("Please enter your pin: ");
    int userPin = 0;
    while(true)
    {
      try
      {
        userPin = int.Parse(Console.ReadLine());
        
        if (currentUser.getPin() == userPin) {break;}
        else {Console.WriteLine("Incorrect pin. Please try again."); }
      }
      catch { Console.WriteLine("Incorrect pin. Please try again."); }
    }
    
    Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
    int option = 0;
    do
    {
      printOptions();
      try
      {
        option = int.Parse(Console.ReadLine());
      }
      catch { }
      if(option == 1) {deposit(currentUser); }
      else if(option == 2) {withdraw(currentUser); }
      else if(option == 3) {balance(currentUser); }
      else if(option == 4) {break; }
      else {option = 0; }
    }
    while(option != 4);
    Console.WriteLine("Thank you! Having a nice day :)");
  }
  
}