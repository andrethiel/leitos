using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

public partial class CDI_declaracao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["tasy"].ConnectionString);
        OracleCommand cmd = new OracleCommand("SELECT * FROM atendimentos_v WHERE nr_atendimento = '" + TextBox1.Text + "'", cn);

        try
        {
            cn.Open();
            OracleDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cmd = new OracleCommand("SELECT * FROM paciente_v WHERE cd_pessoa_fisica  = '" + dr["cd_pessoa_fisica"].ToString() + "'", cn);

                dr.Close();
                dr.Dispose();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    TextBox2.Text = dr["nm_pessoa_fisica"].ToString();
                    TextBox3.Text = dr["nr_cpf"].ToString();
                }
            }
            else
            {
                Label1.Text = "Atendimento/Paciente não encontrado";
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(DropDownList1.Text == "Acompanhante")
        {
            string cpf = TextBox7.Text;
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");


            Response.Write("<script>window.open('Acompanhante.aspx?nome_acompanhante=" + TextBox6.Text + "&acompanhante_cpf=" + cpf + "&paciente=" + TextBox2.Text + "&hora_init=" + TextBox4.Text + "&hora_fim="+ TextBox5.Text + "','_blank');</script>");
            Response.AddHeader("Refresh", "1;URL=" + Request.RawUrl);
        }
        else
        {
            string cpf = TextBox3.Text;
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");

            Response.Write("<script>window.open('declaracao_paciente.aspx?&paciente=" + TextBox2.Text + "&cpf=" + cpf + "&hora_init=" + TextBox4.Text + "&hora_fim=" + TextBox5.Text + "','_blank');</script>");
            Response.AddHeader("Refresh", "1;URL=" + Request.RawUrl);
        }

        
    }
}