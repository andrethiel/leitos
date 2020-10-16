using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
    public static string id_alta, id_usuario;
    public static HttpCookie cookie_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        cookie_id = Request.Cookies.Get("id");
        if (Page.IsPostBack)
        {

        }
        else
        {
            
            if (cookie_id == null)
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("select tbaltas.*, tblogin.nome_completo from tbaltas inner join tblogin on tbaltas.usuario = tblogin.id where day(data_alta) = " + DateTime.Now.ToString("dd"), cn);

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
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("insert into tbligacao_alta (mensagem, usuario, id_alta, data, hora) values (@mensagem, @usuario, @id_alta, @data, @hora)", cn);
        cmd.Parameters.AddWithValue("@mensagem", TextBox1.Text);
        cmd.Parameters.AddWithValue("@usuario", cookie_id.Value.ToString());
        cmd.Parameters.AddWithValue("@id_alta", id_alta);
        cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora", DateTime.Now.ToShortTimeString());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("update tbaltas set obs='Entrado em contato', status='Entrado em contato' where id=@id", cn);
            cmd.Parameters.AddWithValue("@id", id_alta);

            try
            {
                cmd.ExecuteNonQuery();
                Label1.Text = "Informações inseridas com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
                Response.AddHeader("Refresh", "1;URL=" + Request.RawUrl);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
        catch(Exception ex)
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
        id_alta = e.CommandArgument.ToString();

        SqlDataAdapter da = new SqlDataAdapter("select tbligacao_alta.*, tblogin.nome_completo from tblogin inner join tbligacao_alta on tbligacao_alta.usuario = tblogin.Id where id_alta=" + id_alta, cn);

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
        TextBox1.Attributes.Add("placeholder", "Digite informaçãoes sobre a ligação");
        TextBox1.Attributes.Add("required", "");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowDo()", true);
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        //cookie = Request.Cookies["id"];
        //cookie.Expires = DateTime.Now.AddDays(-1d);
        //Response.Cookies.Add(cookie);
        //Response.Redirect("Default.aspx");
    }
}