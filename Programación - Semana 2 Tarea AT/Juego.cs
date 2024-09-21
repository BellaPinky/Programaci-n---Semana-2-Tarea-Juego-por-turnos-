using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programación___Semana_2_Tarea_AT
{
    internal class Juego
    {
        private Jugador jugador;
        private List<Personaje> ListaEnemigos;

        private Jugador CrearJugador()
        {
            Console.WriteLine("¡Crea a tu Personaje!");
            Console.WriteLine("Ingresa la vida del Personaje, máximo 100");
            int vida = RevisarSiValido(1, 100);
            Console.WriteLine("Ingresa el Daño del Personaje, máximo 100");
            int daño = RevisarSiValido(1, 100);
            return new Jugador(vida, daño);
        }

        public int RevisarSiValido(int minimo, int maximo)
        {
            int resultado = 0;
            bool esValido = false;

            while (esValido == false)
            {
                Console.WriteLine("Por favor, ingresa un número entre " + minimo + " y " + maximo + ": ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out resultado))
                {
                    if (resultado >= minimo && resultado <= maximo)
                    {
                        esValido = true;
                    }
                    else
                    {
                        Console.WriteLine("El número no está en el rango correcto.");
                    }
                }
                else
                {
                    Console.WriteLine("Eso no es un número válido.");
                }
            }

            return resultado;
        }

        public void AJugar()
        {
            Console.WriteLine("¡Derrota a todos los enemigos para ganar!");
            jugador = CrearJugador();
            ListaEnemigos = new List<Personaje>()
            {
            new Enemigo_Melee(80, 10),
            new Enemigo_Rango(100, 5, 2),
            };
            Console.WriteLine("¡Enemigos a la vista!");
            int turno = 1;
            while (true)
            {
                Console.WriteLine($"\n--- Turno {turno} ---");
                MostrarEstadisticas();
                // Turno del jugador
                if (TurnoJugador())
                {
                    Console.WriteLine("¡Victoria! Has derrotado a todos los enemigos.");
                    break;
                }
                // Turno de los enemigos
                if (TurnoEnemigos())
                {
                    Console.WriteLine("Derrota. Tu personaje ha sido vencido.");
                    break;
                }
                turno++;
            }
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        private void MostrarEstadisticas()
        {
            Console.WriteLine("Vida del jugador: " + jugador.vida);

            int numero = 1;
            foreach (var enemigo in ListaEnemigos)
            {
                Console.WriteLine("Enemigo " + numero + " - Vida: " + enemigo.vida);
                numero = numero + 1;
            }
        }

        private bool TurnoJugador()
        {
            if (ListaEnemigos.Count == 0)
            {
                return true; // Victoria
            }
            Console.WriteLine("Es tu turno. ¿A qué enemigo quieres atacar?");
            for (int i = 0; i < ListaEnemigos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Enemigo {i + 1}");
            }
            int objetivo = RevisarSiValido(1, ListaEnemigos.Count) - 1;
            int daño = jugador.CausarDaño();
            ListaEnemigos[objetivo].RecibirDaño(daño);
            Console.WriteLine($"Has causado {daño} de daño al enemigo {objetivo + 1}");
            if (ListaEnemigos[objetivo].vida <= 0)
            {
                Console.WriteLine($"Has derrotado al enemigo {objetivo + 1}");
                ListaEnemigos.RemoveAt(objetivo);
            }
            return false;
        }

        private bool TurnoEnemigos()
        {
            foreach (var enemigo in ListaEnemigos)
            {
                int daño = enemigo.CausarDaño();
                jugador.RecibirDaño(daño);
                Console.WriteLine($"Un enemigo te ha causado {daño} de daño");
                if (jugador.vida <= 0)
                {
                    return true; // Derrota
                }
            }
            return false;
        }

    }

}
    
       


