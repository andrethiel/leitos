using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;


public partial class Default3 : System.Web.UI.Page
{
    public static string nome_acompanhante, acompanhante_cpf, nome_paciente, hora_init, hora_fim;
    public static DateTime dt_exame;

    protected void Page_Load(object sender, EventArgs e)
    {
        nome_acompanhante = Request.QueryString["nome_acompanhante"];
        acompanhante_cpf = Request.QueryString["acompanhante_cpf"];
        nome_paciente = Request.QueryString["paciente"];
        hora_init = Request.QueryString["hora_init"];
        hora_fim = Request.QueryString["hora_fim"];


        acompanhante.InnerHtml = nome_acompanhante;
        cpf_acompanhante.InnerHtml = Convert.ToInt64(acompanhante_cpf).ToString(@"000\.000\.000\-00");
        paciente.InnerHtml = nome_paciente;
        data.InnerHtml = DateTime.Now.Day + " de " + DateTime.Now.ToString("MMMM") + " de " + DateTime.Now.Year;
        hora_inicio.InnerHtml = hora_init;
        hora_final.InnerHtml = hora_fim;
        data_impressao.InnerHtml = "Campo Largo, " + DateTime.Now.Day + " de " + DateTime.Now.ToString("MMMM") + " de " + DateTime.Now.Year;

    }
}
