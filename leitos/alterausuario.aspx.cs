using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class alterausuariop : System.Web.UI.Page
{
    string nome, email;
    string editanome, editaemail, setor;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Popup();", true);
            if (Request.Cookies == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Text = Request.QueryString["session"];
                if (Request.QueryString["session"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("select tblogin.*, tblocal.local_setor, tblog.session from tblogin inner join tblocal on tblogin.localt = tblocal.id_local inner join tblog on tblogin.Id = tblog.usuario where tblog.session=@session", cn);
                    cmd.Parameters.AddWithValue("@session", Request.QueryString["session"].ToString());

                    try
                    {
                        cn.Open();
                        SqlDataReader dr = null;
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Label2.Text = dr["id"].ToString();
                            TextBox1.Text = dr["nome_completo"].ToString();
                            nome = dr["nome_completo"].ToString();
                            TextBox2.Text = dr["email"].ToString();
                            email = dr["email"].ToString();
                            
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
            }
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Enabled == true)
        {
            Label3.Text = "Atenção: Você não terminou a edição do seu nome. Termine a edição antes de alterar seus dados";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
        }
        else if (TextBox2.Enabled == true)
        {
            Label3.Text = "Atenção: Você não terminou a edição do seu email. Termine a edição antes de alterar seus dados";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
        }
        else
        {
            verifica();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tblogin set nome_completo=@nome_completo, email=@email where id=@id", cn);
            cmd.Parameters.AddWithValue("@nome_completo", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@id", Label2.Text);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();

                Label3.Text = "Dados alterados com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "sucesso();", true);
                cn.Close();
                Response.AddHeader("Refresh", "2;URL=Default.aspx");
            }
            catch(Exception ex)
            {
                throw ex;
            }
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("alterasenha.aspx?session=" + Request.QueryString["session"].ToString());
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("alterasetor.aspx?session=" + Request.QueryString["session"].ToString());
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        setor = Session.Contents["setor"].ToString();
        if (setor == "Posto")
        {
            Response.Redirect("principal/transfere/pedidos.aspx?session=" + Request.QueryString["session"].ToString());
        }
        if(setor == "UTI")
        {
            Response.Redirect("principal/pedidouti/pedidos.aspx?session=" + Request.QueryString["session"].ToString());
        }
        if(setor == "ADM")
        {
            Response.Redirect("principal/principal.aspx?session=" + Request.QueryString["session"].ToString());
        }
        if(setor == "CDI")
        {
            Response.Redirect("cdi/principalCDI.aspx?session=" + Request.QueryString["session"].ToString());
        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "OK();", true);
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Fechar();", true);
    }
}