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
    string senha, textoCriptografado, tipo, id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {

        }
        else
        {
            
            TextBox1.Attributes.Add("placeholder", "Nome Completo");
            TextBox1.Attributes.Add("required", "");
            TextBox2.Attributes.Add("placeholder", "Email");
            TextBox2.Attributes.Add("required", "");
            TextBox3.Attributes.Add("placeholder", "Senha");
            TextBox3.Attributes.Add("required", "");
            TextBox4.Attributes.Add("placeholder", "Repita a senha");
            TextBox4.Attributes.Add("required", "");

            if (Request.QueryString["Session"] == null)
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
            while (dr.Read())
            {
                Label1.Text = dr["id_local"].ToString();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == TextBox3.Text)
        {
            if (DropDownList1.Text == "Selecione um Setor")
            {
                Label3.Text = "Selecione um setor de trabalho";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
            }
            else
            {
                if (Request.QueryString["Session"] == null)
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
        }
        else
        {
            Label3.Text = "Senhas não conferem";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
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
    public void limpar(Control controle)
    {
        foreach (Control ctle in controle.Controls)
        {
            if (ctle is TextBox)
            {
                ((TextBox)ctle).Text = string.Empty;
            }
            else if (ctle.Controls.Count > 0)
            {
                limpar(ctle);
            }
        }
        foreach (Control cla in controle.Controls)
        {
            if (cla is DropDownList)
            {
                ((DropDownList)cla).Text = "Selecione um Setor";
            }
            else if (cla.Controls.Count > 0)
            {
                limpar(cla);
            }
        }
        foreach (Control cla in controle.Controls)
        {
            if (cla is RadioButton)
            {
                ((RadioButton)cla).Checked = false;
            }
            else if (cla.Controls.Count > 0)
            {
                limpar(cla);
            }
        }
        foreach (Control cla in controle.Controls)
        {
            if (cla is CheckBox)
            {
                ((CheckBox)cla).Checked = false;
            }
            else if (cla.Controls.Count > 0)
            {
                limpar(cla);
            }
        }
    }
    public void cadastro()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("Select * from tblogin where nome_completo=@nome_completo and email=@email and localt=@localt", cn);
        cmd.Parameters.AddWithValue("@nome_completo", TextBox1.Text);
        cmd.Parameters.AddWithValue("@email", TextBox2.Text);
        cmd.Parameters.AddWithValue("@localt", Label1.Text);


        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string nome = dr["nome_completo"].ToString();
                string email = dr["email"].ToString();
                Label3.Text = "Nome/email já está cadastrado";
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
                cmd.Parameters.AddWithValue("@localt", Label1.Text);
                cmd.Parameters.AddWithValue("@tipo", tipo);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    limpar(this);
                    Button1.Enabled = false;

                    Label3.Text = "Cadastro concluido";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "sucesso();", true);

                    if (Request.QueryString["Session"] == null)
                    {
                        Response.AddHeader("Refresh", "1;URL=Default.aspx");
                    }
                    else if(Request.QueryString["cdi"] == "1")
                    {
                        Response.AddHeader("Refresh", "1;URL=cdi/principalcdi.aspx?session=" + id);
                    }
                    else
                    {
                        id = Request.QueryString["session"];
                        Response.AddHeader("Refresh", "1;URL=principal/principal.aspx?session=" + id);
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