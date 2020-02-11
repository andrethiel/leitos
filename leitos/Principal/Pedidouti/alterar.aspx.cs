using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class alterar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id;
        if (Page.IsPostBack)
        {

        }
        else
        {
            Label1.Text = Request.QueryString["session"];
            //id = Request.QueryString["tipo"].ToString();
            if (Request.QueryString["session"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            else
            {
                Label13.Text = Request.QueryString["tipo"].ToString();
                preenche();
                UTI();
                TextBox3.Attributes.Add("required", "");
                TextBox4.Attributes.Add("required", "");
                TextBox5.Attributes.Add("required", "");
                TextBox6.Attributes.Add("required", "");
            }
        }
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
                ((DropDownList)cla).Text = "Escolha um sexo";
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
            if (dr.Read())
            {
                if(Label8.Text == dr["usuario_pedido"].ToString())
                {
                    TextBox1.Text = dr["uti"].ToString();
                    TextBox2.Text = dr["num_atendimento"].ToString();
                    TextBox3.Text = dr["nome_pac"].ToString();
                    string sex = dr["sexo"].ToString();
                    DropDownList1.Text = sex.Trim();
                    TextBox4.Text = dr["diagnostico"].ToString();
                    TextBox5.Text = dr["box"].ToString();
                    TextBox6.Text = dr["obs"].ToString();
                    TextBox8.Text = dr["leito"].ToString();
                    Label12.Text = dr["iso"].ToString();
                    string especial = dr["especial"].ToString();
                    DropDownList3.Text = especial.Trim();
                    string conv = dr["convenio"].ToString();
                    DropDownList2.Text = conv.Trim(); ;
                    if (Label12.Text != "")
                    {
                        CheckBox1.Checked = true;
                    }
                    cn.Close();
                    cn.Dispose();
                }
                else
                {
                    Label9.Text = "Atenção: Você não pode alterar esse paciente";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                    Response.AddHeader("Refresh", "2;URL=pedidos.aspx?session=" + Label1.Text);
                }
                
            }
            if (TextBox8.Text != "")
            {
                Label9.Text = "Atenção: Não é possivel alterar ou excluir alta após sem liberado o leito";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                Response.AddHeader("Refresh", "4;URL=pedidos.aspx?session=" + Label1.Text);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.Text == "Escolha um sexo")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Selecione um sexo');</script>");
        }
        if (DropDownList3.Text == "Escolha uma especialidade")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Selecione uma especialidade');</script>");
        }
        if (DropDownList2.Text == "Escolha um Convenio")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Selecione um Convenio');</script>");
        }
        if (CheckBox1.Checked)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tbpedido set nome_pac=@nome_pac, sexo=@sexo, diagnostico=@diagnostico, box=@box, iso=@iso, obs=@obs, especial=@especial, convenio=@convenio where num_atendimento = @num_atendimento", cn);
            cmd.Parameters.AddWithValue("@nome_pac", TextBox3.Text);
            cmd.Parameters.AddWithValue("@sexo", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@box", TextBox5.Text);
            cmd.Parameters.AddWithValue("@diagnostico", TextBox4.Text);
            cmd.Parameters.AddWithValue("@hora_pedido", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@obs", TextBox6.Text);
            cmd.Parameters.AddWithValue("@iso", Label12.Text);
            cmd.Parameters.AddWithValue("@especial", DropDownList3.Text);
            cmd.Parameters.AddWithValue("@convenio", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Label9.Text = "Dados do paciente alterado com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                cn.Close();
                Response.AddHeader("Refresh", "2;URL=pedidos.aspx?session=" + Label1.Text);
                limpar(this);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tbpedido set nome_pac=@nome_pac, sexo=@sexo, diagnostico=@diagnostico, box=@box, obs=@obs, especial=@especial, convenio=@convenio where num_atendimento = @num_atendimento", cn);
            cmd.Parameters.AddWithValue("@nome_pac", TextBox3.Text);
            cmd.Parameters.AddWithValue("@sexo", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@box", TextBox5.Text);
            cmd.Parameters.AddWithValue("@diagnostico", TextBox4.Text);
            cmd.Parameters.AddWithValue("@hora_pedido", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@obs", TextBox6.Text);
            cmd.Parameters.AddWithValue("@especial", DropDownList3.Text);
            cmd.Parameters.AddWithValue("@convenio", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Label9.Text = "Dados enviados com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                cn.Close();
                Response.AddHeader("Refresh", "2;URL=pedidos.aspx?session=" + Label1.Text);
                limpar(this);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("pedidos.aspx?session=" + Label1.Text);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("delete from tbpedido where num_atendimento=@num_atendimento", cn);
        cmd.Parameters.AddWithValue("@num_atendimento", TextBox2.Text);

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Label9.Text = "Alta excluida com sucesso";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
            cn.Close();
            Response.AddHeader("Refresh", "2;URL=pedidos.aspx?session=" + Label1.Text);
            limpar(this);
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
        {
            Label12.Text = "Isolamento";
        }
        else
        {
            Label12.Text = null;
        }
    }
}