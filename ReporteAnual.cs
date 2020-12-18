using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PetesBD
{
    public partial class ReporteAnual : Form
    {
        public BindingSource bSource = new BindingSource();
        public string connectionString = "SERVER=localhost;DATABASE=lote;UID=root;PASSWORD=;";
        public MySqlConnection mysqlCon;
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();

        public ReporteAnual()
        {
            InitializeComponent();

        }

       private void Form1_Load(object sender, EventArgs e)
        {
            
            //InitializeComponent();
            mysqlCon = new MySqlConnection(connectionString);
            this.updateGridViewContent();
            
            mysqlCon.Open();
            mysqlCon.Close();
       }

        private void button1_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog sfd = new SaveFileDialog() { Filter="PDF File|*.pdf", ValidateNames = true})
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 140f, 10f);
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        
                        doc.Open();
                        iTextSharp.text.Image JPG =  iTextSharp.text.Image.GetInstance("12046919_1726331607595049_7849083510719349652_n.jpg");
                        JPG.SetAbsolutePosition((PageSize.LETTER.Width - JPG.ScaledWidth)/2, (PageSize.LETTER.Height - JPG.ScaledHeight)/2);

                        JPG.ScalePercent(30f);
                        //JPG.SetAbsolutePosition(0, doc.PageSize.Height - JPG.ScaledHeight);
                        doc.Add(JPG);

                        
                        //richTextBox1.SelectAll();
                        //richTextBox1.SelectionHangingIndent = 20;
                        //doc.Add(new iTextSharp.text.Paragraph(richTextBox1.Text.PadLeft(20)));
                        PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
                        }

                        table.HeaderRows = 1;

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int k = 0; k < dataGridView1.Columns.Count; k++)
                            {
                                if (dataGridView1[k, i].Value != null)
                                {
                                    
                                    table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));

                                }
                            }
                        }
                        doc.Add(table);
                        //doc.Add(new iTextSharp.text.Paragraph(textBox1.Text.PadLeft(20)));
                    }
                    catch(Exception ex)
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
        private void updateGridViewContent()
        {
            mysqlCon.Open();
            string sqlSelectAll = "SELECT * FROM lote.lote2  ";

            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mysqlCon);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            bSource.DataSource = table;
            bSource.AllowNew = true;

            dataGridView1.DataSource = bSource;

            int n = Convert.ToInt32(dataGridView1.Rows.Count.ToString());
            for (int i = 0; i < n; i++)
            {
               // dataGridView1.Rows[i].Cells[9].ReadOnly = true;
            }
            mysqlCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recibos f2 = new Recibos();
            f2.Show();
        }

        class BooleanFormatter : IFormatProvider, ICustomFormatter
        {
            string trueString, falseString;
            public BooleanFormatter(string trueString, string falseString)
            {
                this.trueString = trueString;
                this.falseString = falseString;
            }
            public object GetFormat(System.Type type)
            {
                return this;
            }
            public string Format(string formatString, object arg, IFormatProvider formatProvider)
            {
                bool formatValue = Convert.ToBoolean(arg);
                if (formatValue)
                    return trueString;
                else
                    return falseString;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Login f3 = new Login();
            f3.Show();
        }
    }
}
