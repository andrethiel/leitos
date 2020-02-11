using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Principal_Pedidouti_examecdi : System.Web.UI.Page
{
    public string id, valor, setor, sui;
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
                    Response.Redirect("../../Default.aspx");
                }
                else
                {
                    var horariofixo = TimeSpan.Parse("17:00");
                    var horario = TimeSpan.Parse(DateTime.Now.ToShortTimeString());

                    if (horario >= horariofixo)
                    {
                        Label7.Text = "A marcação de exames no sistema só pode ser feita até as 17H<br>Apos esse horario, ligar diretamente ao setor do centro de imagem";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "hora();", true);
                    }
                    else
                    {
                        TextBox3.Attributes.Add("required", "");
                        DropDownList4.Attributes.Add("required", "");
                        TextBox5.Attributes.Add("required", "");
                        DropDownList6.Attributes.Add("required", "");
                        preenche();
                        exame();
                    }
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var horariofixo = TimeSpan.Parse("17:00");
        var horario = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
        if (DropDownList5.Visible == false)
        {
            insert();
        }
        else if (TextBox1.Text.Trim() != "Suite 100" || TextBox1.Text.Trim() != "Suite 126" || TextBox1.Text.Trim() != "Suite 113")
        {
            insert();
        }
        else
        {
            insert();
        }
    }
    public void preenche()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tblogin.*, tblocal.local_setor, tblog.session from tblogin inner join tblocal on tblogin.localt = tblocal.id_local inner join tblog on tblogin.Id = tblog.usuario where tblog.session=@session", cn);
        cmd.Parameters.AddWithValue("@session", Label1.Text);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TextBox1.Text = dr["local_setor"].ToString();
                setor = dr["local_setor"].ToString();
                Label13.Text = dr["id"].ToString();

                if(setor.Contains("Suite"))
                {
                    Label17.Visible = false;
                    DropDownList6.Visible = false;
                }
            }
            dr.Close();
            dr = null;

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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("pedidos.aspx?session=" + Label1.Text);
    }
    public void exame()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select exame from tb_especial_cdi where not id='9' and not id='10' and not id='11' and not id='12' and not id='13'", cn);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList4.Items.Add(dr["exame"].ToString());
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

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tb_especial_cdi where exame=@exame", cn);
        cmd.Parameters.AddWithValue("@exame", DropDownList4.Text);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                id = dr["id"].ToString();
                if (id == "8")
                {
                    Label15.Visible = false;
                    DropDownList5.Visible = false;
                }
                else
                {
                    DropDownList5.Attributes.Add("required", "");
                    Label15.Visible = true;
                    DropDownList5.Visible = true;

                    cmd = new SqlCommand("select * from tb_procede_cdi where id_exame=@id_exame", cn);
                    cmd.Parameters.AddWithValue("@id_exame", id);

                    try
                    {
                        dr.Close();
                        dr = null;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            DropDownList5.Items.Add(dr["procede"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        DropDownList4.Text = "Escolha uma especialidade";
        DropDownList5.Text = "Selecione um procedimento";
    }
    public void insert()
    {
        if(TextBox1.Text.Trim() == "Suite 100")
        {
            sui = TextBox5.Text;
        }
        else
        {
            sui = TextBox5.Text + "-" + DropDownList6.Text;
        }
        if (TextBox6.Text == "")
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into tbexames(nome_pac, local, quarto, usuario_pedido, data_pedido, hora_pedido, especial, procede, baixa) values (@nome_pac, @local, @quarto, @usuario_pedido, @data_pedido, @hora_pedido, @especial, @procede, @baixa)", cn);
            cmd.Parameters.AddWithValue("@nome_pac", TextBox3.Text);
            cmd.Parameters.AddWithValue("@local", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@quarto", sui);
            cmd.Parameters.AddWithValue("@usuario_pedido", Label13.Text);
            cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@hora_pedido", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@especial", DropDownList4.Text);
            cmd.Parameters.AddWithValue("@procede", DropDownList5.Text);
            cmd.Parameters.AddWithValue("@baixa", "Aguardando agendamento");

            try
            {

                cn.Open();
                cmd.ExecuteNonQuery();
                Label5.Text = "Exame cadastrado com sucesso!<br>Deseja cadastrar outro exame para esse paciente ?";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Popup();", true);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into tbexames(nome_pac, local, quarto, usuario_pedido, data_pedido, hora_pedido, obs, especial, procede, baixa) values (@nome_pac, @local, @quarto, @usuario_pedido, @data_pedido, @hora_pedido, @obs, @especial, @procede, @baixa)", cn);
            cmd.Parameters.AddWithValue("@nome_pac", TextBox3.Text);
            cmd.Parameters.AddWithValue("@local", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@quarto", sui);
            cmd.Parameters.AddWithValue("@usuario_pedido", Label13.Text);
            cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@hora_pedido", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@obs", TextBox6.Text);
            cmd.Parameters.AddWithValue("@especial", DropDownList4.Text);
            cmd.Parameters.AddWithValue("@procede", DropDownList5.Text);
            cmd.Parameters.AddWithValue("@baixa", "Aguardando agendamento");

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Label5.Text = "Exame cadastrado com sucesso!<br>Deseja cadastrar outro exame para esse paciente ?";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Popup();", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("pedidos.aspx?session=" + Label1.Text);
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("leito.aspx?session=" + Label1.Text);
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if(CheckBox1.Checked)
        {
            Label7.Text = "Em caso de emergencia, ligar diretamente ao setor do centro de imagem.<br>Seu exame não será agendado";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "hora();", true);
        }
    }


    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("pedidos.aspx?session=" + Label1.Text);
    }
}