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
            Console.WriteLine("dsadadasda");
        }
        else
        {
            // client functionalities
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
            else
            {
                Console.WriteLine("The code has no associated user");
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
            }
            else if (userInput.Equals("2"))
            {
                handleRegister();
            }
            else
            {
                stillRunning = false;
            }
        }
    }
}