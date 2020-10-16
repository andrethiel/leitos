using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class registrar : System.Web.UI.Page
{
    public static string local, senha, textoCriptografado, tipo, id;
    public static HttpCookie cookie;
    protected void Page_Load(object sender, EventArgs e)
    {
        cookie = Request.Cookies.Get("id");

        if (Page.IsPostBack)
        {

        }
        else
        {
            if (cookie == null)
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from tblocal where not local_setor = 'Recepção C' and not local_setor = 'Recepção A' and not local_setor = 'Recepção UTI' and not local_setor = 'Centro de Imagem' order by local_setor", cn);

                try
                {
                    cn.Open();
                    SqlDataReader dr = null;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DropDownList1.Items.Add(dr["local_setor"].ToString());
                    }
                    dr.Close();

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
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from tblocal order by local_setor", cn);

                try
                {
                    cn.Open();
                    SqlDataReader dr = null;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DropDownList1.Items.Add(dr["local_setor"].ToString());
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("Select * from tblocal where local_setor=@local_setor", cn);
        cmd.Parameters.AddWithValue("@local_setor", DropDownList1.Text);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                local = dr["id_local"].ToString();
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
    public void crypt()
    {
        senha = TextBox4.Text;
        string chave = "Chave secreta";
        Crypt crypt = new Crypt(CryptProvider.DES);
        crypt.Key = chave;
        textoCriptografado = crypt.Encrypt(senha);
    }
    public void cadastro()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("Select * from tblogin where nome_completo=@nome_completo and email=@email and localt=@localt", cn);
        cmd.Parameters.AddWithValue("@nome_completo", TextBox1.Text);
        cmd.Parameters.AddWithValue("@email", TextBox2.Text);
        cmd.Parameters.AddWithValue("@localt", local);


        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Label1.Text = "Nome/email já está cadastrado";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
            }
            else
            {
                crypt();
                cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                cmd = new SqlCommand("insert into tblogin (nome_completo, email, senha, localt, tipo) values (@nome_completo, @email, @senha, @localt, @tipo)", cn);
                cmd.Parameters.AddWithValue("@nome_completo", TextBox1.Text);
                cmd.Parameters.AddWithValue("@email", TextBox2.Text);
                cmd.Parameters.AddWithValue("@senha", textoCriptografado);
                cmd.Parameters.AddWithValue("@localt", local);
                cmd.Parameters.AddWithValue("@tipo", tipo);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Label1.Text = "Cadastro concluido";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "sucesso();", true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == TextBox3.Text)
        {
            if (cookie == null)
            {
                tipo = "2";
                cadastro();
            }
            else
            {
                tipo = "1";
                cadastro();
            }
        }
        else
        {
            Label1.Text = "Senhas não conferem";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
        }
    }
}