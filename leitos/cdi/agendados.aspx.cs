using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Principal_principalCDI : System.Web.UI.Page
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
                    resso();
                    tomo();
                    raio();
                    eco();
                    bio();
                    angioresso();
                    angiotomo();
                }
            }
        }
    }
    public void resso()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where baixa = 'Exame agendado' and data_pedido=@data_pedido and especial='Ressonância'", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

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
    public void tomo()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where baixa = 'Exame agendado' and data_pedido=@data_pedido and especial='Tomografia'", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

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
                GridView2.DataSource = dt;
                GridView2.DataBind();
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
    public void raio()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where baixa = 'Exame agendado' and data_pedido=@data_pedido and especial='Raio-X'", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

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
                GridView3.DataSource = dt;
                GridView3.DataBind();
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
    public void eco()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where baixa = 'Exame agendado' and data_pedido=@data_pedido and especial='Ecografia'", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

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
                GridView4.DataSource = dt;
                GridView4.DataBind();
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
    public void bio()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where baixa = 'Exame agendado' and data_pedido=@data_pedido and especial='Biópsias'", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

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
                GridView5.DataSource = dt;
                GridView5.DataBind();
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
    public void angioresso()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where baixa = 'Exame agendado' and data_pedido=@data_pedido and especial='Angioressonâncias'", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

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
                GridView6.DataSource = dt;
                GridView6.DataBind();
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
    public void angiotomo()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where baixa = 'Exame agendado' and data_pedido=@data_pedido and especial='Angiotomografias'", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

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
                GridView7.DataSource = dt;
                GridView7.DataBind();
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("principalCDI.aspx?session=" + Label1.Text);
    }
}