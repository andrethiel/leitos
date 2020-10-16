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

public partial class Postos_imprimir : System.Web.UI.Page
{
    public static string texto, dt_libera, sql, cd_exame, id, titulo, nome, prescricao, medico, prontuario,
        atendimento, convenio, sequencia, texto_novo;
    public static DateTime dt_exame;

    public static HttpCookie cookie_local, cookie_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        cookie_local = Request.Cookies["local"];
        cookie_id = Request.Cookies["id"];

        OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["tasy"].ConnectionString);
        OracleDataAdapter da = new OracleDataAdapter("select * from paciente_internado_atual_v WHERE ds_setor_atendimento = '" + cookie_local.Value.ToString() + "'", cn);
        try
        {
            cn.Open();
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
        OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["tasy"].ConnectionString);
        OracleCommand cmd = new OracleCommand("SELECT * FROM laudo_paciente WHERE cd_pessoa_fisica ='" + e.CommandArgument.ToString() + "' order by dt_exame desc", cn);

        try
        {
            cn.Open();

            OracleDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            { 
                OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM laudo_paciente WHERE cd_pessoa_fisica ='" + e.CommandArgument.ToString() + "' order by dt_exame desc", cn);

                try
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    Repeater2.DataSource = ds.Tables[0];
                    Repeater2.DataBind();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowDo()", true);
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
            else
            {
                Response.Write(e.CommandArgument.ToString());
                Label2.Text = "<b>Atenção:</b> Se o paciente realizou o exame favor aguardar a digitação do laudo";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        id = e.CommandArgument.ToString();

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbimpressao_laudo.*, tblogin.nome_completo from tbimpressao_laudo inner join tblogin on tbimpressao_laudo.id_usuario = tblogin.Id where sequencia=@sequencia", cn);
        cmd.Parameters.AddWithValue("@sequencia", id);

        try
        {
            cn.Open();

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                DateTime hora = Convert.ToDateTime(dr["hora"].ToString());
                DateTime data = Convert.ToDateTime(dr["data"].ToString());
                Label1.Text = "<b>" + dr["nome_completo"].ToString().ToUpper() + "</b> - " + data.ToString("dd/MM/yyyy") + " - " + hora.ToString("HH:mm");
                prescricao = dr["prescricao"].ToString();
                atendimento = dr["atendimento"].ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowImprimi()", true);
            }
            else
            {
                busca_exame("Não");
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
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("insert into tbimpressao_laudo (id_usuario, sequencia, setor, prescricao,atendimento, reimpresao, data_reimpressao, hora_reimpressao, motivo_reimpressao) values (@id_usuario, @sequencia, @setor,@prescricao,@atendimento, @reimpresao, @data_reimpressao, @hora_reimpressao, @motivo_reimpressao)", cn);
        cmd.Parameters.AddWithValue("@id_usuario", cookie_id.Value.ToString());
        cmd.Parameters.AddWithValue("@setor", cookie_local.Value.ToString());
        cmd.Parameters.AddWithValue("@prescricao", prescricao);
        cmd.Parameters.AddWithValue("@atendimento", atendimento);
        cmd.Parameters.AddWithValue("@sequencia", id);
        cmd.Parameters.AddWithValue("@reimpresao", "Sim");
        cmd.Parameters.AddWithValue("@data_reimpressao", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_reimpressao", DateTime.Now.ToShortTimeString());
        cmd.Parameters.AddWithValue("@motivo_reimpressao", DropDownList1.Text);

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            busca_exame("Sim");
            DropDownList1.SelectedValue = "";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "$('#Content_DropDownList1').prop('required', false);", true);

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
    public void busca_exame(string imprimir)
    {
        OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["tasy"].ConnectionString);
        OracleCommand cmd = new OracleCommand("SELECT laudo_paciente_v.nr_sequencia,laudo_paciente_v.dt_liberacao, obter_status_laudo(nr_sequencia) status FROM laudo_paciente_v WHERE nr_sequencia = '" + id + "'", cn);

        cn.Open();
        OracleDataReader dr = null;
        dr = cmd.ExecuteReader();


        if (dr.Read())
        {
            //dt_libera = dr["dt_liberacao"].ToString();

            if (dr["dt_liberacao"].ToString() != "" || dr["status"].ToString() == "Laudo liberado")
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "$('#solciita').modal('show');", true);
                Response.Write("<script>window.open('default3.aspx?sequencia=" + id + "&imprimir="+ imprimir + "','_blank');</script>");
            }
            else
            {
                Label3.Text = "Exame não liberado";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "document.getElementById('MyAlert').style.display = 'block'; $('#solciita').modal('show');", true);
            }
        }
    }
}