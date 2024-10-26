using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalabozosYdragones
{
    internal class Basico
    {
        protected ArrayList jugadores = new ArrayList();

        public int CantidadJugadores { get { return jugadores.Count; } }
        public Basico(string nombre, int cantJugadores)
        {
            jugadores.Add(new Caballero(nombre, -1));
            for (int i = 0; i < cantJugadores; i++)
            {
                jugadores.Add(new Caballero("Caballero oscuro" + " " + Convert.ToString(i), i));
            }

        }




        virtual public void Jugar() 

        {
            foreach (Caballero jug in jugadores)
            {
                if (jug.Turno < 1)
                {
                    jug.Mover();
                }

              

                
            }
        }
        public bool HaFinalizado()

                {
                    bool haFinalizado = false;
                    foreach (Caballero jugador in jugadores)
                    {
                        if (jugador.VerPosicion() == 50)
                        {
                            haFinalizado |= true;
                        }
                    }
                    return haFinalizado;
                }
                public Caballero VerJugador(int idx)
                {
                    Caballero jug = null;
                    if (idx >= 0 && idx < jugadores.Count)
                    {
                        jug = (Caballero)jugadores[idx];
                    }
                    return jug;
                }

            }
        }