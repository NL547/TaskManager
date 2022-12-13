using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Process[] proc;

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllProcess();
        }

        private void Завершить_Click(object sender, EventArgs e)
        {
            try
            {
                proc[listBox1.SelectedIndex].Kill();
                GetAllProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messege", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void запуститьНовыйПроцессToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form2 form = new Form2())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    GetAllProcess();
            }
        }

        void GetAllProcess()
        {
            proc = Process.GetProcesses();
            listBox1.Items.Clear();
            foreach (Process p in proc)
                listBox1.Items.Add(p.ProcessName);
        }
    }
}
