using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Olympic_Village
{
    public class storeddata
    {


        SqlConnection con;
        public storeddata()
        {
            string mycon = @"Data Source=DESKTOP-81UEU54\SQLEXPRESS;Integrated Security=SSPI;database = olympic_village";
            con = new SqlConnection(mycon);
        }

        // this function insert data into table of database
        public void insertInTable(string query)
        {

            try
            {
                con.Open();
                SqlCommand sqadp = new SqlCommand(query, con);
                sqadp.ExecuteNonQuery();
                MessageBox.Show("تم العملية بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }



        }

        // this function delete data from table of database
        public void deletfromTable(string query)
        {
            try
            {
                con.Open();
                SqlDataAdapter sqadp = new SqlDataAdapter(query, con);
                sqadp.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("تم الحذف بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        //// this function select data from table of database and put it datagridveiw
        public void showdata(DataGridView datagrid, string query, int numOfItem,int startofsqltable,int datagridstart)
        {
            try
            {

                con.Open();
                SqlDataAdapter sqldata = new SqlDataAdapter(query, con);
                datagrid.Rows.Clear();
                DataTable datable = new DataTable();
                sqldata.Fill(datable);
                foreach (DataRow item in datable.Rows)
                {
                    int n = datagrid.Rows.Add();
                    for (int i = startofsqltable, j = datagridstart; i < numOfItem; i++,j++)
                    {
                        datagrid.Rows[n].Cells[j].Value = item[i].ToString();
                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        public void updateinTable(string query)
        {
            try
            {
                con.Open();
                SqlDataAdapter sqadp = new SqlDataAdapter(query, con);
                sqadp.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("تم التعديل بنجاح");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

        }





        // this function to create pdf  and open folder to store and save in pc
        public void creatpdf(DataGridView datagrid, string filename)
        {
            try
            {
                BaseFont bsf = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, true);
                PdfPTable pdftab = new PdfPTable(datagrid.Columns.Count);


                pdftab.DefaultCell.Padding = 3;
                pdftab.WidthPercentage = 100;
                pdftab.HorizontalAlignment = Element.ALIGN_RIGHT;

                pdftab.DefaultCell.BorderWidth = 1;

                iTextSharp.text.Font text = new iTextSharp.text.Font(bsf, 10, iTextSharp.text.Font.NORMAL);



                foreach (DataGridViewColumn item in datagrid.Columns)
                {

                    PdfPCell cell = new PdfPCell(new Phrase(item.HeaderText, text));

                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);

                    pdftab.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    pdftab.AddCell(cell);
                }
                foreach (DataGridViewRow row in datagrid.Rows)
                {
                    foreach (DataGridViewCell cel in row.Cells)
                    {

                        pdftab.AddCell(new Phrase(cel.Value.ToString(), text));
                        pdftab.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    }

                }

                var svfd = new SaveFileDialog();
                svfd.FileName = filename;
                svfd.DefaultExt = ".pdf";
                if (svfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream filst = new FileStream(svfd.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(doc, filst);
                        doc.Open();
                        doc.Add(pdftab);
                        doc.Close();
                        filst.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // this function to create othr pdf  and open folder to store and save in pc
        public void creatotherpdf(DataGridView datagrid, string filename, string headertext)
        {
            try
            {
                BaseFont bsf = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, true);
                PdfPTable pdftab = new PdfPTable(datagrid.Columns.Count - 1);


                pdftab.DefaultCell.Padding = 3;
                pdftab.WidthPercentage = 100;
                pdftab.HorizontalAlignment = Element.ALIGN_RIGHT;

                pdftab.DefaultCell.BorderWidth = 1;

                iTextSharp.text.Font text = new iTextSharp.text.Font(bsf, 10, iTextSharp.text.Font.NORMAL);



                foreach (DataGridViewColumn item in datagrid.Columns)
                {
                    if (item.HeaderText != headertext)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(item.HeaderText, text));

                        cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);

                        pdftab.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        pdftab.AddCell(cell);
                    }
                }
                foreach (DataGridViewRow row in datagrid.Rows)
                {
                    int i = 0;
                    foreach (DataGridViewCell cel in row.Cells)
                    {

                        if (row.Cells.Count - 1 > i)
                        {
                            pdftab.AddCell(new Phrase(cel.Value.ToString(), text));
                            pdftab.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                        }
                        i++;
                    }

                }

                var svfd = new SaveFileDialog();
                svfd.FileName = filename;
                svfd.DefaultExt = ".pdf";
                if (svfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream filst = new FileStream(svfd.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(doc, filst);
                        doc.Open();
                        doc.Add(pdftab);
                        doc.Close();
                        filst.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // this function to create excel  and open folder to store and save in pc

        public void createExcle(DataGridView datagrid)
        {
            //try
            //{
            //    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //    Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            //    Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            //    worksheet = workbook.Sheets["sheet1"];
            //    worksheet = workbook.ActiveSheet;
            //    worksheet.Name = "databaseSchool";
            //    for (int i = 1; i < datagrid.Columns.Count + 1; i++)
            //    {
            //        worksheet.Cells[1, i] = datagrid.Columns[i - 1].HeaderText;
            //    }
            //    for (int i = 0; i < datagrid.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < datagrid.Columns.Count; j++)
            //        {
            //            worksheet.Cells[i + 2, j + 1] = datagrid.Rows[i].Cells[j].Value.ToString();
            //        }

            //    }
            //    var safefile = new SaveFileDialog();
            //    safefile.FileName = "output";
            //    safefile.DefaultExt = ".xlsx";
            //    if (safefile.ShowDialog() == DialogResult.OK)
            //    {
            //        workbook.SaveAs(safefile.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //    }
            //    app.Quit();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        // this function open brows to selecte photo from pc

        public void openbrows(PictureBox pbox)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image file(*.png;*.jpg;*.bmp;*.gif;)|*.png;*.jpg;*.bmp;*.gif;";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = new Bitmap(op.FileName);
            }
        }


        public byte[] savephote(PictureBox pbox)
        {
            MemoryStream memophoto = new MemoryStream();
            pbox.Image.Save(memophoto, pbox.Image.RawFormat);
            return memophoto.GetBuffer();
        }

    }
}
