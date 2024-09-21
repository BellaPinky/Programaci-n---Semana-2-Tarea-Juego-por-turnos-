using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programación___Semana_2_Tarea_AT
{
    internal abstract class Personaje
    {
        public int vida;
        public int daño;

        public Personaje(int vida, int daño)
        {
            this.vida = vida;
            this.daño = daño;
        }

        public abstract void RecibirDaño(int DañoRecibido);
        public abstract int CausarDaño();
        public abstract bool EstaVivo();

        internal int ObtenerDaño()
        {
            throw new NotImplementedException();
        }
    }
}
