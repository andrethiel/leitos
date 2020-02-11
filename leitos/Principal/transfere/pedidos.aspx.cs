using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Leitos_Principal_Pedidouti_pedidos : System.Web.UI.Page
{
    string id, texto, linha, teste;
    SqlDataReader dr;
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            if(cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
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
                TextBox5.Text = Request.QueryString["session"];
                if (Request.QueryString["session"] == null)
                {
                    Response.Redirect("../../Default.aspx");
                }
                else
                {
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("select tblogin.*, tblocal.local_setor, tblog.session from tblogin inner join tblocal on tblogin.localt = tblocal.id_local inner join tblog on tblogin.Id = tblog.usuario where tblog.session=@session", cn);
                    cmd.Parameters.AddWithValue("@session", Label1.Text);

                    try
                    {
                        cn.Open();
                        SqlDataReader dr = null;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            id = dr["id"].ToString();
                            teste = dr["local_setor"].ToString();
                            Label7.Text = teste.Trim();
                            preenche();
                            exame();
                            social();
                        }
                        cn.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }

    public void preenche()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbtransfere where usuario_pedido=@usuario_pedido and data_pedido=@data_pedido", cn);
        cmd.Parameters.AddWithValue("@usuario_pedido", id);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            cn.Open();
            SqlDataReader le = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(le);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cn.Close();
            cn.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("leito.aspx?session=" + Label1.Text);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("pedidos.aspx?session=" + Label1.Text);
    }
    public void altera()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("update tbtransfere set autoriza = 's' where num_atendimento = @num_atendimento", cn);
        cmd.Parameters.AddWithValue("@num_atendimento", texto);

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        catch(Exception ex)
        {
            throw ex;
        }

    }
    [System.Web.Services.WebMethod]
    public static string GetCurrentTime(string name)
    {
        return "Hello " + name + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("examecdi.aspx?session=" + Label1.Text);
    }
    public void exame()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido=@data_pedido and local=@local order by baixa", cn);
        cmd.Parameters.AddWithValue("@local", Label7.Text);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            cn.Open();
            SqlDataReader le = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(le);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            cn.Close();
            cn.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            string valor = DataBinder.Eval(e.Row.DataItem, "status").ToString();

            if (valor.Trim() == "Exame Cancelado")
            {
                e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
            }
        }
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../default.aspx");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "noback()");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Session["setor"] = "Posto";
        Response.Redirect("../../alterausuario.aspx?session=" + Label1.Text);
        
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("asocial.aspx?session=" + Label1.Text);
    }

    public void social()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbaltas.*, tblogin.nome_completo from tbaltas inner join tblogin on tbaltas.usuario = tblogin.Id where data_alta=@data_alta and posto=@posto order by data_alta", cn);
        cmd.Parameters.AddWithValue("@posto", Label7.Text);
        cmd.Parameters.AddWithValue("@data_alta", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            cn.Open();
            SqlDataReader le = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(le);
            GridView4.DataSource = dt;
            GridView4.DataBind();
            cn.Close();
            cn.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}