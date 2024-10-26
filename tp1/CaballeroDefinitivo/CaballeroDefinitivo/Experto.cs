using CaballeroDefinitivo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalabozosYdragones
{
    internal class Experto : Intermedio

    {
        ArrayList calabozos = new ArrayList();
        Calabozo cueva1, cueva2, cueva3;



        public Experto(string nombre, int cantjugadores) : base(nombre, cantjugadores)
        {
            cueva1 = new Calabozo();
            calabozos.Add(cueva1);
            cueva2 = new Calabozo();
            calabozos.Add(cueva2);
            cueva3 = new Calabozo();
            calabozos.Add(cueva3);
        }
        public int VerPosicion(int idx)
        {
            Calabozo a = (Calabozo)calabozos[idx];
            return a.Posicion;
        }

        override public void Jugar()
        {
            base.Jugar();
            for(int i = 0; i < jugadores.Count; i++) { 
                Caballero jug = (Caballero)jugadores[i];
               
                    if (jug.Turno <= 0)
                    {
                        for (int n = 0; n < calabozos.Count && jug.Turno <= 0; n++)
                        {   foreach (Dragon drag in Dragons)
                        {
                            Calabozo aux = (Calabozo)calabozos[n];
                            if (aux.Posicion == jug.VerPosicion())
                            {
                                jug.Turno = 1;
                                if (jug.VerPosicion() == drag.VerPosicion() && jug.VerTipo() == drag.VerTipo())
                                {
                                    jug.Turno = 0;
                                }
                                else if (jug.VerPosicion() == drag.VerPosicion() && jug.VerTipo() != drag.VerTipo())
                                {
                                    jugadores.Remove(jug);
                                }
                            }
                        }
                        }
                    }
                    else
                    {
                        jug.Turno--;
                    }
                
            }
        }

        public Calabozo VerCalabozo(int idx)
        {
            Calabozo jug = null;
            if (idx >= 0 && idx < calabozos.Count)
            {
                jug = (Calabozo)calabozos[idx];
            }
            return jug;
        }
    }
}

