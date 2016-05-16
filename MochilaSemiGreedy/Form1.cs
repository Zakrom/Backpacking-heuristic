using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MochilaSemiGreedy
{
    public partial class Form1 : Form
    {

        
        Dictionary<string, double> dicPeso =
        new Dictionary<string, double>();

        Dictionary<string, double> dicValor =
        new Dictionary<string, double>();

        OrderedDictionary ODKeys =
        new OrderedDictionary();

        ArrayList AlRemover = new ArrayList(); 
        ArrayList AlSolucion = new ArrayList();
        ArrayList AlSolucionActual = new ArrayList();


        //rnd1 sirve para generar numeros aleatorios
        Random rnd = new Random();
        double mejorValor= 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


       
        //---------------------------------------------------------------------------------
         //Agrega elementos a la tabla GridView

        private void generar_Registro(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBox1.Text, Convert.ToInt32(numericUpDown2.Text), Convert.ToInt32(numericUpDown3.Text), Convert.ToDouble(numericUpDown3.Text)/Convert.ToDouble(numericUpDown2.Text) );
            textBox1.Text = "";
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
        }
        //----------------------------------------------------------------------------------

        //Reordena cuando se agrega una fila de mayor a menor con cociente(campo no visible)
        //al hacer esto se evaluan los elementos ordenandolos dle mejor al peor

        private void Sort(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1.Sort(cociente, ListSortDirection.Descending);
        }

        //-----------------------------------------------------------------------------------
        //Esta funcion Reordena cuando se modifica un campo de la misma manera

       

        //-----------------------------------------------------------------------------------
        // se activa al presionar el boton que generara las soluciones
        private void generar_Soluciones(object sender, EventArgs e)
        {
            AlSolucion.Clear();
            for (int i = 0; i < txtNumSol.Value; i++)
            {
                generar_Solucion();

            }

            string conclusion = "Elementos:{";

            foreach(object cebollin in AlSolucion)
                {
                conclusion = conclusion + Convert.ToString(cebollin)+","; 
            }
            
            conclusion.Trim(','); 

            conclusion += "} \n Con un valor de: ";
            conclusion += Convert.ToString(mejorValor);
            MessageBox.Show(conclusion);
        }
        //------------------------------------------------------------------------------------
        //funcion para crear de una solucion en una
        public void generar_Solucion()
        {
            double cupo = Convert.ToInt32(this.numericUpDown4.Value);

            //Creo un diccionario donde se asocia peso y valor de los objetos a estos 
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            { 
                dicPeso.Add(Convert.ToString(row.Cells[0].Value) ,Convert.ToDouble(row.Cells[1].Value));
                dicValor.Add(Convert.ToString(row.Cells[0].Value), Convert.ToDouble(row.Cells[2].Value));

                //Este diccionario ordenado permitiara escoger un elemento aleatoriamente mas adelante
                ODKeys.Add(row.Cells[0].Value, row.Cells[0].Value);
                
            }

            double valorActual = 0 ;
            while (dicPeso.Count > 0)
            {
                //Agrego a una lista los elementos que se borraran 
                foreach (KeyValuePair<string, double> pair in dicPeso)
                {
                    if (pair.Value > cupo)
                    {
                        AlRemover.Add(pair.Key);
                    }
                }

                //dichos elementos son removidos
                foreach (object alElement in AlRemover)
                { 
                    dicPeso.Remove(Convert.ToString(alElement));
                    ODKeys.Remove(alElement);
                }

                //se elimina el contenido de esta lista para futuro uso
                AlRemover.Clear();


                if (dicPeso.Count != 0)
                {
                    //Se genera numero aleatorio "picker"
                    int picker = rnd.Next((Convert.ToInt32(Math.Sqrt(dicPeso.Count))));

                    //En este caso se uso raiz cuadrada para agregar un elemento a la solucion
                    string elementToAdd = Convert.ToString(ODKeys[picker]);

                    //Se agrega a la solucion, y actualiza peso restante al igual que valor resultante
                    AlSolucionActual.Add(elementToAdd);
                    cupo -= dicPeso[elementToAdd];
                    valorActual += dicValor[elementToAdd];

                    dicPeso.Remove(elementToAdd);
                    ODKeys.Remove(elementToAdd);

                }
            }
            //Se compara con el mejor valor anterior y se sutituye
            if (valorActual > mejorValor)
            {
                mejorValor = valorActual;
                foreach (object alElement in AlSolucionActual)
                {
                    AlSolucion.Add(alElement);
                }
            }
            dicValor.Clear();
            AlSolucionActual.Clear();

            return;  
        }
         
        //-------------------------------------------------------------------------------------




        //-------------------------------------------------------------------------------------
    }
        
    
}
/*
insertar registros*


generar n soluciones*
    {
    generar 1 solucion
        {
        evaluar elementos*
        seleccionar candidatos*
        agregar elemento a solucion
        checar si solucion esta completa
        }
    }
*/