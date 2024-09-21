using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programación___Semana_2_Tarea_AT
{
    internal class Enemigo_Melee:Personaje
    {
        public Enemigo_Melee(int vida, int daño) : base(vida, daño)
        {

        }

        public override void RecibirDaño(int DañoRecibido)
        {
            vida -= DañoRecibido;

            if (vida <0)
            {
                vida = 0;
            }
        }

        public override int CausarDaño()
        {
            return daño;
        }

        public override bool EstaVivo()
        {
            if(vida >0)
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
