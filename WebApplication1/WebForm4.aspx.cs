using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    /// <summary>
    /// ExecuteReader, ExecuteNonQuery, ExecuteScalar
    /// </summary>
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADODBConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from Students where StudentName like @name";
                    cmd.Parameters.Add(new SqlParameter("@name", "%" + txtSearch.Text + "%"));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        gvResult.DataSource = dt;
                        gvResult.DataBind();
                        dr.Close();
                    }
                }
            }
        }

        //ExecuteScalar
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO [dbo].[Students]([StudentName],[StudentAge],[StudentNumber],[StudentAddress])
                             VALUES
                               (@Name
                               ,@Age,@studentNumber,@studentAddress);SELECT CAST(scope_identity() AS int);";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADODBConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@Name", txtName.Text));
                    cmd.Parameters.Add(new SqlParameter("@Age", txtAge.Text));
                    cmd.Parameters.Add(new SqlParameter("@studentNumber", txtNumber.Text));
                    cmd.Parameters.Add(new SqlParameter("@studentAddress", txtAddress.Text));

                    txtID.Text = cmd.ExecuteScalar().ToString();
                }
                btnSearch_Click(null, null);
            }
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string sql = @"update [Students] set [StudentName] = @Name, [StudentAge] = @Age ,[StudentNumber] = @studentNumber,[StudentAddress] = @studentAddress
                             where StudentID = @ID";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADODBConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@ID", txtE_ID.Text));
                    cmd.Parameters.Add(new SqlParameter("@Name", txtE_Name.Text));
                    cmd.Parameters.Add(new SqlParameter("@Age", txtE_Age.Text));
                    cmd.Parameters.Add(new SqlParameter("@studentNumber", txtE_Number.Text));
                    cmd.Parameters.Add(new SqlParameter("@studentAddress", txtE_Address.Text));
                    cmd.ExecuteNonQuery();
                }
                btnSearch_Click(null, null);
            }
        }

    }
}