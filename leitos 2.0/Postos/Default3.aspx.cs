using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Globalization;
using System.Web.Services;
using System.Data.SqlClient;

public partial class Default3 : System.Web.UI.Page
{
    public static string texto, dt_libera, sql, cd_exame, id, titulo, nome, prescricao, medico_solicita, prontuario,
        atendimento, convenio, sequencia, medico_laudo, medico_residente, crm, uf_crm, usuario_digita, reimpressao;
    public static DateTime dt_exame;

    public static HttpCookie cookie_local, cookie_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        cookie_local = Request.Cookies["local"];
        cookie_id = Request.Cookies["id"];
        sequencia = Request.QueryString["sequencia"];
        reimpressao = Request.QueryString["imprimir"];

        OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["tasy"].ConnectionString);
        OracleCommand cmd = new OracleCommand("SELECT a.*, obter_prontuario_atendimento(a.nr_atendimento) prontuario, b.nr_crm, b.uf_crm FROM laudo_paciente_v a, medico_v b WHERE a.nr_sequencia = '"+Request.QueryString["sequencia"] +"' AND a.cd_medico_resp = b.cd_pessoa_fisica", cn);

        cn.Open();
        OracleDataReader dr = null;
        dr = cmd.ExecuteReader();


        if (dr.Read())
        {
            prontuario = dr["prontuario"].ToString();
            dt_libera = dr["dt_liberacao"].ToString();
            titulo = dr["ds_titulo_laudo"].ToString();
            nome = dr["nm_paciente"].ToString();
            prescricao = dr["nr_prescricao"].ToString();
            dt_exame = Convert.ToDateTime(dr["dt_exame"].ToString());
            medico_solicita = dr["nm_medico"].ToString();
            atendimento = dr["nr_atendimento"].ToString();
            convenio = dr["ds_convenio"].ToString();
            medico_laudo = dr["nm_medico_resp"].ToString();
            crm = dr["nr_crm"].ToString();
            uf_crm = dr["uf_crm"].ToString();
            medico_residente = dr["nm_medico_resid"].ToString();
            usuario_digita = dr["nm_usuario_digitacao"].ToString();

            cmd = new OracleCommand("SELECT * FROM laudo_paciente WHERE nr_sequencia = '" + Request.QueryString["sequencia"] + "'", cn);

            dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                texto = dr["ds_laudo"].ToString().Trim();
                MarkupConverter.MarkupConverter markupConverter = new MarkupConverter.MarkupConverter();

                texto = markupConverter.ConvertRtfToHtml(texto);

                nome_paciente.InnerHtml = "Nome: " + nome;
                prescricao_paciente.InnerHtml = "Prescrição: " + prescricao;
                solicita.InnerHtml = "Solicitação: " + medico_solicita;
                exame_paciente.InnerHtml = "Exame: " + titulo;
                data_exame.InnerHtml = "Data Exame: " + Convert.ToString(dt_exame.ToString("dd/MM/yyyy"));
                prontuario_paciente.InnerHtml = "Prontuário: " + prontuario;
                atendimento_paciente.InnerHtml = "Atendimento: " + atendimento;
                convenio_paciente.InnerHtml = "Concênio: " + convenio;
                laudo.InnerHtml = texto;
                medico.InnerHtml = "Dr(a) "+ medico_laudo;
                crm_medico.InnerHtml = "CRM - " + uf_crm +" " + crm;
                digitacao.InnerHtml = "Digitado por: " + usuario_digita;
                residente.InnerHtml = "Dr(a) " + medico_residente;
                data_impressao.InnerHtml = "Campo Largo, " + DateTime.Now.Day + " de " + DateTime.Now.ToString("MMMM") + " de " + DateTime.Now.Year;
                insere();

            }
        }
    }
    public void insere()
    {
        if(reimpressao == "Não")
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into tbimpressao_laudo (id_usuario, sequencia, setor, prescricao, atendimento, exame, data, hora, reimpresao) values (@id_usuario, @sequencia, @setor, @prescricao, @atendimento, @exame, @data, @hora, @reimpresao)", cn);
            cmd.Parameters.AddWithValue("@id_usuario", cookie_id.Value.ToString());
            cmd.Parameters.AddWithValue("@setor", cookie_local.Value.ToString());
            cmd.Parameters.AddWithValue("@prescricao", prescricao);
            cmd.Parameters.AddWithValue("@atendimento", atendimento);
            cmd.Parameters.AddWithValue("@exame", titulo);
            cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@hora", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@sequencia", sequencia);
            cmd.Parameters.AddWithValue("@reimpresao", "Não");


            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
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
            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("update tbimpressao_laudo set prescricao=@prescricao, atendimento=@atendimento, exame=@exame where sequencia=@sequencia", cn);
            //cmd.Parameters.AddWithValue("@prescricao", prescricao);
            //cmd.Parameters.AddWithValue("@atendimento", atendimento);
            //cmd.Parameters.AddWithValue("@exame", titulo);
            //cmd.Parameters.AddWithValue("@sequencia", sequencia);


            //try
            //{
            //    cn.Open();
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    cn.Close();
            //}
        }

    }
}
