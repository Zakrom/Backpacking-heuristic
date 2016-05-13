using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        int n = 0;
        //rnd1 sirve para generar numeros aleatorios
        Random rnd1 = new Random();


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
            this.dataGridView1.Rows.Add(this.textBox1.Text, Convert.ToInt32(this.numericUpDown2.Text), Convert.ToInt32(this.numericUpDown3.Text), Convert.ToDouble(this.numericUpDown2.Text)/Convert.ToDouble(this.numericUpDown3.Text));
            
            n++;
        }
        //----------------------------------------------------------------------------------

        //Reordena cuando se agrega una fila de mayor a menor con cociente(campo no visible)
        private void Sort(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.dataGridView1.Sort(this.cociente, ListSortDirection.Descending);
        }
        
        //-----------------------------------------------------------------------------------
        //Esta funcion Reordena cuando se modifica un campo de la misma manera

        private void ReSort(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Sort(this.cociente, ListSortDirection.Descending);
        }

        //-----------------------------------------------------------------------------------
        // se activa al presionar el boton que generara las soluciones
        private void generar_Soluciones(object sender, EventArgs e)
        {
             
            for(int nSolucion = 1; nSolucion <= this.txtNumSol.Value; nSolucion++)
            {
                generar_Solucion();
            } 
        }
        //------------------------------------------------------------------------------------
        //funcion para crear de una solucion en una
        public void generar_Solucion()
        {
            int cupo = Convert.ToInt32(this.numericUpDown4.Value);
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dt.Columns.Add(col.HeaderText);
            }


            DataTable dtSolucion = dt.Clone();


            foreach (DataRow row in dt.Rows)
            {

                float peso = Convert.ToInt32(row["Peso"]);
                float valor = Convert.ToInt32(row["Valor"]);
                if (peso > cupo)
                {
                    row.Delete();
                }
            }
            int count = dt.Rows.Count;
            int rnd = rnd1.Next(1, count);
            dtSolucion.ImportRow(dt.Rows[rnd]); 



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
        evaluar elementos
        seleccionar candidatos
        agregar elemento a solucion
        checar si solucion esta completa
        }
    }
*/