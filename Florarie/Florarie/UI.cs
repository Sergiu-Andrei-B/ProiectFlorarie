namespace Florarie;

public class UI
{
    private UserService userService;
    private Utilizator currentUser = null;

    private void welcomeMenu()
    {
        Console.WriteLine("1 - Login");
        Console.WriteLine("2 - Register");
        Console.WriteLine("Anything else - Exit");
    }

    public UI(UserService userService)
    {
        this.userService = userService;
    }

    private void mainApp()
    {
        Console.WriteLine("Welcome " + currentUser.prenume);
        if (currentUser.cod.StartsWith('a'))
        {
            // angajat functionalities
            string cod1;
            Console.WriteLine("Angajat logat");
            Console.WriteLine("1 - Viziualizare comenzi");
            Console.WriteLine("2 - Comanda materie pentru buchete");
            Console.WriteLine("3 - Preluare materie pentru buchete");
            Console.WriteLine("4 - Preluare comanda buchet");
            Console.WriteLine("5 - Finalizare comanda");
            Console.WriteLine("Anything else - Exit");
            Console.WriteLine("Introduceti optiunea");
            cod1 = Console.ReadLine();
            switch (cod1)
            {
                case "1":
                    break;
                case "2":
                    break;  
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default: Console.WriteLine("Delogare reusita");
                    runApp(); 
                    break;
            }
        }
        else
        {
            // client functionalities
            string cod2;
            Console.WriteLine("Client logat");
            Console.WriteLine("1 - Comanda de buchet");
            Console.WriteLine("2 - Vizualizare istoric comenzi");
            Console.WriteLine("3 - Vizualizare detalii comanda");
            Console.WriteLine("4 - Ridicare comanda");
            Console.WriteLine("5 - Review comanda");
            Console.WriteLine("Anything else - Exit");
            Console.WriteLine("Introduceti optiunea");
            cod2 = Console.ReadLine();
            switch (cod2)
            {
                case "1":
                    break;
                case "2":
                    break;  
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default: Console.WriteLine("Delogare reusita");
                    runApp(); 
                    break;
            }
        }
    }

    private void handleLogin()
    {
        bool loggedIn = false;
        while (!loggedIn)
        {
            Console.WriteLine("Enter unique code: ");
            string userInput = Console.ReadLine();
            Utilizator currentUser = userService.findOne(userInput);
            if (currentUser != null)
            {
                loggedIn = true;
                this.currentUser = currentUser;
                mainApp();
            }
            else if (currentUser == null)
            {
                bool logged = false;
                while (!logged)
                {
                    Console.WriteLine("1 - Enter unique code again: ");
                    Console.WriteLine("Anything else - Back to main menu");
                    string userInput1 = Console.ReadLine();
                
                    if (userInput1.Equals("1"))
                    {
                        Console.WriteLine("Enter unique code: ");
                        string userInput2 = Console.ReadLine();
                        currentUser = userService.findOne(userInput2);
                        if (currentUser != null)
                        {
                            loggedIn = true;
                            logged = true;
                            this.currentUser = currentUser;
                            mainApp();
                        }
                    }
                    else
                    {
                        runApp();
                        logged = true;
                    }

                }
                
            }
        }
    }
    

    private void handleRegister()
    {
        Console.WriteLine("Code: ");
        string userCode = Console.ReadLine();
        Console.WriteLine("Nume: ");
        string userNume = Console.ReadLine();
        Console.WriteLine("Prenume: ");
        string userPrenume = Console.ReadLine();
        Console.WriteLine("Email: ");
        string userEmail = Console.ReadLine();
        Console.WriteLine("Parola: ");
        string userPassword = Console.ReadLine();
        
        Utilizator newUser = new Utilizator(userCode, userNume, userPrenume, userEmail, userPassword);
        if (userService.add(newUser))
        {
            currentUser = newUser;
            mainApp();
        }
    }

    public void runApp()
    {
        
        bool stillRunning = true;
        while (stillRunning)
        {
            welcomeMenu();
            Console.WriteLine("Input: ");
            string userInput = Console.ReadLine();
            if (userInput.Equals("1"))
            {
                handleLogin();
                stillRunning = false;
            }
            else if (userInput.Equals("2"))
            {
                handleRegister();
                stillRunning = false;
            }
            else
            {
                stillRunning = false;
            }
        }
    }
}