using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalabozosYdragones
{
    internal class Calabozo
    {
        static Random dado = new Random();
        private int posicion;
        public int Posicion { get { return posicion; } }


        public Calabozo()
        {

            posicion = dado.Next(2, 50);
        }



    }
}
