using NReco.PdfGenerator;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Web.Api.Teste.Controllers
{
    public class IndexController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            string html = "<html><head><style>" +
                          "body, td { font: 16px Arial }" +
                          ".tab1 { border: 1px #CCCCCC solid; border-radius: 15px; padding: 10px }" +
                          ".tab1 td { padding: 5px 10px }" +
                          ".td1e { background-color: #EEEEEE; width: 100px; text-align: right; padding: 5px 10px }" +
                          ".tab2 { border: 1px #CCCCCC solid; border-radius: 15px; padding: 10px; width: 100%; background-color: #EEEEEE }" +
                          ".tab2 td { text-align: center; font-weight: bold } " +
                          "</style></head><body>" +
                          "<b style=\"color: #5466dd; font-size: 22px\">REPRESENTAÇÕES<br />ENCAMINHADAS</b><br /><br />" +
                          "<table class=\"tab1\">" +
                          "<tr><td class=\"td1e\">CNPJ base</td><td>00.111.222/3333-44</td></tr>" +
                          "</table><br /><br />" +
                          "<table class=\"tab2\"><tr><td>Nenhum registro foi encontrado.</td></tr></table><br /><br />" +
                          "Data da consulta: 08/01/1987 às 00:50.<br />" +
                          "<b>Fonte:</b> Base Interna, período de 01/2020, atualizada em 12/02/2022.<br />" +
                          "Portaria AFB nº 1.750 de 12/04/2014, artigo 16." +
                          "</body></html>";

            HtmlToPdfConverter pdf = new HtmlToPdfConverter();
            pdf.CustomWkHtmlArgs = "--print-media-type --encoding utf-8";

            byte[] pdfBytes = pdf.GeneratePdf(html);

            IHttpActionResult response;
            HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.OK);
            responseMsg.Content = new ByteArrayContent(pdfBytes);
            responseMsg.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            responseMsg.Content.Headers.ContentDisposition.FileName = "test.pdf";
            responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response = ResponseMessage(responseMsg);
            return response;
        }
    }
}
