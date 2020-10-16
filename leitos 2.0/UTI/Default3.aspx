<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Script/jquery-3.2.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        /*            --------------------------------------------------- RESET */

        html {
            font-size: 62.5%;
            -ms-text-size-adjust: 62.5%; /* 2 */
            -webkit-text-size-adjust: 62.5%; /* 2 */
        }
        /* Grupo de Conteudo.
               ========================================================================== */

        /**
             * Correção de tela no IE 9-.
             * 1. Adicionando correção de display no IE.
             */

        figcaption,
        figure,
        main { /* 1 */
            display: block;
        }

        /**
             * Adicionando correção de margin no IE 8.
             */

        figure {
            margin: 0;
        }

        /* Formato Padão.
               ========================================================================== */

        h1, h2, h3, h4, h5, h6 {
            font-weight: normal;
            margin: 0;
        }

        ul {
            margin: 0;
            padding: 0;
        }

        li {
            list-style: none;
            margin: 0;
        }

        /* WRAP */

        header, main, footer {
            max-width: 880px;
            padding-left: 60px;
            padding-right: 60px;
            margin: auto;
            display: block;
        }

        /* CLEARFIX */

        .clearfix:after {
            visibility: hidden;
            display: block;
            font-size: 0;
            content: " ";
            clear: both;
            height: 0;
        }

        .clearfix {
            display: inline-block;
        }

        * html .clearfix {
            height: 1%;
        }

        .clearfix {
            display: block;
        }

        /*            ------------------------------------------------------------------------------------ FIM _ RESET*/

        html, body {
            height: 100%;
            min-height: 100%;
            font-family: 'Times New Roman';
            margin: 0;
        }

        header {
            font-family: 'Arial';
            width: 100%;
            z-index: 10;
            position: relative;
            margin-bottom: -169px;
        }

        main {
            font-size: 14px;
            min-height: 100%;
            z-index: 10;
            position: relative;
            padding-top: 169px;
            padding-bottom: 250px;
            width: 880px;
            -webkit-box-shadow: 0px -2px 12px -2px rgba(130,130,130,0.2);
            -moz-box-shadow: 0px -2px 12px -2px rgba(130,130,130,0.2);
            -ms-box-shadow: 0px -2px 12px -2px rgba(130,130,130,0.2);
            -o-box-shadow: 0px -2px 12px -2px rgba(130,130,130,0.2);
            box-shadow: 0px -2px 12px -2px rgba(130,130,130,0.2);
        }

            main p {
                line-height: 14px;
                margin: 0px;
            }

        header h1 {
            font-family: 'Corbel';
            color: rgb(53, 75, 157);
            text-align: center;
            margin-bottom: 30px;
            font-size: 40px;
        }

        /* CLEARFIX LI */

        header article li:after {
            visibility: hidden;
            display: block;
            font-size: 0;
            content: " ";
            clear: both;
            height: 0;
        }

        header article li {
            display: inline-block;
        }

        * html header article li {
            height: 1%;
        }

        header article li {
            display: block;
        }

        /* FIM - CLEARFIX */

        header article div {
            text-align: left;
            position: relative;
            float: left;
            font-weight: bold;
            font-size: 13px;
            z-index: 10;
        }

        header article li div:last-child {
            width: 25%;
        }

        header article li div:first-child {
            width: 75%;
        }

        footer {
            margin: 0 auto;
            margin-top: -250px;
            padding-top: 100px;
            text-align: center;
            width: 100%;
            font-size: 16px;
            z-index: 10;
            position: relative;
            font-family: "Calibri";
        }

            footer > div:first-child {
                width: 100%;
                font-size: 12px;
                margin-bottom: 40px;
            }

                footer > div:first-child div {
                    position: relative;
                    float: left;
                    width: 50%;
                    text-align: center;
                }

                footer > div:first-child p:first-child {
                    display: inline-block;
                    border-top: #222 solid 1px;
                    width: 230px;
                    padding-top: 10px;
                    font-weight: bold;
                }

                footer > div:first-child p {
                    margin: 0;
                }

            footer > div:last-child {
                border-top: rgb(53, 75, 157) solid 2px;
                color: rgb(53, 75, 157);
                padding: 5px 0 0 0;
            }

                footer > div:last-child p {
                    margin: 0;
                    line-height: 20px;
                }

            footer .sub div {
                position: relative;
                float: left;
                width: 33%;
                font-size: 13px;
                margin-bottom: 5px;
            }

                footer .sub div:last-child {
                    font-size: 18px;
                }

        .background {
            background-image: url(../images/logo_laudo.png);
            background-position: left;
            background-repeat: no-repeat;
            width: 1000px;
            height: 100%;
            position: fixed;
            top: 0px;
            z-index: 0;
            left: 50%;
            margin-left: -500px;
        }

        @page {
            margin: 0.5in;
            margin-left: 0;
        }

        @media print {
            html, body {
                height: auto;
            }

            header {
                position: fixed;
                top: 0px;
                margin-left: 6.5%;
                width: 93.5%;
                padding: 0;
            }

            main {
                margin-left: 6.5%;
                width: 93.5%;
                padding: 0;
                -webkit-box-shadow: none;
                -moz-box-shadow: none;
                -ms-box-shadow: none;
                -o-box-shadow: none;
                box-shadow: none;
            }

            footer {
                position: fixed;
                bottom: 0px;
                margin: 0;
                margin-left: 6.5%;
                width: 93.5%;
                padding: 0;
            }

            main p.pagebreak {
                padding-top: 200px;
            }

            .background {
                width: 100%;
                margin: 0;
                left: auto;
            }
        }
    </style>
    <script type="application/javascript">

        $(document).ready(function ($) {
            var AltContPag = 0;     // Height do conteúdo da página na impressão.
            var cond = 0;           // Para realizar a posição do corpo após a quebra de página.

            // Coloca espaçamentos dentro de tag "P" vazio. (Para <P />)
            $("main > div > p").each(function (index) {
                if ($(this).text().trim() == '') $(this).append('&nbsp;');
            });

            // Formatação para quebra de páginas na impressão.
            $("main > div").children().each(function (index) {

                if ($(this).text().length != 0) {
                    // Tamanho de margin top, margin botton, padding top e padding bottom para cauculo em altura.
                    var margin = parseInt($(this).css('margin-top')) + parseInt($(this).css('margin-bottom'));
                    var padding = parseInt($(this).css('padding-top')) + parseInt($(this).css('padding-bottom'));

                    // Adiciona posição do corpo em relação a altura depois de quebra de página.
                    if (cond == 0) { $(this).addClass('pagebreak'); cond = 1 };

                    // Calculo total do volume em altura do corpo da página.
                    AltContPag += $(this).height() + margin + padding;

                    // Força quebra de página no tamanho especificado em "PX".
                    if (AltContPag > 525) {
                        $(this).css({ 'page-break-after': 'always' });           // Adiciona "page-break-after" na tag para quebra de página.
                        AltContPag = $(this).height() + margin + padding;         // Calculo total do volume em altura do corpo da página.
                        cond = 0;                                                   // Para realizar a posição do corpo após a quebra de página.
                    }
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <header>
            <h1>ROCIO DIAGNÓSTICO POR IMAGEM</h1>
            <article>
                <ul>
                    <li>
                        <div style="text-align: center; width: 100%">Laudo de Exame</div>
                    </li>
                    <li>
                        <div id="nome_paciente" runat="server"></div>
                        <div id="prescricao_paciente" runat="server"></div>
                    </li>
                    <li>
                        <div id="solicita" runat="server"></div>
                    </li>
                    <li>
                        <div id="exame_paciente" runat="server"></div>
                        <div id="data_exame" runat="server"></div>
                    </li>
                    <li>
                        <div id="prontuario_paciente" runat="server"></div>
                        <div id="atendimento_paciente" runat="server"></div>
                    </li>
                    <li>
                        <div id="convenio_paciente" runat="server"></div>
                    </li>
                </ul>
            </article>
        </header>

        <main id="laudo" runat="server"></main>

        <footer>
            <div class="clearfix">
                <div>
                    <p id="medico" runat="server"></p>
                    <p id="crm_medico" runat="server"></p>
                </div>
                <div>
                    <p id="residente" runat="server"></p>
                    <p>
                        Médico(a) Residente
                    </p>
                </div>
            </div>
            <div class="sub clearfix">
                <div id="data_impressao" runat="server"></div>
                <div id="digitacao" runat="server"></div>
                <div><b>Laudo cópia</b></div>
            </div>
            <div>
                <p>Rua Maria Aparecida de Oliveira, 599 - Loteamento São Gerônimo - 83606-177 - Campo Largo/PR</p>
                <p>(41) 3136.2515 - 75.802.348/0001-00 - www.hospitaldorocio.com.br</p>
            </div>
        </footer>
        <div class="background">
        </div>
        <script>
            function imprimir() {
                window.print();

            }
            
            setTimeout(imprimir, 1000);
            window.onafterprint = function () {
                window.close();
            };

        </script>
    </form>
</body>
</html>
