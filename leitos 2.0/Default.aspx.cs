using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    public static string senha, textodecriptografado, id, email, tipo, local, nome_completo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
        }
        else
        {
            TextBox1.Attributes.Add("placeholder", "Email");
            TextBox1.Attributes.Add("required", "");
            TextBox2.Attributes.Add("placeholder", "Senha");
            TextBox2.Attributes.Add("required", "");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tblogin.*, tblocal.local_setor from tblogin inner join tblocal on tblocal.id_local = tblogin.localt where email=@email", cn);
        cmd.Parameters.AddWithValue("@email", TextBox1.Text);

        cn.Open();
        SqlDataReader dr = null;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            email = dr["email"].ToString();
            senha = dr["senha"].ToString().Trim();
            id = dr["id"].ToString();
            local = dr["local_setor"].ToString();
            tipo = dr["tipo"].ToString();
            nome_completo = dr["nome_completo"].ToString();
            crypt();


            if (textodecriptografado == TextBox2.Text)
            {
                HttpCookie cookie = new HttpCookie("id");
                cookie.Value = id;
                Response.Cookies.Add(cookie);
                cookie = new HttpCookie("local");
                cookie.Value = local;
                Response.Cookies.Add(cookie);
                cookie = new HttpCookie("nome_completo");
                cookie.Value = nome_completo;
                Response.Cookies.Add(cookie);
                Label1.Text = "Seja Bem vindo " + dr["nome_completo"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "sucesso();", true);
                if (tipo == "2")
                {
                    if (local.Contains("UTI"))
                    {
                        Response.AddHeader("Refresh", "1;URL=UTI/Principal.aspx");
                    }
                    else
                    {
                        Response.AddHeader("Refresh", "1;URL=Postos/Principal.aspx");
                    }
                }
                else
                {
                    if (local.Contains("Centro de Imagem"))
                    {
                        Response.AddHeader("Refresh", "2;URL=CDI/Principal.aspx");
                    }
                    else if (local.Contains("Assistente Social"))
                    {
                        Response.AddHeader("Refresh", "2;URL=Leitos/Altas.aspx");
                    }
                    else
                    {
                        Response.AddHeader("Refresh", "2;URL=Leitos/Principal.aspx");
                    }
                }
            }
            else
            {
                Response.Write(textodecriptografado);
                Label1.Text = "Usuario/Senha incorreto";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
            }
        }

    }
    public void crypt()
    {
        string chave = "Chave secreta";
        Crypt crypt = new Crypt(CryptProvider.DES);
        crypt.Key = chave;
        textodecriptografado = crypt.Decrypt(senha);
    }
}