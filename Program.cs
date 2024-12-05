using System.Security.Principal;

namespace task_4
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string Name = "Unnamed Account", double Balance = 0.0)
        {
            this.Name = Name;
            this.Balance = Balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public virtual  bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"Name :{Name} - Balance :{Balance} ";
        }
        public static Account operator+(Account leh ,Account rhs)
        {
            Account account = new Account(leh.Name,leh.Balance + rhs.Balance);
            return account;
        }
    }
    public static class AccountUtil
    {
        // Utility helper functions for Account class

        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }

        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.Name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc.Name}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
            }
        }
    }
    class SavingsAccount : Account
    {
        public SavingsAccount(string Name = "Unnamed Account", double Balance = 0.0, double rate=0.09):base(Name,Balance)
        {
            Rate = rate;
        }

        public double Rate { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()}-Rate :{Rate}";
        }

        public override bool Deposit(double amount)
        {
            return base.Deposit(amount);
        }
        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount+Rate);
        }
        public static void Display(List<SavingsAccount> accounts)
        {
            Console.WriteLine("\n=== SavingsAccount ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }
        public static void Deposit(List<SavingsAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to SavingsAccount =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.Name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
            }
        }

        public static void Withdraw(List<SavingsAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from SavingsAccount ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc.Name}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
            }
        }
       

    }
    class CheckingAccount : Account
    {

        public double Fee = 1.5;

        public CheckingAccount(string Name = "Unnamed Account", double Balance = 0.0) : base(Name, Balance) { }

        public override string ToString()
        {
            return $"Name :{Name}-Balance :{Balance}";
        }
        public override bool Deposit(double amount)
        {
            return base.Deposit(amount);
        }
        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount+Fee);
        }
        public static void Display(List<CheckingAccount> accounts)
        {
            Console.WriteLine("\n=== CheckingAccount ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }
        public static void Deposit(List<CheckingAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to CheckingAccount =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.Name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
            }
        }

        public static void Withdraw(List<CheckingAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from CheckingAccount ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc.Name}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
            }
        }

    }
    class TrustAccount : SavingsAccount
    {
        public double Bouns = 50;
        

        public TrustAccount(string Name = "Unnamed Account", double Balance = 0.0, double rate = 0.09 ) : base(Name, Balance, rate) { } 
        

        public DateTime Date = DateTime.Now;

 

        public override bool Deposit(double amount)
        {
            base.Deposit(amount);
                if(amount <= 5000)
                {
                Balance += Bouns;
                 return true;
                }
                return false;   
        }
        public  bool Withdraw(double amount)
        {           
                if (amount < Balance * 0.2 && amount > 0)
                {
                    Balance -= amount;
                    return true;
                }
                return false;
        }
        public override string ToString()
        {
            return $"Name :{Name}-Balance :{Balance}-Date :{Date}";
        }
        public static void Display(List<TrustAccount> accounts)
        {
            Console.WriteLine("\n=== TrustAccount ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }
        public static void Deposit(List<TrustAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to TrustAccount =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.Name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
            }
        }

        public static void Withdraw(List<TrustAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from TrustAccount ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc.Name}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
            }
        }


    }
    






    internal class Program
    {
        static void Main(string[] args)
        {
            // Accounts
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));
            

            AccountUtil.Display(accounts);
            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
           var savAccounts = new List<SavingsAccount>();
            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            SavingsAccount.Display(savAccounts);
            SavingsAccount.Deposit(savAccounts, 1000);
            SavingsAccount.Withdraw(savAccounts, 2000);
            SavingsAccount.Display(savAccounts);


            // Checking
            var checAccounts = new List<CheckingAccount>();
            checAccounts.Add(new CheckingAccount());
             checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            CheckingAccount.Display(checAccounts);
            CheckingAccount.Deposit(checAccounts, 1000);
            CheckingAccount.Withdraw(checAccounts, 2000);
            CheckingAccount.Withdraw(checAccounts, 2000);
            CheckingAccount.Display(checAccounts);

            // Trust
            var trustAccounts = new List<TrustAccount>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000));

            TrustAccount.Display(trustAccounts);
            TrustAccount.Deposit(trustAccounts, 1000);
            TrustAccount.Deposit(trustAccounts, 6000);
            TrustAccount.Display(trustAccounts);
            TrustAccount.Withdraw(trustAccounts, 2000);
            TrustAccount.Display(trustAccounts);
            TrustAccount.Withdraw(trustAccounts, 3000);
            TrustAccount.Display(trustAccounts);
            TrustAccount.Withdraw(trustAccounts, 500);
            TrustAccount.Display(trustAccounts);
            //مش عارف اعمل بتاعت اخلي يسحب 3 مرات بس ممكن تتوضح لو سمحت 


            Console.WriteLine();
        }
    }
}
