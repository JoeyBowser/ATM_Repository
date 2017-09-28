//© [2017] Joey Bowser
//THIS PROGRAM ACTS AS A VIRTUAL ATM FOR THE USER. 
//USER WILL ENTER IN INFO, LOG IN, MANAGE ACCOUNT BALANCE, ETC.
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            int logInNum = 0; //VARIABLE THAT KEEPS TRACK OF TIMES USER HAS LOGGED IN
            int logInTries = 5; //VARIABLE THAT KEEPS TRACK OF TIMES USER HAS TRIED LOGGED IN

            string input = null;

            bool correctPin = false; //CHECKS IF USER ENTERED IN CORRECT PIN

            //FOR BELOW CLASSES
            RegInfo myInfo;
            myInfo = new RegInfo();
            MenuInfo myMenu;
            myMenu = new MenuInfo();

            //START MAIN PROGRAM
            Console.WriteLine("Welcome to the ATM Internet Machine!\n");
            //CHECKS TO SEE IF USER LOGGED IN BEFORE. IF THIS IS THE FIRST TIME, THIS PORTION IS CALLED
            if (logInNum < 1)
            {
                Console.WriteLine("Looks like this is your first time using this program. " +
                    "Therefore, you will have to create an account before progressing forward.");

                myInfo.EnterInfo();
                myInfo.VerifyInfo();

                Console.WriteLine("\nHello " + myInfo.firstName + "! Thank you for registering!");
                Console.WriteLine("Please log in...");
                //THIS WILL RUN UNTIL THE CORRECT PIN IS ENTERED. THEN BOOLEAN WILL BE SET TO TRUE
                while (correctPin == false)
                {
                    Console.WriteLine("\nPlease enter in your 4 digit PIN:");
                    input = Console.ReadLine();

                    if (input == myInfo.pinNum)
                    {
                        Console.WriteLine("Welcome " + myInfo.firstName + "!");
                        logInNum++;
                        correctPin = true;
                    }
                    else
                    {
                        logInTries--;

                        if (logInTries < 1)
                        {
                            Console.WriteLine("\nNumber of log in attempts exceeded. " +
                                "Program now exiting... \n(Press any key to continue)");
                            Console.ReadLine();

                            System.Environment.Exit(1);
                        }

                        Console.WriteLine("\nIncorrect PIN. Please try again " +
                            "(" + logInTries + " log in attemps remaining):");
                    }
                }
            }
            //BASICALLY REPEATS THE SECOND HALF OF THE FUNCTION ABOVE, BUT STARTING AT THE ENTER PIN PART
            else
            {
                while (correctPin == false)
                {
                    Console.WriteLine("\nPlease enter in your 4 digit PIN:");
                    input = Console.ReadLine();

                    if (input == myInfo.pinNum)
                    {
                        Console.WriteLine("Welcome " + myInfo.firstName + "!");
                        logInNum++;
                        correctPin = true;
                    }
                    else
                    {
                        logInTries--;

                        if (logInTries < 1)
                        {
                            Console.WriteLine("\nNumber of log in attempts exceeded. " +
                                "Program now exiting... \n(Press any key to continue)");
                            Console.ReadLine();

                            System.Environment.Exit(1);
                        }

                        Console.WriteLine("\nIncorrect PIN. Please try again " +
                            "(" + logInTries + " log in attemps remaining):");
                    }
                }
            }
            //CONTINUE WITH THE ATM MENU PORTION OF THE PROGRAM
            myMenu.ShowMenu();
        }
    }
    //CLASS FOR USER INFO FOR REGISTRY
    class RegInfo
    {
        public string firstName;
        public string lastName;
        public string phoneNum;
        public string pinNum;

        public string response;

        public bool correctFName = false;
        public bool correctLName = false;
        public bool correctPhone = false;
        public bool correctPin = false;

        public bool infoEntered = false;

        public void EnterInfo()
        {
            correctFName = false;
            correctLName = false;
            correctPhone = false;
            correctPin = false;

            while (correctFName == false)
            {
                Console.WriteLine("\nPlease enter in your first name:");
                firstName = Console.ReadLine();

                if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$") && firstName.Length < 25)
                {
                    correctFName = true;

                    firstName = firstName.First().ToString().ToUpper() + firstName.Substring(1).ToLower();
                }
                else
                {
                    Console.WriteLine("Invalid key entered. Please try again.");
                }
            }

            while (correctLName == false)
            {
                Console.WriteLine("\nPlease enter in your last name:");
                lastName = Console.ReadLine();

                if (Regex.IsMatch(lastName, @"^{15}[a-zA-Z]+$") && lastName.Length < 25)
                {
                    correctLName = true;

                    lastName = lastName.First().ToString().ToUpper() + lastName.Substring(1).ToLower();
                }
                else
                {
                    Console.WriteLine("Invalid key entered. Please try again.");
                }
            }

            while (correctPhone == false)
            {
                Console.WriteLine("\nPlease enter in your 10 digit phone number using this format: (XXX) XXX-XXXX");
                phoneNum = Console.ReadLine();

                if (Regex.IsMatch(phoneNum, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
                {
                    correctPhone = true;
                }
                else
                {
                    Console.WriteLine("Invalid key entered. Please try again.");
                }
            }

            while (correctPin == false)
            {
                Console.WriteLine("\nPlease enter in your 4 digit PIN number consisting of numbers only " +
                "(This PIN is what you will prompted to enter whenever you attempt to log in from now on) :");
                pinNum = Console.ReadLine();

                if (Regex.IsMatch(pinNum, @"\b\d{4}\b"))
                {
                    correctPin = true;
                }
                else
                {
                    Console.WriteLine("Invalid key entered. Please try again.");
                }
            }

            Console.WriteLine("\n\nHere is the information you entered: \nFirst Name: " + firstName +
                "\nLast Name: " + lastName + "\nPhone Number: " + phoneNum + "\nPIN Number: " + pinNum);
            Console.WriteLine("\nIs the above information correct? (Y or N)");

            //return;
        }
        public void VerifyInfo()
        {
            response = Console.ReadLine();

            while (infoEntered == false)
            {
                if (response == "Y" || response == "y")
                {
                    infoEntered = true;
                }
                else if (response == "N" || response == "n")
                {
                    Console.WriteLine("Please enter in your information again.");
                    EnterInfo();
                    VerifyInfo();
                }
                else
                {
                    Console.WriteLine("Please enter in one of the appropiate responses (Y or N)");
                    response = Console.ReadLine();
                }
            }
        }
    }
    //FOR ATM MENU PORTION, BALANCE INFO, DEPOSITS AND WITHDRAWALS, ETC.
    class MenuInfo
    {
        public string input;

        public float currBalance = 0f;
        public string withdraw;
        public string deposit;

        public void ShowMenu()
        {
            Console.WriteLine("\n---------------------ATM---------------------" +
                "\n1. Check Balance\n2. Withdraw Money\n3. Deposit Money\n4. Close Program" +
                "\n\nPlease make a selection:\n");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    //Console.WriteLine("Case 1");
                    CheckBalance();
                    break;
                case "2":
                    WithdrawMoney();
                    break;
                case "3":
                    DepositMoney();
                    break;
                case "4":
                    Console.WriteLine("Program now exiting... \n(Press any key to continue)");
                    Console.ReadLine();
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Invalid Key.");
                    ShowMenu();
                    break;
            }
        }
        public void CheckBalance()
        {
            Console.WriteLine("Your current balance is: $" + currBalance);
            ShowMenu();
        }
        public void WithdrawMoney()
        {
            if (currBalance > 0)
            {
                Console.WriteLine("Please enter in an amount to withdraw (example = 5.50): $");
                withdraw = Console.ReadLine();

                if (Regex.IsMatch(withdraw, @"^[0-9]*(?:\.[0-9]*)?$"))
                {
                    currBalance = currBalance - float.Parse(withdraw);

                    Console.WriteLine("\nWithdrawed $" + deposit + " from your account." +
                        " Your current balance is now $" + currBalance + ".");
                    withdraw = "";
                    ShowMenu();
                }
                else
                {
                    Console.WriteLine("Invalid key.");
                    WithdrawMoney();
                }
            }
            else
            {
                Console.WriteLine("Your urrent balance is " + currBalance +
                    ". You have no money to withdraw from your account.");
                ShowMenu();
            }
        }
        public void DepositMoney()
        {
            Console.WriteLine("Please enter in an amount to deposit (example = 5.50): $");
            deposit = Console.ReadLine();

            if (Regex.IsMatch(deposit, @"^[0-9]*(?:\.[0-9]*)?$"))
            {
                currBalance = float.Parse(deposit) + currBalance;

                Console.WriteLine("\nDeposited $" + deposit + " into your account." +
                    " Your current balance is now $" + currBalance + ".");
                deposit = "";
                ShowMenu();
            }
            else
            {
                Console.WriteLine("Invalid key.");
                DepositMoney();
            }
        }
    }
}
