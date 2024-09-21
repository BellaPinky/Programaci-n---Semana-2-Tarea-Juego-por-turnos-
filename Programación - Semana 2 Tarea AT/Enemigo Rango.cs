using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programación___Semana_2_Tarea_AT
{
    internal class Enemigo_Rango:Enemigo_Melee
    {

        int balas;
        
        public Enemigo_Rango(int vida, int daño, int balas) : base(vida, daño)
        {

        }

        public override void RecibirDaño(int DañoCausado)
        {
            vida -= DañoCausado;

            if (vida < 0)
            {
                vida = 0;
            }
        }

        public override int CausarDaño()
        {
            if (balas > 0)
            {
                balas = balas - 1;
                return daño;
            }
            else
            {
                Console.WriteLine("El enemigo se quedo sin balas");
                return 0; 
            }
        }



        public override bool EstaVivo()
        {
            if (vida > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

