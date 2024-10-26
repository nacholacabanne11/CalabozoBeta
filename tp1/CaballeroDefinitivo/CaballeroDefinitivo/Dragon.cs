using CaballeroDefinitivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalabozosYdragones
{
    internal class Dragon : Pieza
    {
        static Random dado = new Random();

        public override void Mover()
        {

            posicion = dado.Next(2, 50);

        }
        public Dragon(int tipo) : base(tipo)
        {
            posicion = 0;
        }
        public int VerPosicion()
        {
            return posicion;
        }
        public void Evaluar(Caballero caballero)
        {
            if (this.posicion == caballero.VerPosicion())
            {
                if (tipo == caballero.VerTipo())
                {
                    caballero.Dragonhelp();

                }
                else
                {
                    caballero.DragonAttack();

                }
            }
        }
    }
}