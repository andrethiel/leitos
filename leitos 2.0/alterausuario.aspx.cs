using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class alterausuario : System.Web.UI.Page
{
    public static HttpCookie cookie, cookie_local;
    public static string editanome, editaemail, setor, nome, email;

    protected void Page_Load(object sender, EventArgs e)
    {
        cookie = Request.Cookies["id"];
        
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tblogin.*, tblocal.local_setor from tblogin inner join tblocal on tblogin.localt = tblocal.id_local where id=@id", cn);
        cmd.Parameters.AddWithValue("@id", cookie.Value.ToString());

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                nome = dr["nome_completo"].ToString();
                email = dr["email"].ToString();
                TextBox1.Text = nome;
                TextBox2.Text = email;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Close();
            cn.Dispose();
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (TextBox1.Enabled == false)
        {
            ImageButton1.ImageUrl = "~/images/salvar.ico";
            TextBox1.Enabled = true;
            editanome = "1";
        }
        else
        {
            ImageButton1.ImageUrl = "~/images/editar.ico";
            TextBox1.Enabled = false;
            editanome = "0";
        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (TextBox2.Enabled == false)
        {
            ImageButton2.ImageUrl = "~/images/salvar.ico";
            TextBox2.Enabled = true;
            editaemail = "1";
        }
        else
        {
            ImageButton2.ImageUrl = "~/images/editar.ico";
            TextBox2.Enabled = false;
            editaemail = "0";
        }
    }
    public void verifica()
    {
        if (TextBox1.Text != nome)
        {
            nome = TextBox1.Text;
        }
        if (TextBox2.Text != email)
        {
            email = TextBox2.Text;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Enabled == true)
        {
            Label1.Text = "Atenção: Você não terminou a edição do seu nome. Termine a edição antes de alterar seus dados";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
        }
        else if (TextBox2.Enabled == true)
        {
            Label1.Text = "Atenção: Você não terminou a edição do seu email. Termine a edição antes de alterar seus dados";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
        }
        else
        {
            verifica();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tblogin set nome_completo=@nome_completo, email=@email where id=@id", cn);
            cmd.Parameters.AddWithValue("@nome_completo", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@id", cookie.Value.ToString());

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();

                Label1.Text = "Dados alterados com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "sucesso();", true);
                cn.Close();
                Response.AddHeader("Refresh", "2;URL=Default.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("alterasenha.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("alterasetor.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        cookie_local = Request.Cookies["local"];
        string cookies = cookie_local.Value.ToString();

        if(cookies.Contains("UTI"))
        {
            Response.Redirect("uti/principal.aspx");
        }
        else if (cookies.Contains("Centro de Imagem"))
        {
            Response.AddHeader("Refresh", "2;URL=CDI/Principal.aspx");
        }
        else if(cookies.Contains("Posto"))
        {
            Response.AddHeader("Refresh", "1;URL=Postos/Principal.aspx");
        }
        else
        {
            Response.AddHeader("Refresh", "2;URL=Leitos/Principal.aspx");
        }
    }
}