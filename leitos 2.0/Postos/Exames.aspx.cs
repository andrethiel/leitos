using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UTI_Exames : System.Web.UI.Page
{
    public static HttpCookie cookie_local, cookie_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Page.IsPostBack)
        {
            cookie_local = Request.Cookies["local"];
            cookie_id = Request.Cookies["id"];
        }
        else
        {
            var horariofixo = TimeSpan.Parse("17:00");
            var horario = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            if (horario >= horariofixo)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "hora();", true);
            }
            else
            {
                TextBox1.Attributes.Add("placeholder", "N° Atendimento");
                TextBox1.Attributes.Add("required", "");
                TextBox2.Attributes.Add("placeholder", "Nome do paciente");
                TextBox3.Attributes.Add("placeholder", "Leito");
                DropDownList1.Attributes.Add("required", "");
                DropDownList2.Attributes.Add("required", "");
                exames();
            }
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["tasy"].ConnectionString);
        OracleCommand cmd = new OracleCommand("select * from paciente_internado_atual_v WHERE ds_setor_atendimento = '" + cookie_local.Value.ToString() + "' and nr_atendimento = '" + TextBox1.Text + "'", cn);

        try
        {
            cn.Open();

            OracleDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox2.Text = dr["nm_paciente"].ToString();
                if(cookie_local.Value.ToString().Contains("UTI"))
                {
                    TextBox3.Text = dr["cd_unidade_compl"].ToString();
                }
                else
                {
                    TextBox3.Text = dr["cd_unidade_basica"].ToString() + " " + dr["cd_unidade_compl"].ToString();
                }
                
            }
            else
            {
                Label1.Text = "Paciente não pertence ao seu setor";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
            }
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

    public void exames()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select exame from tb_especial_cdi where not id='9' and not id='10' and not id='11' and not id='12' and not id='13' order by exame", cn);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr["exame"].ToString());
            }
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

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tb_especial_cdi where exame=@exame", cn);
        cmd.Parameters.AddWithValue("@exame", DropDownList1.Text);

        try
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("Procedimento");
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string id = dr["id"].ToString();

                if (id == "8")
                {
                    DropDownList2.Visible = false;
                    DropDownList2.Attributes.Remove("required");
                }
                else
                {
                    DropDownList2.Visible = true;
                    cmd = new SqlCommand("select * from tb_procede_cdi where id_exame=@id_exame order by procede", cn);
                    cmd.Parameters.AddWithValue("@id_exame", id);

                    try
                    {
                        dr.Close();
                        dr = null;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            DropDownList2.Items.Add(dr["procede"].ToString());
                        }
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
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList2.Visible == false)
        {
            DropDownList2.Items.Clear();

        }
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("insert into tbexames(nome_pac, local, quarto, usuario_pedido, data_pedido, hora_pedido, especial, procede, baixa) values (@nome_pac, @local,@quarto, @usuario_pedido, @data_pedido, @hora_pedido, @especial, @procede, @baixa)", cn);
        cmd.Parameters.AddWithValue("@nome_pac", TextBox2.Text);
        cmd.Parameters.AddWithValue("@local", cookie_local.Value.ToString());
        cmd.Parameters.AddWithValue("@quarto", TextBox3.Text);
        cmd.Parameters.AddWithValue("@usuario_pedido", cookie_id.Value.ToString());
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_pedido", DateTime.Now.ToShortTimeString());
        cmd.Parameters.AddWithValue("@especial", DropDownList1.Text);
        cmd.Parameters.AddWithValue("@procede", DropDownList2.Text);
        cmd.Parameters.AddWithValue("@baixa", "Aguardando agendamento");


        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Label1.Text = "Exame cadastrado com sucesso!";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
            Response.AddHeader("Refresh", "1;URL=" + Request.RawUrl);
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