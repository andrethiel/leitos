using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;

public partial class UTI_Default : System.Web.UI.Page
{
    public static HttpCookie cookie, cookie_id;
    public static string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        cookie = Request.Cookies["local"];
        cookie_id = Request.Cookies["id"];

        Label10.Text = cookie.Value.ToString();

        if (Page.IsPostBack)
        {
            if (cookie.Value.ToString() == "Centro Cirurgico")
            {
                Repeater2.Visible = false;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "<script>document.getElementById('exames').style.display = 'none'</script>", false);
            }
        }
        else
        {
            leitos();
            exames();
            social();
        }
    }
    public void leitos()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select * from tbtransfere where data_pedido='" + DateTime.Now.ToString("yyyy/MM/dd") + "'and local='" + cookie.Value.ToString() + "' order by leito, hora_pedido desc", cn);
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
    public void social()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select * from tbaltas where data_alta='" + DateTime.Now.ToString("dd/MM/yyyy") + "' and posto='" + cookie.Value.ToString() + "' order by hora asc", cn);
        try
        {
            cn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater3.DataSource = ds.Tables[0];
            Repeater3.DataBind();
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

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        leitos();
        exames();
        social();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button1.Visible = true;
        Button2.Visible = false;
        Button3.Visible = false;
        id = e.CommandArgument.ToString();

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbtransfere where id=@id and leito IS NULL ", cn);
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
        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowPopup();", true);
    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button1.Visible = false;
        Button2.Visible = true;
        Button3.Visible = false;
        id = e.CommandArgument.ToString();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbexames where baixa='Exame agendado' and id=@id", cn);
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
        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowPopup();", true);
    }

    protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button1.Visible = false;
        Button2.Visible = false;
        Button3.Visible = true;

        id = e.CommandArgument.ToString();

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbexames where status = 'Aguardando Ligação' and id=@id", cn);
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
                Label1.Text = "Não e possivel fazer o cancelamento, já foi entrado em contato. Para fazer o cancelamento favor entrar em contato com a assistente social";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error();", true);
                Response.AddHeader("Refresh", "4;URL=" + Request.RawUrl);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowPopup();", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowPopup();", true);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("update tbtransfere set leito='Alta Cancelada', usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where id=@id", cn);
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
        SqlCommand cmd = new SqlCommand("update tbexames set baixa='Exame agendado', status='Exame Cancelado', usuario_cancela=@usuario_cancela, data_cancela=@data_cancela, hora_cancela=@hora_cancela where id=@id", cn);
        cmd.Parameters.AddWithValue("@usuario_cancela", cookie_id.Value.ToString());
        cmd.Parameters.AddWithValue("@data_cancela", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_cancela", DateTime.Now.ToShortTimeString());
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            cn.Open();
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("update tbaltas set status=@status where id=@id", cn);
        cmd.Parameters.AddWithValue("@status", "Alta Cancelada");
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Label1.Text = "Alta assistente social cancelado com sucesso";
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