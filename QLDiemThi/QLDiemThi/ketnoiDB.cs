using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Ex11_QLDiemThi
{
    internal class ketnoiDB
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1V993VR\\SQLEXPRESS;Initial Catalog=QLDiemThi;Integrated Security=True");

        public DataTable QLDiemThi(string sql)
        {
            try
            {
               
                conn.Open();
                DataTable dataTable = new DataTable();
                SqlDataAdapter Adapter = new SqlDataAdapter(sql, conn);
                Adapter.Fill(dataTable);
           
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex);
                return null;
            }
            finally
            {
                conn.Close ();
            }
        }
        public void update(string sql)
        {
            
            try
            {

                conn.Open();
                DataTable dataTable = new DataTable();
                SqlCommand cmd = new SqlCommand(sql, conn); 
                int row = cmd.ExecuteNonQuery();
                if(row > 0)
                {
                    MessageBox.Show("Thanh Cong");
                }
                else
                {
                    MessageBox.Show("Loi");
                }
                
            
            }
            catch(Exception ex)
            {
                MessageBox.Show("loi: "+ex);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
