using System;

class CuentaBancaria
{
    public string NumeroCuenta { get; set; }
    public string NIP { get; set; }
    public double Saldo { get; set; }

    public CuentaBancaria(string numeroCuenta, string nip, double saldoInicial)
    {
        NumeroCuenta = numeroCuenta;
        NIP = nip;
        Saldo = saldoInicial;
    }
}

class ATM
{
    private CuentaBancaria[] cuentas;

    public ATM(CuentaBancaria[] cuentas)
    {
        this.cuentas = cuentas;
    }

    public void IniciarSesion()
    {
        Console.WriteLine("Ingrese número de cuenta: ");
        string numeroCuenta = Console.ReadLine();

        Console.WriteLine("Ingrese NIP: ");
        string nip = Console.ReadLine();

        foreach (CuentaBancaria cuenta in cuentas)
        {
            if (cuenta.NumeroCuenta == numeroCuenta && cuenta.NIP == nip)
            {
                MostrarMenuPrincipal(cuenta);
                return;
            }
        }

        Console.WriteLine("Número de cuenta o NIP incorrectos.");
    }

    public void MostrarMenuPrincipal(CuentaBancaria cuenta)
    {
        Console.WriteLine($"Bienvenido, {cuenta.NumeroCuenta}");
        Console.WriteLine("Menú Principal:");
        Console.WriteLine("1. Consultar Saldo");
        Console.WriteLine("2. Retirar Dinero");
        Console.WriteLine("3. Depositar Dinero");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");

        int opcion = int.Parse(Console.ReadLine());
        RealizarTransaccion(opcion, cuenta);
    }

    public void RealizarTransaccion(int opcion, CuentaBancaria cuenta)
    {
        switch (opcion)
        {
            case 1:
                Console.WriteLine($"Su saldo actual es: {cuenta.Saldo:C}");
                break;
            case 2:
                Console.Write("Ingrese la cantidad a retirar: ");
                double cantidadRetiro = double.Parse(Console.ReadLine());

                if (cantidadRetiro > cuenta.Saldo)
                {
                    Console.WriteLine("Saldo insuficiente para realizar el retiro.");
                }
                else
                {
                    cuenta.Saldo -= cantidadRetiro;
                    Console.WriteLine($"Se ha retirado {cantidadRetiro:C}. Su saldo actual es: {cuenta.Saldo:C}");
                }
                break;
            case 3:
                Console.Write("Ingrese la cantidad a depositar: ");
                double cantidadDeposito = double.Parse(Console.ReadLine());

                if (cantidadDeposito > 0)
                {
                    cuenta.Saldo += cantidadDeposito;
                    Console.WriteLine($"Se ha depositado {cantidadDeposito:C}. Su saldo actual es: {cuenta.Saldo:C}");
                }
                else
                {
                    Console.WriteLine("La cantidad a depositar debe ser mayor que cero.");
                }
                break;
            case 4:
                Console.WriteLine("Gracias por usar el ATM. ¡Hasta luego!");
                return;
            default:
                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                break;
        }

        MostrarMenuPrincipal(cuenta);
    }
}

class Program
{
    static void Main()
    {
        CuentaBancaria[] cuentas = new CuentaBancaria[]
        {
            new CuentaBancaria("12345", "1234", 1000),
            new CuentaBancaria("54321", "4321", 500)
            // Agrega más cuentas aquí, estas son cuentas para prueba profe
        };

        ATM atm = new ATM(cuentas);

        Console.WriteLine("Bienvenido al ATM. Por favor, inicie sesión:");
        atm.IniciarSesion();
    }
}
