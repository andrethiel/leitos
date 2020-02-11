using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
public partial class dados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            Label1.Text = Request.QueryString["session"];
            //id = Request.QueryString["tipo"].ToString();
            if (Request.QueryString["session"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                uti();
                posto();
                cc();
            }
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("principal.aspx?session=" + Label1.Text);
    }
    public void uti()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbpedido.*, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where data_libera=@data_libera order by uti, hora_libera", cn);
        cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            dr.Close();
            dt.Clear();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void posto()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbtransfere.*, tblogin.nome_completo from tbtransfere inner join tblogin on tbtransfere.usuario_pedido = tblogin.Id where not local='centro cirurgico' and data_libera=@data_libera", cn);
        cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            dr.Close();
            dt.Clear();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void cc()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbtransfere.*, tblogin.nome_completo from tbtransfere inner join tblogin on tbtransfere.usuario_pedido = tblogin.Id where local='Centro Cirurgico' and data_libera=@data_libera", cn);
        cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            GridView3.DataSource = dt;
            GridView3.DataBind();
            dr.Close();
            dt.Clear();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}