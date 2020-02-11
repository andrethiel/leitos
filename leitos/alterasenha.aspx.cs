using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class alterasenha : System.Web.UI.Page
{
    string textodecriptografado, senha, senhanova, textoCriptografado, setor;

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
                            senha = dr["senha"].ToString().Trim();
                            decrypt();
                            Label1.Text = textodecriptografado;

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
    public void decrypt()
    {
        string chave = "Chave secreta";
        Crypt crypt = new Crypt(CryptProvider.DES);
        crypt.Key = chave;
        textodecriptografado = crypt.Decrypt(senha);
    }
    public void crypt()
    {
        senhanova = TextBox2.Text;
        string chave = "Chave secreta";
        Crypt crypt = new Crypt(CryptProvider.DES);
        crypt.Key = chave;
        textoCriptografado = crypt.Encrypt(senhanova);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "")
        {
            Label4.Text = "Atenção: Os campos de senha não pode estar em branco";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
        }
        if (TextBox1.Text != Label1.Text)
        {
            Label4.Text = "Atenção: A senha não confere com a anterior";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
        }
        else if(TextBox2.Text == Label1.Text)
        {
            Label4.Text = "Atenção: A senha não pode ser a mesma que a anterior";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
        }
        else if(TextBox3.Text != TextBox2.Text)
        {
            Label4.Text = "Atenção: A senha não são iguais";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
        }
        else
        {
            crypt();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tblogin set senha=@senha where id=@id", cn);
            cmd.Parameters.AddWithValue("@senha", textoCriptografado);
            cmd.Parameters.AddWithValue("@id", Label2.Text);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Label4.Text = "Senha alterada com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "sucesso();", true);
                cn.Close();
                Response.AddHeader("Refresh", "1;URL=Default.aspx");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        setor = Session.Contents["setor"].ToString();
        if (setor == "Posto")
        {
            Response.Redirect("principal/transfere/pedidos.aspx?session=" + Request.QueryString["session"].ToString());
        }
        if (setor == "UTI")
        {
            Response.Redirect("principal/pedidouti/pedidos.aspx?session=" + Request.QueryString["session"].ToString());
        }
        if (setor == "ADM")
        {
            Response.Redirect("principal/principal.aspx?session=" + Request.QueryString["session"].ToString());
        }
        if (setor == "CDI")
        {
            Response.Redirect("cdi/principalCDI.aspx?session=" + Request.QueryString["session"].ToString());
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("alterasetor.aspx?session=" + Request.QueryString["session"].ToString());
    }
}