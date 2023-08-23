using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// estructura de los datos del cliente
    public struct ClienteData
    {
        public long Identificacion;
        public string Nombre;
        public int Destino;
        public int Clase;
        public int Estrato;
        public int Genero;
        public int DiaSemana;
    }

namespace AireTour
{
    internal class Login
    {

        
        public string IniciarSesion( string contraseña)
        {
            

                // Aquí iría la lógica de autenticación real
                if (contraseña == "123")
                {
       
                    return "Inicio de sesión exitoso";
                   
                }
                else
                {
                  
                    throw new Exception("Credenciales inválidas");

                }



        }

        public string InfoEstudiante()
        {
            Console.WriteLine("------------------------ AIR TOUR ------------------------ \n");
            Console.WriteLine("Alejandro olarte Diaz");
            Console.WriteLine("Estructura de datos");

            Console.WriteLine("\nIngresa la contraseña de inicio de sesión: ");
            string password=Console.ReadLine();


            return password;
        }

        public Cliente menuPrincipal()
        {
            ClienteData datosCliente = new ClienteData();
           
            Console.WriteLine("Bienvenido a AIR TOUR \n");
            Console.WriteLine("  Digita tu número de Identificación: ");
            datosCliente.Identificacion = GetValidLongInput();

            Console.WriteLine("\n  Nombre completo: ");
            datosCliente.Nombre = Console.ReadLine();

            Console.WriteLine("\n Selecciona a dónde viajas:" +
                "\n1) Bogotá" +
                "\n2) Medellín" +
                "\n3) Florencia" +
                "\n4) Pitalito");
            datosCliente.Destino = GetValidIntInput(4);

            Console.WriteLine("\n  Selecciona la clase en la cual viajas:" +
                "\n1) A" +
                "\n2) B" +
                "\n3) C");
            datosCliente.Clase = GetValidIntInput(3);

            Console.WriteLine("\n Estrato: ");
            datosCliente.Estrato = GetValidIntInput(6);

            Console.WriteLine("\n  Selecciona tu género:" +
                "\n1) Masculino" +
                "\n2) Femenino"+
                "\n3) Otro");
            datosCliente.Genero = GetValidIntInput(3);

            Console.WriteLine("\n  Día de la semana:" +
                "\n1) Lunes" +
                "\n2) Martes" +
                "\n3) Miércoles" +
                "\n4) Jueves" +
                "\n5) Viernes" +
                "\n6) Sábado" +
                "\n7) Domingo");
            datosCliente.DiaSemana = GetValidIntInput(7);

            Cliente cliente = new Cliente(datosCliente);

             return cliente;
            

        }


        private int GetValidIntInput(int rango)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {

                    if (result >=1 && result <= rango)
                    {
                        return result;
                       
                    }

                    Console.WriteLine("No esta dentro del rango establecido. Ingresa un número válido\n");

                }
                else
                {
                    Console.WriteLine("Entrada inválida. Ingresa un número válido.\n");
                }
            }
        }


        private long GetValidLongInput()
            {
                while (true)
                {
                    string input = Console.ReadLine();
                    if (long.TryParse(input, out long result))
                    {
                            return result;
   
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Ingresa un número válido.\n");
                    }
                }
            }
            


    }
}
