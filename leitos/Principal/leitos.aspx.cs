using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Principal_leito : System.Web.UI.Page
{
    string id, sui;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {

        }
        else
        {
            Label1.Text = Request.QueryString["session"];
            //id = Request.QueryString["tipo"].ToString();
            if(Request.QueryString["session"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                Label13.Text = Request.QueryString["tipo"].ToString();
                preenche();
                if (Label13.Text == "2")
                {
                    posto();
                    TextBox8.Attributes.Add("placeholder", "Esse campo não e utilizado para transferencia de paciente");
                    TextBox9.Attributes.Add("placeholder", "Esse campo não e utilizado para transferencia de paciente");
                    TextBox10.Attributes.Add("placeholder", "Esse campo não e utilizado para transferencia de paciente");
                }
                else
                {
                    UTI();
                    Label6.Text = "BOX";
                    Label7.Text = "Obs. do paciente";
                }
            }
            
        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("principal.aspx?session=" + Label1.Text);
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
                ((DropDownList)cla).Text = string.Empty;
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
                Label8.Text = dr["id"].ToString();
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
    public void posto()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbtransfere where num_atendimento = @num_atendimento", cn);
        cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TextBox1.Text = dr["local"].ToString();
                TextBox2.Text = dr["num_atendimento"].ToString();
                TextBox3.Text = dr["nome_pac"].ToString();
                TextBox11.Text = dr["sexo"].ToString();
                TextBox4.Text = dr["diagnostico"].ToString();
                TextBox5.Text = dr["quarto"].ToString();
                TextBox6.Text = dr["motivo"].ToString();
                if(TextBox1.Text.Trim() == "Centro Cirurgico")
                {
                    TextBox10.Text = dr["convenio"].ToString();
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList3.Text == "Selecione o tipo de leito" || DropDownList3.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Selecione o tipo de leito');</script>");
        }
        else if (TextBox7.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Digite o numero do quarto');</script>");
        }
        else if (DropDownList3.Text == "Sus" || DropDownList3.Text == "Suite 2 leitos")
        {
            if (DropDownList2.Text == "Escolha um Leito")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Selecione um leito para o paciente');</script>");
            }
            else
            {
                if(DropDownList3.Text == "Suite 2 leitos")
                {
                    sui = DropDownList3.Text + "-" + TextBox7.Text + "-" + DropDownList2.Text;
                }
                else
                {
                    sui = TextBox7.Text + "-" + DropDownList2.Text;
                }
                if (Label13.Text == "2")
                {
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("update tbtransfere set leito=@leito, usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where num_atendimento=@num_atendimento", cn);
                    cmd.Parameters.AddWithValue("@leito", sui);
                    cmd.Parameters.AddWithValue("@usuario_libera", Label8.Text);
                    cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        limpar(this);
                        cn.Close();
                        cn.Dispose();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("update tbpedido set leito=@leito, usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where num_atendimento=@num_atendimento", cn);
                    cmd.Parameters.AddWithValue("@leito", sui);
                    cmd.Parameters.AddWithValue("@usuario_libera", Label8.Text);
                    cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        limpar(this);
                        cn.Close();
                        cn.Dispose();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        else
        {
            if (Label13.Text == "2")
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                SqlCommand cmd = new SqlCommand("update tbtransfere set leito=@leito, usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where num_atendimento=@num_atendimento", cn);
                cmd.Parameters.AddWithValue("@leito", DropDownList3.Text + "-" + TextBox7.Text);
                cmd.Parameters.AddWithValue("@usuario_libera", Label8.Text);
                cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
                cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    limpar(this);
                    cn.Close();
                    cn.Dispose();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                SqlCommand cmd = new SqlCommand("update tbpedido set leito=@leito, usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where num_atendimento=@num_atendimento", cn);
                cmd.Parameters.AddWithValue("@leito", DropDownList3.Text + "-" + TextBox7.Text);
                cmd.Parameters.AddWithValue("@usuario_libera", Label8.Text);
                cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
                cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    limpar(this);
                    cn.Close();
                    cn.Dispose();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
    public void UTI()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbpedido where num_atendimento = @num_atendimento", cn);
        cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TextBox1.Text = dr["uti"].ToString();
                TextBox2.Text = dr["num_atendimento"].ToString();
                TextBox3.Text = dr["nome_pac"].ToString();
                TextBox11.Text = dr["sexo"].ToString();
                TextBox4.Text = dr["diagnostico"].ToString();
                TextBox5.Text = dr["box"].ToString();
                TextBox6.Text = dr["obs"].ToString();
                TextBox8.Text = dr["iso"].ToString();
                TextBox9.Text = dr["especial"].ToString();
                TextBox10.Text = dr["convenio"].ToString();

            }
            cn.Close();
            cn.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.Text == "Suite")
        {
            DropDownList2.Visible = false;
            Label12.Visible = false;
        }
        else
        {
            DropDownList2.Visible = true;
            Label12.Visible = true;
        }
    }
}