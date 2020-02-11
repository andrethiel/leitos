using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class cdi_agendados_centro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {

        }
        else
        {
            if (Request.Cookies == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Text = Request.QueryString["session"];
                if (Request.QueryString["session"] == null)
                {
                    Response.Redirect("../Default.aspx");
                }
                else
                {
                    
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            if (TextBox2.Text == "")
            {
                Label11.Text = "O campo da data não pode estar em branco";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
            }
            else
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select tbexames_centro.*, tblogin.nome_completo from tbexames_centro inner join tblogin on tbexames_centro.usuario_pedido = tblogin.Id where data_marcado=@data_marcado", cn);
                cmd.Parameters.AddWithValue("@data_marcado", TextBox2.Text);

                try
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                        cn.Dispose();
                    }
                    else
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        this.Label3.Text = this.GridView1.Rows.Count.ToString();
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                            cn.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select tbexames_centro.*, tblogin.nome_completo from tbexames_centro inner join tblogin on tbexames_centro.usuario_pedido = tblogin.Id where nome_pac like'" + TextBox1.Text+"'", cn);

            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
                else
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                        cn.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("centro.aspx?session=" + Label1.Text);
    }
}