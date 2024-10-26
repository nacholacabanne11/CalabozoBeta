using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalabozosYdragones
{
    internal class Caballero : Pieza
    {

        private int avance;

        private int posicionAnterior;
        bool situacion = false;
        bool situacion2 = false;
        bool situacion3 = false;
        public int Turno = 0;
        public bool Situacion { get { return situacion; } }
        public bool Situacion2 { get { return situacion2; } }
        public bool Situacion3 { get { return situacion3; } }
        private string nombre;

        static Random dado = new Random();

        public string Nombre { get { return nombre; } }
        public int Avance { get { return avance; } }
        public int PosicionAnterior { get { return posicionAnterior; } }

        private bool llego = false;
        public bool Llego {  get { return llego; } }
        public override void Mover()
        {
          
                avance = dado.Next(1, 7);

                posicionAnterior = posicion;
                posicion += avance;
                if (posicion > 49)
                {
                    posicion = 50;
                    llego = true;
                }

            
        }
        public Caballero(string nombre, int tipo) : base(tipo)
        {
            this.nombre = nombre;
            posicion = 1;

        }
        public int VerPosicion() { return posicion; }
        public void Dragonhelp()
        {
            situacion = true;
            posicion += 5;
            if (posicion > 50)
            {
                posicion = 50;
                llego = true;
            }
        }
        public void DragonAttack()
        {
            situacion2 = true;
            posicion -= 5;
            if (posicion < 1)
            {
                posicion = 1;
            }
        }
        public void Trampa()
        {
            situacion3 = true;

        }

        public void FinTurno()
        {
            situacion = false;
            situacion2 = false;

        }

    }
}
