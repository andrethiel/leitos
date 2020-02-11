using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class cdi_centro : System.Web.UI.Page
{
    int valor;

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
                    Response.Redirect("../Default.aspx");
                }
                else
                {
                    if (Request.QueryString["atende"] == null)
                    {
                        preenche();
                        drop();
                        TextBox1.Attributes.Add("required", "");
                        TextBox3.Attributes.Add("required", "");
                        Button2.Visible = false;
                        Button3.Visible = false;
                    }
                    else
                    {
                        editar();
                    }
                }
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("principalcdi.aspx?session=" + Label1.Text);
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
                Label2.Text = dr["id"].ToString();
            }
            cn.Close();
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
    public void drop()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tb_especial_cdi where not id='1' and not id='2' and not id='3' and not id='4' and not id='5' and not id='6' and not id='8'", cn);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr["exame"].ToString());
            }
            cn.Close();
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
        if (TextBox4.Text == "50")
        {
            Label11.Text = "Agenda cheia. Escolha outra data";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Popup();", true);
        }
        else
        {
            if (DropDownList1.Text == "Escolha uma especialidade")
            {
                Label11.Text = "Selecione um exame para o paciente";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Popup();", true);
            }
            else
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                SqlCommand cmd = new SqlCommand("insert into tbexames_centro (nome_pac, tel, data_marcado, especial,obs, usuario_pedido, data_pedido, hora_pedido) values (@nome_pac, @tel, @data_marcado, @especial, @obs, @usuario_pedido, @data_pedido, @hora_pedido)", cn);
                cmd.Parameters.AddWithValue("@nome_pac", TextBox1.Text);
                cmd.Parameters.AddWithValue("@tel", TextBox2.Text);
                cmd.Parameters.AddWithValue("@data_marcado", TextBox3.Text);
                cmd.Parameters.AddWithValue("@especial", DropDownList1.Text);
                cmd.Parameters.AddWithValue("@obs", TextBox5.Text);
                cmd.Parameters.AddWithValue("@usuario_pedido", Label2.Text);
                cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@hora_pedido", DateTime.Now.ToShortTimeString());

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Label11.Text = "Paciente inserido com sucesso";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Popup();", true);
                    limpar(this);
                    cn.Close();
                    contador();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("agendados_centro.aspx?session=" + Label1.Text);
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
                ((DropDownList)cla).Text = "Escolha uma especialidade";
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
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        if (TextBox3.Text == "")
        {

        }
        else
        {
            string texto = TextBox3.Text;
            DateTime data = Convert.ToDateTime(texto);
            Label9.Text = data.DayOfWeek.ToString();
            if (Label9.Text == "Friday")
            {
                Label10.Text = "Agenda de sexta-feira.<br> Os exames são marcados no horario das: 11:30 - 15:30.<br> Deseja marcar mesmo o exame ?";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
            }
            else
            {
                contador();
            }
        }
    }
    public void contador()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select count('data_marcado') as num from tbexames_centro where data_marcado = @data_marcado", cn);
        cmd.Parameters.AddWithValue("@data_marcado", TextBox3.Text);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox4.Text = dr["num"].ToString();

                cn.Close();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void editar()
    {
        Button1.Visible = false;
        drop();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames_centro.*, tblogin.nome_completo from tbexames_centro inner join tblogin on tbexames_centro.usuario_pedido = tblogin.Id where tbexames_centro.id=@id", cn);
        cmd.Parameters.AddWithValue("@id", Request.QueryString["atende"].ToString());

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = dr["nome_pac"].ToString();
                TextBox2.Text = dr["tel"].ToString();
                string data = dr["data_marcado"].ToString();
                string datanova = Convert.ToDateTime(data).ToString("dd/MM/yyyy");
                TextBox3.Text = datanova;
                string especial = dr["especial"].ToString();
                DropDownList1.Text = especial;
                TextBox5.Text = dr["obs"].ToString();
                cn.Close();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == "50")
        {
            Label11.Text = "Agenda cheia. Escolha outra data";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Popup();", true);
        }
        else
        {
            if (DropDownList1.Text == "Escolha uma especialidade")
            {
                Label11.Text = "Selecione um exame para o paciente";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Popup();", true);
            }
            else
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                SqlCommand cmd = new SqlCommand("update tbexames_centro set tel=@tel, data_marcado=@data_marcado, especial=@especial,obs=@obs where id=@id", cn);
                cmd.Parameters.AddWithValue("@tel", TextBox2.Text);
                cmd.Parameters.AddWithValue("@data_marcado", TextBox3.Text);
                cmd.Parameters.AddWithValue("@especial", DropDownList1.Text);
                cmd.Parameters.AddWithValue("@obs", TextBox5.Text);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["atende"].ToString());

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Label11.Text = "Editado com sucesso";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Popup();", true);
                    limpar(this);
                    cn.Close();
                    contador();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            Label11.Text = "O nome do paciente não pode estar em branco para excluir um paciente";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Popup();", true);
        }
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("delete from tbexames_centro where id=@id", cn);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["atende"].ToString());

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Label11.Text = "Excluido com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Popup();", true);
                limpar(this);
                cn.Close();
                contador();
                Button1.Visible = true;
                Button2.Visible = false;
                Button3.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        contador();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        TextBox4.Text = "";
    }
}