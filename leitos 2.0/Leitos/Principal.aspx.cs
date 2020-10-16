using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;

public partial class Leitos_Principal : System.Web.UI.Page
{
    public static string num_atendimento, id, unidade, complemento, setor;
    public static string[] valores;

    public static HttpCookie cookie_local, cookie_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Visible = true;
        cookie_local = Request.Cookies["local"];
        cookie_id = Request.Cookies["id"];
        if (Page.IsPostBack)
        {
            
        }
        else
        {
            uco();
            lilas();
            azul();
            verde();
            cc();
            postos();
            altas_cancelada();
        }
    }
    public void uco()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbpedido.*, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where data_pedido = '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and tbpedido.uti = 'UTI Laranja' and tbpedido.leito IS NULL order by leito, hora_pedido desc", cn);

        cn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        Repeater1.DataSource = ds.Tables[0];
        Repeater1.DataBind();
        cn.Close();
    }
    public void azul()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbpedido.*, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where data_pedido = '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and tbpedido.uti = 'UTI Azul' and tbpedido.leito IS NULL order by leito, hora_pedido desc", cn);

        cn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        Repeater2.DataSource = ds.Tables[0];
        Repeater2.DataBind();
        cn.Close();
    }
    public void lilas()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbpedido.*, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where data_pedido = '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and tbpedido.uti = 'UTI Lilas' and tbpedido.leito IS NULL order by leito, hora_pedido desc", cn);

        cn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        Repeater3.DataSource = ds.Tables[0];
        Repeater3.DataBind();
        cn.Close();
    }
    public void verde()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbpedido.*, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where data_pedido = '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and tbpedido.uti = 'UTI Verde' and tbpedido.leito IS NULL order by leito, hora_pedido desc", cn);

        cn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        Repeater4.DataSource = ds.Tables[0];
        Repeater4.DataBind();
        cn.Close();
    }
    public void cc()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbtransfere.*, tblogin.nome_completo from tbtransfere inner join tblogin on tbtransfere.usuario_pedido = tblogin.Id where data_pedido = '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and tbtransfere.Local = 'Centro Cirurgico' and tbtransfere.leito IS NULL order by leito, hora_pedido desc", cn);

        cn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        Repeater5.DataSource = ds.Tables[0];
        Repeater5.DataBind();
        cn.Close();
    }
    public void postos()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbtransfere.*, tblogin.nome_completo from tbtransfere inner join tblogin on tbtransfere.usuario_pedido = tblogin.Id where data_pedido = '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and not tbtransfere.local = 'Centro Cirurgico' and tbtransfere.leito IS NULL order by leito, hora_pedido desc", cn);

        cn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        Repeater6.DataSource = ds.Tables[0];
        Repeater6.DataBind();
        cn.Close();
    }
    public void altas_cancelada()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbpedido.leito, tbpedido.num_atendimento, tbpedido.nome_pac, tbpedido.uti, tbpedido.box, tbpedido.data_libera, tbpedido.hora_libera, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where data_pedido = '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and leito='Alta Cancelada'" +
            "union select tbtransfere.leito, tbtransfere.num_atendimento, tbtransfere.nome_pac, tbtransfere.Local, tbtransfere.quarto, tbtransfere.data_libera, tbtransfere.hora_libera, tblogin.nome_completo from tbtransfere inner join tblogin on tbtransfere.usuario_pedido = tblogin.Id where data_pedido = '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and leito='Alta Cancelada'", cn);


        cn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        Repeater7.DataSource = ds.Tables[0];
        Repeater7.DataBind();
        cn.Close();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id = valores[0].ToString();
        num_atendimento = valores[1].ToString();
        buscarLeito();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowDo()", true);
    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id = valores[0].ToString();
        num_atendimento = valores[1].ToString();
        buscarLeito();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowDo()", true);
    }

    protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id = valores[0].ToString();
        num_atendimento = valores[1].ToString();
        buscarLeito();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowDo()", true);
    }

    protected void Repeater4_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id = valores[0].ToString();
        num_atendimento = valores[1].ToString();
        buscarLeito();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowDo()", true);
    }

    protected void Repeater5_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id = valores[0].ToString();
        num_atendimento = valores[1].ToString();
        buscarLeito();
        //Button1.Visible = false;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowDo()", true);
    }

    protected void Repeater6_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id = valores[0].ToString();
        num_atendimento = valores[1].ToString();
        buscarLeito();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowDo()", true);
    }

    public void buscarLeito()
    {
        OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["tasy"].ConnectionString);
        OracleCommand cmd = new OracleCommand("SELECT obter_dados_reserva(cd_pessoa_fisica) reserva FROM paciente_internado_atual_v WHERE nr_atendimento= '"+num_atendimento+"'", cn);

        try
        {
            cn.Open();

            OracleDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string leito = dr["reserva"].ToString();
                Response.Write(leito);

                if(leito == "")
                {
                    Label1.Text = "Reserva não solicitado";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error(); setTimeout(fechar, 3000);", true);
                }
                else if (leito.Contains("SUITE"))
                {
                    unidade = leito.Substring(0, 14).Trim();
                    complemento = leito.Substring(14, 12).Trim();
                    setor = leito.Substring(25, 5).Trim();
                }
                else
                {
                    unidade = leito.Substring(0, 13).Trim();
                    complemento = leito.Substring(13, 12).Trim();
                    setor = leito.Substring(24, 4).Trim();
                }

                TextBox1.Text = unidade;
                TextBox2.Text = complemento;
                TextBox3.Text = setor;
            }
            else
            {
                
            }
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("update tbpedido set leito=@leito, usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where id=@id and data_pedido=@data_pedido", cn);
        cmd.Parameters.AddWithValue("@leito", TextBox1.Text + " - " + TextBox2.Text + " - " + TextBox3.Text);
        cmd.Parameters.AddWithValue("@usuario_libera", cookie_id.Value.ToString());
        cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Label1.Text = "Leito confirmado";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
            Response.AddHeader("Refresh", "3;URL=" + Request.RawUrl);
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
        SqlCommand cmd = new SqlCommand("select * from tbpedido where id=@id and num_atendimento=@num_atendimento", cn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@num_atendimento", num_atendimento);

        cn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            cmd = new SqlCommand("update tbpedido set leito='Alta Cancelada', usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where id=@id", cn);
            cmd.Parameters.AddWithValue("@usuario_libera", cookie_id.Value.ToString());
            cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                cmd.ExecuteNonQuery();
                Label1.Text = "Leito cancelado com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
                Response.AddHeader("Refresh", "3;URL=" + Request.RawUrl);
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
        else
        {
            cmd = new SqlCommand("update tbtransfere set leito='Alta Cancelada', usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where id=@id", cn);
            cmd.Parameters.AddWithValue("@usuario_libera", cookie_id.Value.ToString());
            cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                cmd.ExecuteNonQuery();
                Label1.Text = "Leito cancelado com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
                Response.AddHeader("Refresh", "3;URL=" + Request.RawUrl);
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("update tbtransfere set leito=@leito, usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where id=@id and data_pedido=@data_pedido", cn);
        cmd.Parameters.AddWithValue("@leito", TextBox1.Text + " - " + TextBox2.Text + " - " + TextBox3.Text);
        cmd.Parameters.AddWithValue("@usuario_libera", cookie_id.Value.ToString());
        cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Label1.Text = "Leito confirmado";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
            Response.AddHeader("Refresh", "3;URL=" + Request.RawUrl);
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