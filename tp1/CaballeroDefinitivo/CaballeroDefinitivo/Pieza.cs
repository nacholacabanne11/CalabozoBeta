using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalabozosYdragones
{
    internal abstract class Pieza
    {
        protected int posicion;


        protected int tipo;
        public int VerTipo()
        {
            return tipo;
        }
        public abstract void Mover();
        public Pieza(int tipo)
        {

            this.tipo = tipo;
        }
    }
}