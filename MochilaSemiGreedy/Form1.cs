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
        int n = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


       


        private void generar_Registro(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add(n, this.textBox1.Text, Convert.ToInt32(this.numericUpDown2.Text), Convert.ToInt32(this.numericUpDown3.Text));
            n++;
        }

        private void generar_Soluciones(object sender, EventArgs e)
        {
            for(int nSolucion = 1; nSolucion <= this.txtNumSol.Value; nSolucion++)
            {
                generar_Solucion();
            }
            
        }

        public void generar_Solucion()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                String cellText = row.Cells[i].Text;
            }
        }

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