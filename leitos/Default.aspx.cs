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
    string senha, textodecriptografado, id, email, tipo, local;
    SqlDataReader dr;
    SqlConnection cn;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
        }
        else
        {
            ViewState.Remove("log");
            TextBox1.Attributes.Add("placeholder", "Email");
            TextBox1.Attributes.Add("required", "");
            TextBox2.Attributes.Add("placeholder", "Senha");
            TextBox2.Attributes.Add("required", "");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tblogin.*, tblocal.local_setor from tblogin inner join tblocal on tblocal.id_local = tblogin.localt where email=@email", cn);
        cmd.Parameters.AddWithValue("@email", TextBox1.Text);

        cn.Open();
        dr = null;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            email = dr["email"].ToString();
            senha = dr["senha"].ToString().Trim();
            id = dr["id"].ToString();
            local = dr["local_setor"].ToString();
            tipo = dr["tipo"].ToString();
            crypt();


            if (textodecriptografado == TextBox2.Text)
            {
                Random random = new Random();
                int idsession = random.Next();

                cmd = new SqlCommand("insert into tblog (usuario, session, data, hora) values (@usuario, @session, @data, @hora)", cn);
                cmd.Parameters.AddWithValue("@usuario", id);
                cmd.Parameters.AddWithValue("@session", idsession);
                cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@hora", DateTime.Now.ToShortTimeString());

                try
                {
                    Label1.Text = "Seja Bem vindo " + dr["nome_completo"].ToString();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "sucesso();", true);

                    cmd.ExecuteNonQuery();
                    HttpCookie cookie = new HttpCookie("log");
                    cookie.Value = "S";
                    Response.Cookies.Add(cookie);
                    if (tipo == "2")
                    {
                        if (local.Contains("UTI"))
                        {
                            Response.AddHeader("Refresh", "2;URL=principal/pedidouti/pedidos.aspx?session=" + idsession);
                        }
                        else
                        {
                            Response.AddHeader("Refresh", "2;URL=principal/transfere/pedidos.aspx?session=" + idsession);
                        }
                    }
                    else
                    {
                        if (local.Contains("Centro de Imagem"))
                        {
                            Response.AddHeader("Refresh", "2;URL=cdi/principalCDI.aspx?session=" + idsession);
                        }
                        else
                        {
                            Response.AddHeader("Refresh", "2;URL=principal/principal.aspx?session=" + idsession);
                        }
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
            else
            {
                Label1.Text = "Usuario/Senha incorreto!";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
            }
        }
        else
        {
            Label1.Text = "Usuario/Senha incorreto!";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
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