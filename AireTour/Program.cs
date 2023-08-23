using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AireTour
{
    internal class Program

    {
        static void Main(string[] args)

        {


            Console.SetWindowSize(70, 30);

            Login login = new Login();
            string password= login.InfoEstudiante();

            try
            {
                string mensaje = login.IniciarSesion(password);
                Console.WriteLine(mensaje);
               
                Console.Clear();

                Cliente cliente = login.menuPrincipal();
                Console.Clear();

                cliente.mostarInfoCliente();

                
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
            }
        }
    }
}   
