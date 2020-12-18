using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PetesBD
{
    public partial class Recibos : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlDataReader mdr;
        MySqlCommand command;

        public Recibos()
        {
            InitializeComponent();
        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            Cliente c1 = new Cliente();
            renta r1 = new renta();

             r1.ellote = int.Parse(txtCosto.Text);
                //r1.lazona = Double.Parse(txtZona.Text);

                String q = r1.ellote.ToString();
                txtTotal.Text = ("$")+q;

                rtRecibo.AppendText("\t\t Pete's Camp " + "\n" + "-------------------------------------------------------------------------" + "\n");
                rtRecibo.AppendText("Nombre" + "\t\t\t" + txtNombre.Text + "\n");
                rtRecibo.AppendText("Apellido" + "\t\t\t" + txtApellido.Text + "\n");
                rtRecibo.AppendText("Domiclio" + "\t\t\t" + txtDomicilio.Text + "\n");
                rtRecibo.AppendText("Codigo Postal" + "\t\t\t" + txtCp.Text + "\n");
                rtRecibo.AppendText("Ciudad" + "\t\t\t" + txtCiudad.Text + "\n");
                rtRecibo.AppendText("Lote" + "\t\t\t" + txtlote2.Text + "\n");
                rtRecibo.AppendText("Zona" + "\t\t\t" + cbZona.Text + "\n");
                rtRecibo.AppendText("-------------------------------------------------------------------------" + "\n");
                rtRecibo.AppendText("Costo" + "\t\t\t" + txtTotal.Text + "\n"); 
        }
        */
        /*
        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            rtRecibo.Clear();
            cbZona.Text = "";
        }
        */
        private void Form2_Load(object sender, EventArgs e)
        {
            //cbZona.Items.Add("A");
            //cbZona.Items.Add("B");
            //cbZona.Items.Add("C");
            //cbZona.Items.Add("D");
            //cbZona.Items.Add("E");
        }
        

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Text = "";
                    else
                        func(control.Controls); 
            };
            func(Controls);
        }
        /*
        private void button3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.LETTER, 10, 10, 42, 35);
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        iTextSharp.text.Image JPG = iTextSharp.text.Image.GetInstance("12046919_1726331607595049_7849083510719349652_n.jpg");
                        JPG.SetAbsolutePosition((PageSize.LETTER.Width - JPG.ScaledWidth), (JPG.ScaledHeight));

                        JPG.ScalePercent(30f);
                        //JPG.SetAbsolutePosition(0, doc.PageSize.Height - JPG.ScaledHeight);
                        doc.Add(JPG);
                        rtRecibo.SelectAll();
                        rtRecibo.SelectionHangingIndent = 20;
                        doc.Add(new iTextSharp.text.Paragraph(rtRecibo.Text.PadLeft(20)));
                         
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
        }
        */
        

        private void llenarcampos()
        {
            /*
            if (txtLote.Text == "1")
            {
                txtNombre.Text = "Alvaro";
                txtApellido.Text = "Calderon";
                txtCiudad.Text = "Ensenada";
                txtDomicilio.Text = "Lago Texcoco";
                txtCp.Text = "22890";
                txtCosto.Text = "500";
                cbZona.Text = "A";
                txtlote2.Text = "1";
                checkBox1.Checked = false;       
            }
            else if (txtLote.Text == "2")
            {
                txtNombre.Text = "Yohali";
                txtApellido.Text = "Murillo";
                txtCiudad.Text = "Bahia Tortugas";
                txtDomicilio.Text = "Noc";
                txtCp.Text = "34234";
                txtCosto.Text = "250";
                cbZona.Text = "C";
                txtlote2.Text = "2";
                checkBox1.Checked = false;
            }
            else if (txtLote.Text == "3")
            {
                txtNombre.Text = "Probando";
                txtApellido.Text = "Prueba";
                txtCiudad.Text = "Juejue";
                txtDomicilio.Text = "Noc";
                txtCp.Text = "12345";
                txtCosto.Text = "1000";
                cbZona.Text = "B";
                txtlote2.Text = "3";
                checkBox1.Checked = false;
            }
            else if (txtLote.Text == "4")
            {
                txtNombre.Text = "Yohali";
                txtApellido.Text = "Murillo";
                txtCiudad.Text = "Bahia Tortugas";
                txtDomicilio.Text = "Noc";
                txtCp.Text = "34234";
                txtCosto.Text = "250";
                cbZona.Text = "C";
                txtlote2.Text = "2";
                checkBox1.Checked = true;
            }
            else if (txtLote.Text == "5")
            {
                txtNombre.Text = "Probando";
                txtApellido.Text = "Prueba";
                txtCiudad.Text = "Juejue";
                txtDomicilio.Text = "Noc";
                txtCp.Text = "12345";
                txtCosto.Text = "1000";
                cbZona.Text = "B";
                txtlote2.Text = "3";
                checkBox1.Checked = true;
            }
            else if (txtLote.Text == "2")
            {
                txtNombre.Text = "Alvaro";
                txtApellido.Text = "Calderon";
                txtCiudad.Text = "Ensenada";
                txtDomicilio.Text = "Lago Texcoco";
                txtCp.Text = "22890";
                txtCosto.Text = "500";
                cbZona.Text = "A";
                txtlote2.Text = "1";
                checkBox1.Checked = true;
            }
            else
            {
                MessageBox.Show("Lote no encontrado");
            }
            */

        }
        
        private void txtLote_TextChanged(object sender, EventArgs e)
        {
            //llenarcampos();
        }

        private void generar_Click(object sender, EventArgs e)
        {
            Cliente c1 = new Cliente();
            renta r1 = new renta();

            r1.ellote = int.Parse(txtCosto.Text);
            //r1.lazona = Double.Parse(txtZona.Text);

            String q = r1.ellote.ToString();
            txtTotal.Text = ("$") + q;

            llenarRecibos();
            if (checkBox1.Checked)
            {
                rtRecibo.AppendText("Pagado");
            }
            else
            {
                rtRecibo.AppendText("Pago pendiente");
            }
            
        }

        private void reset_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            rtRecibo.Clear();
            txtZona.Text = "";
        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.LETTER, 10, 10, 42, 35);
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        iTextSharp.text.Image JPG = iTextSharp.text.Image.GetInstance("12046919_1726331607595049_7849083510719349652_n.jpg");
                        JPG.SetAbsolutePosition((PageSize.LETTER.Width - JPG.ScaledWidth), (JPG.ScaledHeight));

                        JPG.ScalePercent(30f);
                        //JPG.SetAbsolutePosition(0, doc.PageSize.Height - JPG.ScaledHeight);
                        doc.Add(JPG);
                        
                        rtRecibo.SelectAll();
                        //rtRecibo.SelectionHangingIndent = 20;
                        doc.Add(new iTextSharp.text.Paragraph(rtRecibo.Text.PadLeft(20)));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void nuevoCliente_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
            }
            else
            {
                MessageBox.Show("Guardado con exito");
            }
        }

        private void txtLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Favor de ingresar solo numeros");
            }
            
        }

        private void llenarRecibos()
        {
            rtRecibo.AppendText("\t\t Pete's Camp " + "\n" + "-------------------------------------------------------------------------" + "\n");
            rtRecibo.AppendText("Fecha " + "\t\t\t" + dateTimePicker1.Text + "\n");
            rtRecibo.AppendText("Nombre " + "\t\t\t" + txtNombre.Text + "\n");
            rtRecibo.AppendText("Apellido " + "\t\t\t" + txtApellido.Text + "\n");
            rtRecibo.AppendText("Domiclio " + "\t\t\t" + txtDomicilio.Text + "\n");
            rtRecibo.AppendText("Codigo Postal " + "\t\t\t" + txtCp.Text + "\n");
            rtRecibo.AppendText("Ciudad " + "\t\t\t" + txtCiudad.Text + "\n");
            //rtRecibo.AppendText("Lote " + "\t\t\t" + txtlote2.Text + "\n");
            rtRecibo.AppendText("Zona " + "\t\t\t" + txtZona.Text + "\n");
            rtRecibo.AppendText("-------------------------------------------------------------------------" + "\n");
            rtRecibo.AppendText("Costo" + "\t\t\t" + txtTotal.Text + "\n");
        }
        
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            
            string insertQuery = "INSERT INTO lote.lote2(idLote,Nombre,Apellido,Ciudad,CodigoPostal,Fecha,Precio,Estado,Zona,Domicilio) " +
                "VALUES('" + txtLote.Text + "','" + txtNombre.Text + "','" + txtApellido.Text + "','" + txtCiudad.Text + "','" + txtCp.Text + "'," +
                "'" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "','" + txtCosto.Text + "','" + checkBox1.Checked.ToString() + "','" + txtZona.Text + "','" + txtDomicilio.Text + "') ";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos guardados");
                }
                else
                {
                    MessageBox.Show("Datos no Guardados");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            connection.Close();

        }


        private void btn_insertar_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM lote.lote2 WHERE idlote = " + txtLote.Text;
                connection.Open();
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    txtLote.Text = "";
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtCiudad.Text = "";
                    txtCp.Text = "";
                    txtCosto.Text = "";
                    txtZona.Text = "";
                    txtDomicilio.Text = "";
                    rtRecibo.Clear();
                    
                    MessageBox.Show("Cliente eliminado");
                }
                else
                {
                    MessageBox.Show("Cliente no eliminado");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE lote.lote2 SET Nombre='" + txtNombre.Text + "', Apellido='" + txtApellido.Text +
                "', Ciudad='" + txtCiudad.Text + "', CodigoPostal='" + txtCp.Text + "', Fecha='" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'," +
                " Precio='" + txtCosto.Text + "', Estado='" + checkBox1.Checked.ToString() + "', Zona='" + txtZona.Text + "', Domicilio='" + txtDomicilio.Text + "' WHERE idlote=" + int.Parse(txtLote.Text);
            connection.Open();
            MySqlCommand command = new MySqlCommand(updateQuery, connection);
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos modificados");
                }
                else
                {
                    MessageBox.Show("Datos no modificados");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            connection.Open();
            string selectQuery = "SELECT Nombre,Apellido,Ciudad,Domicilio,CodigoPostal,Precio,Zona,Estado FROM lote.lote2 WHERE idlote=" + int.Parse(txtLote.Text);
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
           if (mdr.Read())
           {
                txtNombre.Text = mdr.GetString("Nombre");
                txtApellido.Text = mdr.GetString("Apellido");
                txtCiudad.Text = mdr.GetString("Ciudad");
                txtCp.Text = mdr.GetString("CodigoPostal");
                txtCosto.Text = mdr.GetInt32("Precio").ToString();
                txtDomicilio.Text = mdr.GetString("Domicilio");
                txtZona.Text = mdr.GetString("Zona");
                checkBox1.Checked = mdr.GetBoolean("Estado");

            }
           else
           {
               txtLote.Text = "";
               txtNombre.Text = "";
               txtApellido.Text = "";
               txtCiudad.Text = "";
               txtCp.Text = "";
               txtCosto.Text = "";
               txtZona.Text = "";
               txtDomicilio.Text = "";
               MessageBox.Show("No hay lote con este id");
            }
            connection.Close();
            
        }
     }
}
    


