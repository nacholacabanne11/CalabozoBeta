using CalabozosYdragones;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaballeroDefinitivo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Basico tablero;
        Datos info;
        Intermedio tablero1;
        Experto tablero2;
       ArrayList ganadores=new ArrayList();
       
        int rondas = 0;
        int c, f, cd, fd;
        PictureBox[] caballeros;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            info = new Datos();
            info.comboBox1.Items.Add("Basico");
            info.comboBox1.Items.Add("Intermedio");
            info.comboBox1.Items.Add("Experto");
            info.ShowDialog();
            if (info.comboBox1.SelectedIndex == 0)
            {
                tablero = new Basico(info.txtNombre.Text, Convert.ToInt32(info.txtCANT.Value));
            }
            if (info.comboBox1.SelectedIndex == 1)
            {
                tablero1 = new Intermedio(info.txtNombre.Text, Convert.ToInt32(info.txtCANT.Value));
            }
            if (info.comboBox1.SelectedIndex == 2)
            {
                tablero2 = new Experto(info.txtNombre.Text, Convert.ToInt32(info.txtCANT.Value));
            }
            listBox1.Items.Clear();
            listBox1.Items.Add("HAN INGRESADO TODOS LOS CABALLEROS.... QUE COMIENCE EL JUEGO!");
            info.Dispose();

        }
        

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (info.comboBox1.SelectedIndex == 0)
            {
                if (tablero.HaFinalizado() == false)

                {
                    for (int i = 0; i < 4; i++)
                    {
                        caballeros[i].Visible = false;
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        dragones[i].Visible = false;
                    }
                    tablero.Jugar();
                    for (int i = 0; i < tablero.CantidadJugadores; i++)
                    {
                        Caballero caba = tablero.VerJugador(i);
                        string linea = $">{caba.Nombre} se movió desde la posición: {caba.PosicionAnterior}" +
                                       $"a la posición {caba.VerPosicion()} ({caba.Avance})";
                        listBox1.Items.Add(linea);
                        f = ((caba.VerPosicion() - 1) / 10);
                        c = ((caba.VerPosicion() - 1) % 10);
                        caballeros[i].Visible = true;
                        caballeros[i].Left = (int)(this.pctablero.Left + c * this.pctablero.Width / 10 + 10 * i);
                        caballeros[i].Top = (int)(this.pctablero.Top + f * this.pctablero.Height / 5 + 10 * i);
                        if (caba.Llego == true)
                        {
                           ganadores.Add(caba);
                        }
                    }
                    listBox1.Items.Add("--------------------------------------------------");

                }
                else
                {
                    MessageBox.Show("Un caballero escapo!");
                }
            }
            if (info.comboBox1.SelectedIndex == 1)
            {
                if (tablero1.HaFinalizado() == false)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        caballeros[i].Visible = false;
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        dragones[i].Visible = false;
                    }
                    tablero1.Jugar();
                    for (int i = 0; i < tablero1.CantidadJugadores; i++)
                    {

                        Caballero caba = tablero1.VerJugador(i);
                        if (caba.Situacion == true)
                        {
                            string linea1 = $" {caba.Nombre} se movio a la posicion de su dragon, con un dado de {caba.Avance} ";
                            listBox1.Items.Add(linea1);

                            listBox1.Items.Add(caba.Nombre + " cayo a la posicion " + caba.VerPosicion());

                        }
                        else if (caba.Situacion2 == true)
                        {
                            string linea3 = $" {caba.Nombre} se movio a la posicion de undragon enemigo, con un dado de {caba.Avance} ";
                            listBox1.Items.Add(linea3);

                            listBox1.Items.Add(caba.Nombre + " cayo a la posicion " + caba.VerPosicion());

                        }
                        else
                        {
                            string linea = $">{caba.Nombre} se movió desde la posición: {caba.PosicionAnterior}" +
                                           $"a la posición {caba.VerPosicion()} ({caba.Avance})";
                            listBox1.Items.Add(linea);
                            f = ((caba.VerPosicion() - 1) / 10);
                            c = ((caba.VerPosicion() - 1) % 10);
                            caballeros[i].Visible = true;
                            caballeros[i].Left = (int)(this.pctablero.Left + c * this.pctablero.Width / 10 + 10 * i);
                            caballeros[i].Top = (int)(this.pctablero.Top + f * this.pctablero.Height / 5 + 10 * i);
                            for (int j = 0; j < tablero1.CantDragons; j++)
                            {
                                Dragon dibujo = tablero1.VerDragon(j);

                                fd = (dibujo.VerPosicion() - 1) / 10;
                                cd = ((dibujo.VerPosicion() - 1) % 10);
                                dragones[j].Visible = true;
                                dragones[j].Left = (int)(this.pctablero.Left + cd * this.pctablero.Width / 10 + 20 - 2 * j);
                                dragones[j].Top = (int)(this.pctablero.Top + fd * this.pctablero.Height / 5 + 20 - 2 * j);


                            }

                        }
                        if (caba.Llego == true)
                        {
                            ganadores.Add(caba);
                        }
                        caba.FinTurno();
                    }

                    listBox1.Items.Add("--------------------------------------------------");

                }
                else
                {
                    MessageBox.Show("Un caballero escapo!");
                }



            }
            if (info.comboBox1.SelectedIndex == 2)
            {

                for (int i = 0; i < 3; i++)
                {
                    listBox1.Items.Add("El gran calabozo se encuentra en la posicion: " + Convert.ToString(tablero2.VerPosicion(i)));
                    Calabozo calab = tablero2.VerCalabozo(i);
                    int fa = (calab.Posicion - 1) / 10;
                    int ca = ((calab.Posicion - 1) % 10);
                    calabozos[i].Visible = true;
                    calabozos[i].Left = this.pctablero.Left + ca * this.pctablero.Width / 10;//horizontal
                    calabozos[i].Top = this.pctablero.Top + fa * this.pctablero.Height / 5;//vertical
                }
                if (tablero2.HaFinalizado() == false)
                {
                   
                    for (int i = 0; i < 4; i++)
                    {
                        caballeros[i].Visible = false;
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        dragones[i].Visible = false;
                    }
                    tablero2.Jugar();
                   
                    for (int i = 0; i < tablero2.CantidadJugadores; i++)
                    {
                       
                        Caballero caba = tablero2.VerJugador(i);
                        if (caba.Situacion == true)
                        {
                            string linea1 = $" {caba.Nombre} se movio a la posicion de su dragon, con un dado de {caba.Avance} ";
                            listBox1.Items.Add(linea1);

                            listBox1.Items.Add(caba.Nombre + " cayo a la posicion " + caba.VerPosicion());

                        }
                        else if (caba.Situacion2 == true)
                        {
                            string linea3 = $" {caba.Nombre} se movio a la posicion de undragon enemigo, con un dado de {caba.Avance} ";
                            listBox1.Items.Add(linea3);

                            listBox1.Items.Add(caba.Nombre + " cayo a la posicion " + caba.VerPosicion());


                        }
                        else
                        {
                            string linea = $">{caba.Nombre} se movió desde la posición: {caba.PosicionAnterior}" +
                                           $"a la posición {caba.VerPosicion()} ({caba.Avance})";
                            listBox1.Items.Add(linea);

                        }
                            
                          
                        
                        f = ((caba.VerPosicion() - 1) / 10);
                        c = ((caba.VerPosicion() - 1) % 10);
                        caballeros[i].Visible = true;
                        caballeros[i].Left = (int)(this.pctablero.Left + c * this.pctablero.Width / 10 + 10 * i);
                        caballeros[i].Top = (int)(this.pctablero.Top + f * this.pctablero.Height / 5 + 10 * i);

                       
                        if (caba.Llego == true)
                        {
                            ganadores.Add(caba);
                        }
                        caba.FinTurno();
                        listBox1.Items.Add("----------------");
                        listBox2.Items.Add("----------------");
                       
                    
                    }
                    for (int j = 0; j < tablero2.CantDragons; j++)
                    {
                        Dragon dibujo = tablero2.VerDragon(j);

                        listBox2.Items.Add(dibujo.VerPosicion());

                        fd = (dibujo.VerPosicion() - 1) / 10;
                        cd = ((dibujo.VerPosicion() - 1) % 10);
                        dragones[j].Visible = true;
                        dragones[j].Left = (int)(this.pctablero.Left + cd * this.pctablero.Width / 10 + 20 - 2 * j);
                        dragones[j].Top = (int)(this.pctablero.Top + fd * this.pctablero.Height / 5 + 20 - 2 * j);
                    }
                    listBox1.Items.Add("--------------------------------------------------");

                }
                else
                {
                    MessageBox.Show("Un caballero escapo!");
                }



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (info.comboBox1.SelectedIndex == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    caballeros[i].Visible = false;
                }
                for (int i = 0; i < 8; i++)
                {
                    dragones[i].Visible = false;
                }
                while (tablero.HaFinalizado() == false)
                {
                    tablero.Jugar();
                    for (int i = 0; i < tablero.CantidadJugadores; i++)
                    {
                        Caballero caba = tablero.VerJugador(i);
                        string linea = $">{caba.Nombre} se movió desde la posición: {caba.PosicionAnterior}" +
                                       $"a la posición {caba.VerPosicion()} ({caba.Avance})";
                        listBox1.Items.Add(linea);
                        f = ((caba.VerPosicion() - 1) / 10);
                        c = ((caba.VerPosicion() - 1) % 10);
                        caballeros[i].Visible = true;
                        caballeros[i].Left = (int)(this.pctablero.Left + c * this.pctablero.Width / 10 + 10 * i);
                        caballeros[i].Top = (int)(this.pctablero.Top + f * this.pctablero.Height / 5 + 10 * i);
                        if (caba.Llego == true)
                        {
                            ganadores.Add(caba);
                        }
                    }
                    listBox1.Items.Add("--------------------------------------------------");

                }

                if (tablero.HaFinalizado() == true)
                {

                    {
                        MessageBox.Show("Un caballero escapo!");
                    }
                }


            }
               
          
                if (info.comboBox1.SelectedIndex == 1)
                {
                    while (tablero1.HaFinalizado() == false)
                    {
                    for (int i = 0; i < 4; i++)
                    {
                        caballeros[i].Visible = false;
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        dragones[i].Visible = false;
                    }
                    tablero1.Jugar();
                        for (int i = 0; i < tablero1.CantidadJugadores; i++)
                        {

                            Caballero caba = tablero1.VerJugador(i);
                            if (caba.Situacion == true)
                            {
                                string linea1 = $" {caba.Nombre} se movio a la posicion de su dragon, con un dado de {caba.Avance} ";
                                listBox1.Items.Add(linea1);

                                listBox1.Items.Add(caba.Nombre + " cayo a la posicion " + caba.VerPosicion());

                            }
                            else if (caba.Situacion2 == true)
                            {
                                string linea3 = $" {caba.Nombre} se movio a la posicion de undragon enemigo, con un dado de {caba.Avance} ";
                                listBox1.Items.Add(linea3);

                                listBox1.Items.Add(caba.Nombre + " cayo a la posicion " + caba.VerPosicion());

                            }
                            else
                            {
                                string linea = $">{caba.Nombre} se movió desde la posición: {caba.PosicionAnterior}" +
                                               $"a la posición {caba.VerPosicion()} ({caba.Avance})";
                                listBox1.Items.Add(linea);
                            f = ((caba.VerPosicion() - 1) / 10);
                            c = ((caba.VerPosicion() - 1) % 10);
                            caballeros[i].Visible = true;
                            caballeros[i].Left = (int)(this.pctablero.Left + c * this.pctablero.Width / 10 + 10 * i);
                            caballeros[i].Top = (int)(this.pctablero.Top + f * this.pctablero.Height / 5 + 10 * i);
                            for (int j = 0; j < tablero1.CantDragons; j++)
                            {
                                Dragon dibujo = tablero1.VerDragon(j);

                                fd = (dibujo.VerPosicion() - 1) / 10;
                                cd = ((dibujo.VerPosicion() - 1) % 10);
                                dragones[j].Visible = true;
                                dragones[j].Left = (int)(this.pctablero.Left + cd * this.pctablero.Width / 10 + 20 - 2 * j);
                                dragones[j].Top = (int)(this.pctablero.Top + fd * this.pctablero.Height / 5 + 20 - 2 * j);
                            }
                                if (caba.Llego == true)
                                    {
                                        ganadores.Add(caba);
                                    }

                                
                            }
                            caba.FinTurno();
                        }

                        listBox1.Items.Add("--------------------------------------------------");

                    }
                    if (tablero1.HaFinalizado() == true)
                    {
                        MessageBox.Show("Un caballero escapo!");
                    }

                }

                
                if (info.comboBox1.SelectedIndex == 2)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        listBox1.Items.Add("El gran calabozo se encuentra en la posicion: " + Convert.ToString(tablero2.VerPosicion(i)));
                    Calabozo calab = tablero2.VerCalabozo(i);
                    int fa = (calab.Posicion - 1) / 10;
                    int ca = ((calab.Posicion - 1) % 10);
                    calabozos[i].Visible = true;
                    calabozos[i].Left = this.pctablero.Left + ca * this.pctablero.Width / 10;//horizontal
                    calabozos[i].Top = this.pctablero.Top + fa * this.pctablero.Height / 5;//vertical
                    }

                        
                            
                        
                    
                    while (tablero2.HaFinalizado() == false)
                    {
                    for (int i = 0; i < 4; i++)
                    {
                        caballeros[i].Visible = false;
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        dragones[i].Visible = false;
                    }
                    tablero2.Jugar();
                        for (int i = 0; i < tablero2.CantidadJugadores; i++)
                        {

                            Caballero caba = tablero2.VerJugador(i);
                            if (caba.Situacion == true)
                            {
                                string linea1 = $" {caba.Nombre} se movio a la posicion de su dragon, con un dado de {caba.Avance} ";
                                listBox1.Items.Add(linea1);

                                listBox1.Items.Add(caba.Nombre + " cayo a la posicion " + caba.VerPosicion());

                            }
                            else if (caba.Situacion2 == true)
                            {
                                string linea3 = $" {caba.Nombre} se movio a la posicion de undragon enemigo, con un dado de {caba.Avance} ";
                                listBox1.Items.Add(linea3);

                                listBox1.Items.Add(caba.Nombre + " cayo a la posicion " + caba.VerPosicion());
                            }
                            else
                            {
                                string linea = $">{caba.Nombre} se movió desde la posición: {caba.PosicionAnterior}" +
                                               $"a la posición {caba.VerPosicion()} ({caba.Avance})";
                                listBox1.Items.Add(linea);
                            f = ((caba.VerPosicion() - 1) / 10);
                            c = ((caba.VerPosicion() - 1) % 10);
                            caballeros[i].Visible = true;
                            caballeros[i].Left = (int)(this.pctablero.Left + c * this.pctablero.Width / 10 + 10 * i);
                            caballeros[i].Top = (int)(this.pctablero.Top + f * this.pctablero.Height / 5 + 10 * i);
                            if(caba.Llego==true)
                            {
                                    ganadores.Add(caba);
                                }
                               
                            }


                            caba.FinTurno();
                            listBox1.Items.Add("----------------");
                       
                    }
                    for (int j = 0; j < tablero2.CantDragons; j++)
                    {
                        Dragon dibujo = tablero2.VerDragon(j);

                        fd = (dibujo.VerPosicion() - 1) / 10;
                        cd = ((dibujo.VerPosicion() - 1) % 10);
                        dragones[j].Visible = true;
                        dragones[j].Left = (int)(this.pctablero.Left + cd * this.pctablero.Width / 10 + 20);
                        dragones[j].Top = (int)(this.pctablero.Top + fd * this.pctablero.Height / 5 + 20 );
                    }
                    listBox1.Items.Add("--------------------------------------------------");

                    }
                    if(tablero2.HaFinalizado()==true)
                    {
                        MessageBox.Show("Un caballero escapo!");
                    }

                }
               }   

        private void Historial_Click(object sender, EventArgs e)
        {
            Ganadores w =new Ganadores();
            foreach (Caballero b in ganadores)
            {
                w.lGanadores.Items.Add(b.Nombre);
            }
            w.ShowDialog();
            
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        PictureBox[] dragones; PictureBox[] calabozos;
        private void Form1_Load(object sender, EventArgs e)
        {
            caballeros = new PictureBox[4];
            dragones = new PictureBox[8];
            calabozos = new PictureBox[3];
            caballeros[0] = pictureBox2; caballeros[1] = pictureBox5; caballeros[2] = pictureBox3; caballeros[3] = pictureBox4;
            dragones[0] = pictureBox1; dragones[1] = pictureBox6; dragones[2] = pictureBox7; dragones[3] = pictureBox8; dragones[4] = pictureBox9;
            dragones[5] = pictureBox10; dragones[6] = pictureBox11; dragones[7] = pictureBox12;
            calabozos[0] = pictureBox14; calabozos[1] = pictureBox15; calabozos[2] = pictureBox16;
            Splash vspash = new Splash(2);
            vspash.ShowDialog();
        }
    }
}
 