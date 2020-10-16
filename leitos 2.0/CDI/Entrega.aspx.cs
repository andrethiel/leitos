using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class CDI_Entrega : System.Web.UI.Page
{
    public static string atendimento, prescricao, exame, sequencia;
    public static HttpCookie cookie_id, cookie_local;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbimpressao_laudo.*, tblogin.nome_completo from tbimpressao_laudo inner join tblogin on tbimpressao_laudo.id_usuario = tblogin.Id where prescricao='" +TextBox4.Text+ "' or atendimento='" + TextBox4.Text + "'", cn);
        try
        {
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();
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

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
        atendimento = valores[0].ToString();
        prescricao = valores[1].ToString();
        exame = valores[2].ToString();
        sequencia = valores[3].ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowPopup();", true);

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        cookie_id = Request.Cookies.Get("id");
        cookie_local = Request.Cookies.Get("local");

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("insert into tbimpressao_laudo (id_usuario, setor, sequencia, prescricao, atendimento, exame, reimpresao, data_reimpressao, hora_reimpressao, motivo_reimpressao) values (@id_usuario, @setor, @sequencia, @prescricao, @atendimento, @exame, @reimpresao, @data_reimpressao, @hora_reimpressao, @motivo_reimpressao)", cn);
        cmd.Parameters.AddWithValue("@id_usuario", cookie_id.Value.ToString());
        cmd.Parameters.AddWithValue("@setor", cookie_local.Value.ToString());
        cmd.Parameters.AddWithValue("@sequencia", sequencia);
        cmd.Parameters.AddWithValue("@prescricao", prescricao);
        cmd.Parameters.AddWithValue("@atendimento", atendimento);
        cmd.Parameters.AddWithValue("@exame", exame);
        cmd.Parameters.AddWithValue("@reimpresao", "Sim");
        cmd.Parameters.AddWithValue("@data_reimpressao", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_reimpressao", DateTime.Now.ToShortTimeString());
        cmd.Parameters.AddWithValue("@motivo_reimpressao", "Reimpressão Centro de Imagens");

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Label1.Text = "Laudos registrado com sucesso";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Close();
        }


    }
}