using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace AccountCreator
{
    public partial class Form1 : Form
    {
        private SemaphoreSlim semaphoreSlim;
        private Creator creator;
        private Thread RegThread;

        public Form1()
        {
            InitializeComponent();
            semaphoreSlim = new SemaphoreSlim(1);
            semaphoreSlim.Wait();
            
            creator = new Creator(semaphoreSlim, this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*[!@#$%^*+=-])(?=.*[0-9]).{6,8}",
                            RegexOptions.Compiled |
                        RegexOptions.CultureInvariant);

            if(!regex.IsMatch(txtPassword.Text) || txtPassword.Text.Contains(txtUsername.Text))
            {
                MessageBox.Show("Wrong password, Password must be 6-8 characters, including at least one letter, number, symbol. Cannot include ID or space..");
                return;
            }

            if (btnStart.Text.Equals("Start"))
            {
                this.btnStart.Enabled = false;
                this.numericUpDown1.ReadOnly = true;

                this.btnStart.Text = "Stop";
                this.progressBar1.Value = 0;
                this.progressBar1.Maximum = Convert.ToInt32(this.numericUpDown1.Value);
                this.label4.Text = "0/" + Convert.ToInt32(this.numericUpDown1.Value);

                RegThread = new Thread(() => creator.RegistrationThread(Convert.ToInt32(this.numericUpDown1.Value)));
                RegThread.Start();

                this.btnStart.Enabled = true;
            }
            else //stop
            {
                this.btnStart.Enabled = false;

                RegThread.Abort();

                this.btnStart.Text = "Start";
                this.numericUpDown1.ReadOnly = false;
                this.btnStart.Enabled = true;
            }
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                semaphoreSlim.Release();
                e.Handled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(RegThread != null)
                RegThread.Abort();
        }
    }
}
