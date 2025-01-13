namespace Florarie;

public class Meniu
{
    private UserService userService;
    private Utilizator currentUser = null;
    private GestionareComenzi gestionareComenzi;

    private void welcomeMenu()
    {
        Console.WriteLine("1 - Login");
        Console.WriteLine("2 - Inregistrare");
        Console.WriteLine("Alta optiune - IESIRE");
    }

    public Meniu(UserService userService, GestionareComenzi gestionareComenzi)
    {
        this.userService = userService;
        this.gestionareComenzi = gestionareComenzi;
    }

    private void mainApp()
    {
        Console.WriteLine("Buna ziua " + currentUser.prenume);
        if (currentUser is Angajat angajat)
        {
            // functionalitati angajat
            string cod1;
            Console.WriteLine("Angajat logat cu succes ! ");
            Console.WriteLine("1 - Viziualizare comenzi");
            Console.WriteLine("2 - Comanda materie pentru buchete");
            Console.WriteLine("3 - Preluare materie pentru buchete");
            Console.WriteLine("4 - Preluare comanda buchet");
            Console.WriteLine("5 - Finalizare comanda");
            Console.WriteLine("Alta optiune - IESIRE");
            Console.WriteLine("Introduceti optiunea");
            cod1 = Console.ReadLine();
            string cod4;
            switch (cod1)
            {
                case "1":
                    
                    Console.WriteLine("Doriti sa efectuati alta operatie ?(Da/Nu)");
                    cod4 = Console.ReadLine().ToLower();
                    if (cod4 == "da")
                    {
                        mainApp();
                    }
                    else if (cod4 == "nu" || cod4 != "da")
                    {   
                        Console.WriteLine("Delogare reusita");
                    }    
                    break;
                case "2":
                    Console.WriteLine("Descriere materie: ");
                    string descriereMaterie = Console.ReadLine();
                    int codUnic = new Random().Next(0, 1000);
                    var comandaMaterie = new ComandaMaterie(descriereMaterie, codUnic, ComandaMaterie.StatusMaterie.InAsteptare);
                    gestionareComenzi.AddComandaMaterie(comandaMaterie);
                    Console.WriteLine($"Comanda cu codul {codUnic} a fost adaugata cu succes!");
                    
                    Console.WriteLine("Doriti sa efectuati alta operatie ?(Da/Nu)");
                    cod4 = Console.ReadLine().ToLower();
                    if (cod4 == "da")
                    {
                        mainApp();
                    }
                    else if (cod4 == "nu" || cod4 != "da")
                    {   
                        Console.WriteLine("Delogare reusita");
                    }    
                    break;  
                case "3":
                    Console.WriteLine("Introduceti codul comenzii de materie pentru a fi preluata: ");
                    int codMaterie = int.Parse(Console.ReadLine());
                    string rezultat = gestionareComenzi.PreiaComandaMaterie(codMaterie);
                    Console.WriteLine(rezultat);
                    
                    Console.WriteLine("Doriti sa efectuati alta operatie ?(Da/Nu)");
                    cod4 = Console.ReadLine().ToLower();
                    if (cod4 == "da")
                    {
                        mainApp();
                    }
                    else if (cod4 == "nu" || cod4 != "da")
                    {   
                        Console.WriteLine("Delogare reusita");
                    }       
                    break;
                case "4":
                    Console.WriteLine("Introduceti codul comenzii de buchet pentru a fi preluata: ");
                    int codBuchet = int.Parse(Console.ReadLine());
                    string rezultatComanda = gestionareComenzi.PreiaComandaBuchet(codBuchet, angajat);
                    Console.WriteLine(rezultatComanda);
                    
                    Console.WriteLine("Doriti sa efectuati alta operatie ?(Da/Nu)");
                    cod4 = Console.ReadLine().ToLower();
                    if (cod4 == "da")
                    {
                        mainApp();
                    }
                    else if (cod4 == "nu" || cod4 != "da")
                    {   
                        Console.WriteLine("Delogare reusita");
                    }    
                    break;
                case "5":
                    string rezultatFinalizare = gestionareComenzi.FinalizareComanda(angajat);
                    Console.WriteLine(rezultatFinalizare);
                    
                    Console.WriteLine("Doriti sa efectuati alta operatie ?(Da/Nu)");
                    cod4 = Console.ReadLine().ToLower();
                    if (cod4 == "da")
                    {
                        mainApp();
                    }
                    else if (cod4 == "nu" || cod4 != "da")
                    {   
                        Console.WriteLine("Delogare reusita");
                    }        
                    break;
                default: Console.WriteLine("Delogare reusita");
                    runApp(); 
                    break;
            }
        }
        else if(currentUser is Client client)
        {
            // functionalitati client
            string cod2;
            Console.WriteLine("Client logat");
            Console.WriteLine("1 - Comanda de buchet");
            Console.WriteLine("2 - Vizualizare istoric comenzi");
            Console.WriteLine("3 - Vizualizare detalii comanda");
            Console.WriteLine("4 - Ridicare comanda");
            Console.WriteLine("5 - Review comanda");
            Console.WriteLine("Alta optiune - IESIRE");
            Console.WriteLine("Introduceti optiunea");
            cod2 = Console.ReadLine();
            string cod3;
            switch (cod2)
            {
                case "1": 
                    Console.WriteLine("Introduceti descrierea buchetului: ");
                    string descriere = Console.ReadLine();
                    Console.WriteLine("Introduceti numele dumneavoastra:");
                    string nume = Console.ReadLine();
                    Console.WriteLine("Introduceti numarul de telefon: ");
                    string nrTel = Console.ReadLine();
                    int codComanda = new Random().Next(1, 1000);
                    var comandaNoua = new ComandaBuchet(descriere, codComanda, nume, nrTel, ComandaBuchet.Status.InPreluare);
                    gestionareComenzi.AddComandaBuchet(comandaNoua);
                    Console.WriteLine($"Comanda cu numarul {codComanda}, aflata pe numele {nume} a fost plasata cu succes!");
                    Console.WriteLine("Status - In Preluare");
                    
                    Console.WriteLine("Doriti sa efectuati alta operatie ?(Da/Nu)");
                    cod3 = Console.ReadLine().ToLower();
                    if (cod3 == "da")
                    {
                        mainApp();
                    }else if (cod3 == "nu" || cod3 != "da")
                    {   
                        Console.WriteLine("Delogare reusita");
                    }    
                    break;
                case "2": 
                    
                    Console.WriteLine("Doriti sa efectuati alta operatie ?(Da/Nu)");
                    cod3=Console.ReadLine();
                    if (cod3 == "da")
                    {
                        mainApp();
                    }
                    else if (cod3 == "nu" || cod3 != "da")
                    {   
                        Console.WriteLine("Delogare reusita");
                    }    
                    break;  
                case "3":
                    
                    Console.WriteLine("Doriti sa efectuati alta operatie ?(Da/Nu)");
                    cod3 = Console.ReadLine().ToLower();
                    if (cod3 == "da")
                    {
                        mainApp();
                    }
                    else if (cod3 == "nu" || cod3 != "da")
                    {   
                        Console.WriteLine("Delogare reusita");
                    }    
                    break;
                
                case "4":
                    
                    Console.WriteLine("Doriti sa efectuati alta operatie ?(Da/Nu)");
                    cod3=Console.ReadLine();
                    if (cod3 == "Da" || cod3 == "da"||cod3 == "DA")
                    {
                        mainApp();
                    }
                    else if (cod3 == "nu" || cod3 != "da")
                    {   
                        Console.WriteLine("Delogare reusita");
                    }    
                    break;
                case "5":
                    
                    Console.WriteLine("Doriti sa efectuati alta operatie ?(Da/Nu)");
                    cod3 = Console.ReadLine().ToLower();
                    if (cod3 == "da")
                    {
                        mainApp();
                    }
                    else if (cod3 == "nu" || cod3 != "da")
                    {   
                        Console.WriteLine("Delogare reusita");
                    }    
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
            Console.WriteLine("Introduceti codul unic ");
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
                    Console.WriteLine("1 - Introduceti codul unic din nou: ");
                    Console.WriteLine("Alta optiune - Intoarcere la meniul principal");
                    string userInput1 = Console.ReadLine();
                
                    if (userInput1.Equals("1"))
                    {
                        Console.WriteLine("Introduceti codul unic: ");
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

        Utilizator newUser;
        if (userCode.StartsWith("a"))
        {
            newUser = new Angajat(userCode,userNume,userPrenume,userEmail,userPassword);
            currentUser = newUser;
            mainApp();
        }
        else if (userCode.StartsWith("b"))
        {
            newUser = new Client(userCode, userNume, userPrenume, userEmail,userPassword);
            currentUser = newUser;
            mainApp();
        }
        else
        {
            Console.WriteLine("Codul introdus este invalid ! ");
            handleRegister();
        }
    }

    public void runApp()
    {
        
        bool stillRunning = true;
        while (stillRunning)
        {
            welcomeMenu();
            Console.WriteLine("Alegeti optiunea: ");
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