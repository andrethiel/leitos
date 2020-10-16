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

public partial class CDI_Principal : System.Web.UI.Page
{
    public static string id_exec, nome_pac;
    public static HttpCookie cookie;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.IsPostBack)
        {
            
        }
        else
        {
            cookie = Request.Cookies.Get("local");
            if (cookie == null)
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                resso();
                tomo();
                raio();
                eco();
                angioresso();
                angiotomo();
                mamo();
                contador();
                
            }
        }
    }
    public void contador()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select COUNT(*) as tipo,(select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Ressonância') as resso, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Angioressonâncias') as angior, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Tomografia') as tomo, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Angiotomografias') as angiot, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Raio-X') as raio, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Mamografia') as mamo, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Ecografia') as eco", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));

        cn.Open();
        SqlDataReader dr = null;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Label2.Text = dr["resso"].ToString();
            Label4.Text = dr["tomo"].ToString();
            Label7.Text = dr["raio"].ToString();
            Label8.Text = dr["eco"].ToString();
            Label9.Text = dr["mamo"].ToString();
            if (dr["angior"].ToString() == "0")
            {
                Label6.Text = dr["angiot"].ToString();
            }
            else
            {
                Label6.Text = dr["angior"].ToString();
            }
        }
    }

    public void resso()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido='" + DateTime.Now.ToString("dd/MM/yyyy") + "' and especial='Ressonância' order by baixa, hora_pedido desc", cn);
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
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
    public void tomo()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido='" + DateTime.Now.ToString("dd/MM/yyyy") + "' and especial='Tomografia' order by baixa, hora_pedido desc", cn);
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
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
    public void raio()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido='" + DateTime.Now.ToString("dd/MM/yyyy") + "' and especial='Raio-X' order by baixa, hora_pedido desc", cn);
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
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
    public void eco()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido='" + DateTime.Now.ToString("dd/MM/yyyy") + "' and especial='Ecografia' order by baixa, hora_pedido desc", cn);
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater4.DataSource = ds.Tables[0];
            Repeater4.DataBind();
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
    public void angioresso()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido='" + DateTime.Now.ToString("dd/MM/yyyy") + "' and especial='Angioressonâncias' order by baixa, hora_pedido desc", cn);
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater6.DataSource = ds.Tables[0];
            Repeater6.DataBind();
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
    public void angiotomo()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido='" + DateTime.Now.ToString("dd/MM/yyyy") + "' and especial='Angiotomografias' order by baixa, hora_pedido desc", cn);
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater5.DataSource = ds.Tables[0];
            Repeater5.DataBind();
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
    public void mamo()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido='" + DateTime.Now.ToString("dd/MM/yyyy") + "' and especial='Mamografia' order by baixa, hora_pedido desc", cn);
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater7.DataSource = ds.Tables[0];
            Repeater7.DataBind();
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
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id_exec = valores[0].ToString();
        TextBox2.Text = valores[1].ToString();
        nome_pac = valores[1].ToString();
        TextBox1.Text = valores[2].ToString();
        TextBox3.Text = valores[3].ToString();


        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "$('#div_resso').collapse('show');ShowPopup();", true);
        

    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id_exec = valores[0].ToString();
        TextBox2.Text = valores[1].ToString();
        nome_pac = valores[1].ToString();
        TextBox1.Text = valores[2].ToString();
        TextBox3.Text = valores[3].ToString();


        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "$('#div_tomo').collapse('show');ShowPopup();", true);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        cookie = Request.Cookies.Get("nome_completo");

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbexames where id=@id and baixa='Exame agendado'", cn);
        cmd.Parameters.AddWithValue("@id", id_exec);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            Label1.Text = "Exame ja agendado";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
        }
        else
        {
            cmd = new SqlCommand("select * from tbexames where id=@id and baixa='Exame agendado' and status='Exame Cancelado'", cn);
            cmd.Parameters.AddWithValue("@id", id_exec);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            dr = null;
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                Label1.Text = "Exame cancelado";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
            }
            else
            {
                cmd = new SqlCommand("update tbexames set baixa= 'Exame agendado', usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where id=@id", cn);
                cmd.Parameters.AddWithValue("@usuario_libera", cookie.Value);
                cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
                cmd.Parameters.AddWithValue("@id", id_exec);

                try
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    Label1.Text = "Exame baixado com sucesso de: " + nome_pac;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
                    resso();
                    tomo();
                    raio();
                    eco();
                    angioresso();
                    angiotomo();
                    mamo();
                    contador();
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

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        cookie = Request.Cookies.Get("nome_completo");

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbexames where id=@id and status='Exame Cancelado'", cn);
        cmd.Parameters.AddWithValue("@id", id_exec);

        cn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Label1.Text = "Exame Cancelado por: " + dr["usuario_cancela"].ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
        }
        else
        {
            cmd = new SqlCommand("select * from tbexames where id=@id and baixa='Exame agendado'", cn);
            cmd.Parameters.AddWithValue("@id", id_exec);

            dr = null;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                cmd = new SqlCommand("update tbexames set status= 'Exame Cancelado', usuario_cancela=@usuario_cancela, data_cancela=@data_cancela, hora_cancela=@hora_cancela where id=@id", cn);
                cmd.Parameters.AddWithValue("@usuario_cancela", cookie.Value);
                cmd.Parameters.AddWithValue("@data_cancela", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@hora_cancela", DateTime.Now.ToShortTimeString());

                cmd.Parameters.AddWithValue("@id", id_exec);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Label1.Text = "Exame cancelado com sucesso de: " + nome_pac;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
                    resso();
                    tomo();
                    raio();
                    eco();
                    angioresso();
                    angiotomo();
                    mamo();
                    contador();
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
                Label1.Text = "Exame não agendado";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
            }
        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where nome_pac like'"+TextBox4.Text+"%' and data_pedido='" + DateTime.Now.ToString("dd/MM/yyyy") + "' and especial='"+ DropDownList1.Text+ "' order by baixa, hora_pedido desc", cn);
        try
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater8.DataSource = ds.Tables[0];
            Repeater8.DataBind();
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

    protected void Button4_Click(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        DropDownList1.SelectedValue = "";
        Repeater8.DataSource = null;
        Repeater8.DataSourceID = null;
        Repeater8.DataBind();
    }

    protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id_exec = valores[0].ToString();
        TextBox2.Text = valores[1].ToString();
        nome_pac = valores[1].ToString();
        TextBox1.Text = valores[2].ToString();
        TextBox3.Text = valores[3].ToString();


        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "$('#div_raio').collapse('show');ShowPopup();", true);
    }

    protected void Repeater4_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id_exec = valores[0].ToString();
        TextBox2.Text = valores[1].ToString();
        nome_pac = valores[1].ToString();
        TextBox1.Text = valores[2].ToString();
        TextBox3.Text = valores[3].ToString();


        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "$('#div_eco').collapse('show');ShowPopup();", true);
    }

    protected void Repeater7_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id_exec = valores[0].ToString();
        TextBox2.Text = valores[1].ToString();
        nome_pac = valores[1].ToString();
        TextBox1.Text = valores[2].ToString();
        TextBox3.Text = valores[3].ToString();


        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "$('#div_mamo').collapse('show');ShowPopup();", true);
    }

    protected void Repeater6_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id_exec = valores[0].ToString();
        TextBox2.Text = valores[1].ToString();
        nome_pac = valores[1].ToString();
        TextBox1.Text = valores[2].ToString();
        TextBox3.Text = valores[3].ToString();


        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "$('#div_angioresso').collapse('show');ShowPopup();", true);
    }

    protected void Repeater5_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        id_exec = valores[0].ToString();
        TextBox2.Text = valores[1].ToString();
        nome_pac = valores[1].ToString();
        TextBox1.Text = valores[2].ToString();
        TextBox3.Text = valores[3].ToString();


        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "$('#div_angiotomo').collapse('show');ShowPopup();", true);
    }
}
