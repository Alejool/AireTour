using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireTour


{
    internal class Cliente
    {

        private long _id { get; set; }
        private string _name { get; set; }
        private int _destino { get; set; }
        private int _clase { get; set; }
        private int _estrato { get; set; }
        private int _genero { get; set; }
        private int _diaSemana { get; set; }
        private float _valorVuelo {get; set; }
        private int _descuentoVuelo { get; set; }
        private float _valorFinal { get; set; }


        public Cliente(ClienteData datosCliente)
        {
            _id = datosCliente.Identificacion;
            _name = datosCliente.Nombre;
            _destino = datosCliente.Destino;
            _clase = datosCliente.Clase;
            _estrato = datosCliente.Estrato;
            _genero = datosCliente.Genero;
            _diaSemana = datosCliente.DiaSemana;
        }

        public void precioDestino()
        {

              Dictionary<Tuple<int, int>, float> valoresVuelo = new Dictionary<Tuple<int, int>, float>
            {
                { Tuple.Create(1, 1), 300000 },
                { Tuple.Create(1, 2), 225000 },
                { Tuple.Create(1, 3), 150000 },
                { Tuple.Create(2, 1), 420000 },
                { Tuple.Create(2, 2), 315000 },
                { Tuple.Create(2, 3), 210000 },
                { Tuple.Create(3, 1), 270000 },
                { Tuple.Create(3, 2), 202500 },
                { Tuple.Create(3, 3), 135000 },
                { Tuple.Create(4, 1), 250000 },
                { Tuple.Create(4, 2), 187500 },
                { Tuple.Create(4, 3), 125000 },

            };

            float valorVuelo;

            if (valoresVuelo.TryGetValue(Tuple.Create(_destino, _clase), out valorVuelo))
            {
               _valorVuelo = valorVuelo;
                
            }
            else
            {
                _valorVuelo = 0;
          
            }
        }


        public void descuentoEstrato()
        {
            Dictionary<Tuple<int>, int> descuentosVuelo = new Dictionary<Tuple<int>, int>
            {
                { Tuple.Create(1), 10},
                { Tuple.Create(2), 10},
                { Tuple.Create(3), 7},
                { Tuple.Create(4), 7},
                { Tuple.Create(5), 5},
                { Tuple.Create(6), 5},
            };

            int descuentoVuelo;

            if(descuentosVuelo.TryGetValue(Tuple.Create(_estrato), out descuentoVuelo))
            {
                _descuentoVuelo += descuentoVuelo;

            }
            else
            {
                _descuentoVuelo += 0;

            }

        }

        public void descuentoDiaSemana()
        {
            Dictionary<Tuple<int>, int> descuentosVuelo = new Dictionary<Tuple<int>, int>
            {
                { Tuple.Create(1), 10},
                { Tuple.Create(2), 10},
                { Tuple.Create(3), 5},
                { Tuple.Create(4), 5},
                { Tuple.Create(5), 0},
                { Tuple.Create(6), 0},
            };

            int descuentoVuelo;

            if (descuentosVuelo.TryGetValue(Tuple.Create(_diaSemana), out descuentoVuelo))
            {
                _descuentoVuelo += descuentoVuelo;

            }
            else
            {
                _descuentoVuelo += 0;

            }

        }


        public void descuentoGenero()
        {
            Dictionary<Tuple<int>, int> descuentosVuelo = new Dictionary<Tuple<int>, int>
            {
                { Tuple.Create(1), 0},
                { Tuple.Create(2), 3},
            };

            int descuentoGenero;

            if (descuentosVuelo.TryGetValue(Tuple.Create(_genero), out descuentoGenero))
            {
                _descuentoVuelo += descuentoGenero;

            }
            else
            {
                _descuentoVuelo += 0;

            }

        }


        public void descuentos()
        {
            descuentoEstrato();
            descuentoDiaSemana();
            descuentoGenero();
        }


        public void  valorFinalVuelo()
        {
            float descuento = (_valorVuelo * _descuentoVuelo) / 100;
            _valorFinal = _valorVuelo - descuento;


        }


        public void mostarInfoCliente()
        {
            precioDestino();
            descuentos();
            valorFinalVuelo();

            Console.WriteLine("Nombre: "+ _name);
            Console.WriteLine("Identificación: " + _id);
            Console.WriteLine("Destino: " + destinoString());
            Console.WriteLine("Estrato: " + _estrato);
            Console.WriteLine("Género: " + generoString());
            Console.WriteLine("Dia de viaje: " + diaSemanaString());
            Console.WriteLine("Descuentos totales: "+_descuentoVuelo +"%");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("VALOR VUELO: $"+_valorFinal);
        }

        private string destinoString()
        {
            Dictionary<Tuple<int>, string> destinosString= new Dictionary<Tuple<int>, string>
            {
                { Tuple.Create(1), "Bogota"},
                { Tuple.Create(2), "Medellín"},
                { Tuple.Create(3), "Florencia"},
                { Tuple.Create(4), "Pitalito"},
            };


            string stringDestino = "No especificado";

            if (destinosString.TryGetValue(Tuple.Create(_destino), out stringDestino))
            {
                return stringDestino;

            }
            else
            {
                return stringDestino;

            }
        }
        private string diaSemanaString()
        {
            Dictionary<Tuple<int>, string> diaSemanaString = new Dictionary<Tuple<int>, string>
            {
                { Tuple.Create(1), "Lunes"},
                { Tuple.Create(2), "Martes"},
                { Tuple.Create(3), "Miercoles"},
                { Tuple.Create(4), "Jueves"},
                { Tuple.Create(5), "Viernes"},
                { Tuple.Create(6), "Sábado"},
                { Tuple.Create(7), "Domingo"},
            };


            string stringDiaSemana = "No especificado";

            if (diaSemanaString.TryGetValue(Tuple.Create(_diaSemana), out stringDiaSemana))
            {
                return stringDiaSemana;

            }
            else
            {
                return stringDiaSemana;

            }
        }

        private string generoString()
        {
            Dictionary<Tuple<int>, string> generoString = new Dictionary<Tuple<int>, string>
            {
                { Tuple.Create(1), "Masculino"},
                { Tuple.Create(2), "Femenino"},
                { Tuple.Create(3), "Otro"},
                
            };


            string stringGenero = "No especificado";

            if (generoString.TryGetValue(Tuple.Create(_genero), out stringGenero))
            {
                return stringGenero;

            }
            else
            {
                return stringGenero;

            }
        }
    }
}
