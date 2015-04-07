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
    /// DataSet
    /// </summary>
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADODBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from Students where StudentName like @name";
                    cmd.Parameters.Add(new SqlParameter("@name", "%" + txtSearch.Text + "%"));

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        gvResult.DataSource = ds;
                        gvResult.DataMember = "Table";
                        gvResult.DataBind();
                        da.Fill(ds);
                    }
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADODBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from Students";
                    cmd.Parameters.Add(new SqlParameter("@name", "%" + txtSearch.Text + "%"));

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        //自動產生Insert, Update, DeleteCommand
                        SqlCommandBuilder builder = new SqlCommandBuilder(da);
                        //builder.GetInsertCommand()
                        //builder.GetUpdateCommand()
                        //builder.GetDeleteCommand()

                        DataSet ds = new DataSet();
                        ds.Clear();
                        da.Fill(ds);
                        DataTable dt = ds.Tables["Table"];
                        DataRow dr = dt.NewRow();
                        dr["StudentName"] = txtName.Text;
                        dr["StudentAge"] = txtAge.Text;
                        dr["StudentNumber"] = txtNumber.Text;
                        dr["StudentAddress"] = txtAddress.Text;
                        dt.Rows.Add(dr);
                        da.Update(dt);

                        btnSearch_Click(null, null);
                    }
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADODBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from students";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        //自動產生Insert, Update, DeleteCommand
                        SqlCommandBuilder builder = new SqlCommandBuilder(da);
                        //builder.GetInsertCommand()
                        //builder.GetUpdateCommand()
                        //builder.GetDeleteCommand()

                        DataSet ds = new DataSet();
                        ds.Clear();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        DataRow dr = dt.Select(string.Format("StudentID = {0}", txtE_ID.Text)).First();
                        dr["StudentName"] = txtE_Name.Text;
                        dr["StudentAge"] = txtE_Age.Text;
                        dr["StudentNumber"] = txtE_Number.Text;
                        dr["StudentAddress"] = txtE_Address.Text;
                        da.Update(dt);

                        btnSearch_Click(null, null);
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADODBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from Students";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        //自動產生Insert, Update, DeleteCommand
                        SqlCommandBuilder builder = new SqlCommandBuilder(da);
                        //builder.GetInsertCommand()
                        //builder.GetUpdateCommand()
                        //builder.GetDeleteCommand()

                        DataSet ds = new DataSet();
                        ds.Clear();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        DataRow dr = dt.Select(string.Format("StudentID = {0}", txtD_ID.Text)).First();
                        dr.Delete();
                        da.Update(dt);

                        btnSearch_Click(null, null);
                    }
                }
            }
        }
    }
}