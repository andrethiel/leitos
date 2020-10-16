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
    public static HttpCookie cookie_local, cookie_id;

    public static string textodecriptografado, senha, senhanova, textoCriptografado, setor;

    protected void Page_Load(object sender, EventArgs e)
    {
            TextBox1.Attributes.Add("required", "");
            TextBox2.Attributes.Add("required", "");
            TextBox3.Attributes.Add("required", "");
            cookie_local = Request.Cookies["local"];
            cookie_id = Request.Cookies["id"];
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from tblogin where id=@id", cn);
            cmd.Parameters.AddWithValue("@id", cookie_id.Value.ToString());

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                senha = dr["senha"].ToString().Trim();
                decrypt();

                senha = textodecriptografado;
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
        if (senha == TextBox2.Text)
        {
            Label1.Text = "Atenção: A senha não pode ser igual a anterior";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error();", true);
        }
        else if (TextBox3.Text != TextBox2.Text)
        {
            Label1.Text = "Atenção: A senha não são iguais";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error();", true);
        }
        else
        {
            crypt();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tblogin set senha=@senha where id=@id", cn);
            cmd.Parameters.AddWithValue("@senha", textoCriptografado);
            cmd.Parameters.AddWithValue("@id", cookie_id.Value.ToString());

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Label1.Text = "Senha alterada com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso();", true);
                Response.AddHeader("Refresh", "1;URL=Default.aspx");
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

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("alterasetor.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("alterausuario.aspx");
    }
}