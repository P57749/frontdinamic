using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Referencia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // comboBox1.Items.Add("Opción 1");
           // comboBox1.Items.Add("Opción 2");
           // comboBox1.Items.Add("Opción 3");
           // comboBox1.Items.Add("Geográficas");
            // Selecciona "Geográficas"
           // comboBox1.SelectedIndex = 3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox9.Visible = false;   
            textBox8.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            //textBox1.Visible = false;
       //     comboBox1.Items.Add("Opción 1");
      //      comboBox1.Items.Add("Opción 2");
        //    comboBox1.Items.Add("Opción 3");
            //comboBox1.Items.Add("Geográficas");
            // Selecciona "Geográficas"
            //comboBox1.SelectedIndex = 3;


        }

      //  List<object> tempList1 = new List<object>();
    //    List<object> tempList2 = new List<object>();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
      //      if (comboBox1.SelectedItem != null)
   //         {
                // Guarda la opción seleccionada en comboBox1
     //           string selectedOption = comboBox1.SelectedItem.ToString();

                // Agrega la opción seleccionada a tempList1
         //       tempList1.Add(selectedOption);

                // Limpia los elementos de comboBox2
           //     comboBox2.Items.Clear();

                // Agrega todas las opciones al comboBox2, excepto la opción seleccionada en comboBox1
            //    foreach (var option in comboBox1.Items)
           //     {
            //        if (option.ToString() != selectedOption)
            //        {
             //           comboBox2.Items.Add(option);
          //          }
               // }

                // Selecciona la primera opción en comboBox2
              //  //if (comboBox2.Items.Count > 0)
              //  {
              //      comboBox2.SelectedIndex = 0;
              //  }
           // }



            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() == "Geográficas")
            {
                label1.Visible = true;
                label2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                //false
                label4.Visible = false;
                label3.Visible  = false;
                label5.Visible = false;
                textBox1.Visible = false;
                textBox5.Visible = false;   
                textBox6.Visible = false;


            }
            else {
                label4.Visible = true;
                label3.Visible = true;
                label5.Visible = true;
                textBox1.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                //false
                label1.Visible = false;
                label2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if (comboBox2.SelectedItem != null)
           // {
                // Guarda la opción seleccionada en comboBox2
          //      string selectedOption = comboBox2.SelectedItem.ToString();

                // Agrega la opción seleccionada a tempList2
             //   tempList2.Add(selectedOption);

                // Limpia los elementos de comboBox1
           //     comboBox1.Items.Clear();

                // Agrega todas las opciones al comboBox1, excepto la opción seleccionada en comboBox2
            //    foreach (var option in comboBox2.Items)
           //     {
           //         if (option.ToString() != selectedOption)
           //         {
           //             comboBox1.Items.Add(option);
          //          }
          //      }

                // Selecciona la primera opción en comboBox1
             //   if (comboBox1.Items.Count > 0)
             //   {
              //      comboBox1.SelectedIndex = 0;
                //}

            //}

            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Geográficas")
            {
                label6.Visible = true;
                label7.Visible = true;
                comboBox5.Visible = true;
                comboBox6.Visible = true;
                textBox9.Visible = true;
                textBox8.Visible = true;
                //false
                label10.Visible = false;
                label9.Visible = false;
                label8.Visible = false;
                textBox10.Visible = false;
                textBox7.Visible = false;
                textBox2.Visible = false;


            }
            else
            {
                label10.Visible = true;
                label9.Visible = true;
                label8.Visible = true;
                textBox10.Visible = true;
                textBox7.Visible = true;
                textBox2.Visible = true;
                //false
                label6.Visible = false;
                label7.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                textBox9.Visible = false;
                textBox8.Visible = false;
            }
        }
        
        private void button1_Click(object sender , EventArgs e)
        {
            var temp = comboBox1.SelectedItem;
            comboBox1.SelectedItem = comboBox2.SelectedItem;
            comboBox2.SelectedItem = temp;

            // Actualiza los elementos de los ComboBoxes con las listas temporales
          //  comboBox1.Items.Clear();
     //       comboBox2.Items.Clear();
        //    foreach (var option in tempList1)
    //        {
     //           comboBox1.Items.Add(option);
      //      }
         //   foreach (var option in tempList2)
    //        {
    //            comboBox2.Items.Add(option);
   //         }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Obtiene las opciones seleccionadas en los ComboBoxes
            string coordenadasPartida = comboBox1.SelectedItem.ToString();
            string coordenadasLlegada = comboBox2.SelectedItem.ToString();

            // Obtiene los valores de la latitud y longitud
            string longitud = comboBox3.SelectedItem + textBox4.Text;
            string latitud = comboBox4.SelectedItem + textBox3.Text;

            List<string> parametros = new List<string>();

            //longitud
                parametros.Add(textBox1.Text);
                //Este o Oeste
                parametros.Add(textBox5.Text);
                //Latitud
                parametros.Add(textBox6.Text);
                // //Norte o Sur
                // parametros.Add(textBox3.Text);


            // Obtiene los valores de los campos de la izquierda
            //x
            string valor1 = textBox1.Text;
            //y
            string valor2 = textBox5.Text;
            //z
            string valor3 = textBox6.Text;

            if (coordenadasLlegada == "Geográficas")
            {
                List<string> parametros = new List<string>();
                //longitud
                parametros.Add(comboBox3.Text);
                //Este o Oeste
                parametros.Add(textBox4.Text);
                //Latitud
                parametros.Add(comboBox4.Text);
                //Norte o Sur
                parametros.Add(textBox3.Text);

                List<string> resultados = Convertir.Convertir_Coordenada(parametros, coordenadasPartida, coordenadasLlegada);

                //latitud
                textBox9.Text= resultados[0];
                //longitud
                textBox8.Text= resultados[1];
                
                string lat = resultados[0];
                string lng = resultados[1];

                string url = $"https://www.google.com/maps/search/?api=1&query={lat},{lng}";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };

        Process.Start(psi);   

            }
            else
            {
                // Llama al método Calcular con los valores
                List<string> resultados = Convertir.Convertir_Coordenada(parametros, coordenadasPartida, coordenadasLlegada);

                //List<string> resultados = Convertir.ConvertirCoordenadas(coordenadasPartida, coordenadasLlegada,valor1, valor2, valor3);

                // Muestra los resultados en los campos de la derecha
                //x
                textBox6.Text = resultados[0];
                y
                textBox7.Text = resultados[1];
                z
                textBox8.Text = resultados[2];
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
