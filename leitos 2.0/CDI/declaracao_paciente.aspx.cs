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
    public static string nome_paciente, hora_init, hora_fim, cpf;

    protected void Page_Load(object sender, EventArgs e)
    {
        nome_paciente = Request.QueryString["paciente"];
        cpf = Request.QueryString["cpf"];
        hora_init = Request.QueryString["hora_init"];
        hora_fim = Request.QueryString["hora_fim"];

        paciente.InnerHtml = nome_paciente;
        cpf_paciente.InnerHtml = Convert.ToInt64(cpf).ToString(@"000\.000\.000\-00");
        data.InnerHtml = DateTime.Now.Day + " de " + DateTime.Now.ToString("MMMM") + " de " + DateTime.Now.Year;
        hora_inicio.InnerHtml = hora_init;
        hora_final.InnerHtml = hora_fim;
        data_impressao.InnerHtml = "Campo Largo, " + DateTime.Now.Day + " de " + DateTime.Now.ToString("MMMM") + " de " + DateTime.Now.Year;
    }
}
