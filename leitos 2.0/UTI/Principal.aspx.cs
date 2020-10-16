using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class UTI_Default : System.Web.UI.Page
{
    public static HttpCookie cookie, cookie_id;
    public static string id, valor;
    protected void Page_Load(object sender, EventArgs e)
    {
        cookie = Request.Cookies["local"];
        cookie_id = Request.Cookies["id"];

        Label10.Text = cookie.Value.ToString();

        if (Page.IsPostBack)
        {

        }
        else
        {
            leitos();
            exames();
        }
    }
    public void leitos()
    {
        //cookie = Request.Cookies["local"];
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbpedido.*, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where data_pedido='" + DateTime.Now.ToString("yyyy/MM/dd") + "'and uti='" + cookie.Value.ToString() + "' order by leito, hora_pedido desc", cn);
        try
        {
            cn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Close();
        }
    }

    public void exames()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido='" + DateTime.Now.ToString("yyyy/MM/dd") + "'and local='" + cookie.Value.ToString() + "' order by hora_pedido asc", cn);
        try
        {
            cn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater2.DataSource = ds.Tables[0];
            Repeater2.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Close();
        }
    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button1.Visible = false;
        Button2.Visible = true;
        id = e.CommandArgument.ToString();

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbexames where baixa = 'Exame agendado' and id=@id", cn);
        cmd.Parameters.AddWithValue("@id", id);
        try
        {
            cn.Open();

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Label1.Text = "Exame agendado não e possivel fazer o cancelamento. Para fazer o cancelamento favor entrar em contato com o centro de imagens";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error();", true);
                Response.AddHeader("Refresh", "4;URL=" + Request.RawUrl);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowPopup();", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button2.Visible = false;
        Button1.Visible = true;
        id = e.CommandArgument.ToString();

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbpedido where id=@id and leito IS NULL ", cn);
        cmd.Parameters.AddWithValue("@id", id);
        try
        {
            cn.Open();

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowPopup();", true);
            }
            else
            {
                Label1.Text = "Não e possivel fazer o cancelamento com o leito reservado. Para cancelar entre em contato com o gerenciamento de leitos para cancelar o pedido";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error();", true);
                Response.AddHeader("Refresh", "4;URL=" + Request.RawUrl);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("update tbpedido set leito='Alta Cancelada', usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where id=@id", cn);
        cmd.Parameters.AddWithValue("@usuario_libera", cookie_id.Value.ToString());
        cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Label1.Text = "Pedido de alta cancelado com sucesso";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso();", true);
            Response.AddHeader("Refresh", "4;URL=" + Request.RawUrl);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("update tbexames set baixa='Exame Cancelado', status='Exame Cancelado', usuario_cancela=@usuario_cancela, data_cancela=@data_cancela, hora_cancela=@hora_cancela where id=@id", cn);
        cmd.Parameters.AddWithValue("@usuario_cancela", cookie_id.Value.ToString());
        cmd.Parameters.AddWithValue("@data_cancela", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_cancela", DateTime.Now.ToShortTimeString());
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            cmd.ExecuteNonQuery();
            Label1.Text = "Exame cancelado com sucesso";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso();", true);
            Response.AddHeader("Refresh", "4;URL=" + Request.RawUrl);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Close();
        }
    }
}