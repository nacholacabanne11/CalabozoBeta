using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalabozosYdragones
{
    internal class Intermedio : Basico
    {

        protected ArrayList Dragons = new ArrayList();
        Dragon draga;
        public int CantDragons { get { return Dragons.Count; } }

        public Intermedio(string nombre, int cantjugadores) : base(nombre, cantjugadores)
        {
            for (int i = -1; i < jugadores.Count - 1; i++)
            {
                draga = new Dragon(i);
                Dragons.Add(draga);
               draga = new Dragon(i);
                Dragons.Add(draga);
            }

        }
        public override void Jugar()
        {
            base.Jugar();
            foreach (Dragon sasha in Dragons)
            {
                foreach (Caballero a in jugadores)
            {
               
                    sasha.Mover();
                    sasha.Evaluar(a);
                }
            }
        }
        public Dragon VerDragon(int idx)
        {
            Dragon jug = null;
            if (idx >= 0 && idx < Dragons.Count)
            {
                jug = (Dragon)Dragons[idx];
            }
            return jug;
        }

    }
}