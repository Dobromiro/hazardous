using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using MySql.Data.MySqlClient;
using System.Media;


namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        string dataOUT;
        string solenoid;
        string DataIN;
        //char DataIN;
        private object file;
       // MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.AddRange(ports);

            string[] ports2 = SerialPort.GetPortNames();
           

            chBoxAddToOldData.Checked = true;
            chBoxAlwaysUpdate.Checked = false;

            //connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=testdb");
          //  connection.Open();

            // automatyka

            try
            {
                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = Convert.ToInt32(CBoxBaudRate.Text);
                serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBits.Text);

                serialPort1.Open();
                progressBar1.Value = 100;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {

               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = Convert.ToInt32(CBoxBaudRate.Text);
                serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBits.Text);

                serialPort1.Open();
                progressBar1.Value = 100; 
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar1.Value = 0;

            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                dataOUT = tBoxDataIn.Text;
                //serialPort1.WriteLine(dataOUT);
                serialPort2.Write(dataOUT);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxAlwaysUpdate.Checked)
            {
                chBoxAlwaysUpdate.Checked = true;
                chBoxAddToOldData.Checked = false;
            }
        }



        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataIN = serialPort1.ReadExisting();
            //this.Invoke(new EventHandler(ShowData));
            this.Invoke(new EventHandler(ShowData));
            if (DataIN == "1\r\n\r")
             {
                
                SoundPlayer splayer = new SoundPlayer(@"fail.wav");
                splayer.Play();
             }




            /* using (var cmd = new MySqlCommand())
             {
                 DateTime localDate = DateTime.Now;
                 string date = DateTime.Now.ToString("yyyy-MM-dd ");


                 cmd.Connection = connection;
                 cmd.CommandText = "INSERT INTO tab (`ID`, `date_`) VALUES (@id, @DATE)";
                 cmd.Parameters.AddWithValue("@id", DataIN);
                 cmd.Parameters.AddWithValue("@DATE", date);
                 //cmd.Parameters.AddWithValue("@date", DateS);
                 cmd.ExecuteNonQuery();

             }*/

        }

        private void ShowData(object sender, EventArgs e)
        {
            
            if(chBoxAlwaysUpdate.Checked)
            {
                tBoxDataIn.Text = DataIN;
            }
            else if(chBoxAddToOldData.Checked)
            {
                tBoxDataIn.Text += DataIN;
            }
        }

        private void chBoxAddToOldData_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxAddToOldData.Checked)
            {
                chBoxAlwaysUpdate.Checked = false;
                chBoxAddToOldData.Checked = true;

            }
        }

        private void cBoxCOMPORT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cBoxDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tBoxDataIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
               

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort2.PortName = cBoxCOMPORT.Text;
                serialPort2.BaudRate = Convert.ToInt32(CBoxBaudRate.Text);
                serialPort2.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                serialPort2.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                serialPort2.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBits.Text);

                serialPort2.Open();
              
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
              
                //serialPort1.WriteLine(dataOUT);
                serialPort2.Write(dataOUT);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataIN = serialPort2.ReadExisting();
            if (serialPort1.IsOpen && DataIN == "79D13F98")
            {
                solenoid = "1";
                dataOUT = "OK";
                //serialPort1.WriteLine(dataOUT);
                serialPort1.Write(solenoid);
                //serialPort1.WriteLine("");
                //solenoid = "0";
            }
            //this.Invoke(new EventHandler(ShowData));
            this.Invoke(new EventHandler(ShowData));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SoundPlayer splayer = new SoundPlayer(@"C:\Users\kierownik\Desktop\fail.wav");
            SoundPlayer splayer = new SoundPlayer(@"fail.wav");
            splayer.Play();
        }

        private void btnClearDataIn_Click(object sender, EventArgs e)
        {

        }
    }
}
