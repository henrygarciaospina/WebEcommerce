using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Errors
{
    public class CodeErrorResponse
    {
        public CodeErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {

            return statusCode switch
            {
                400 => "Errores en el envío de los datos",
                401 => "No tiene aurorización para este recurso",
                404 => "No se encontró el item buscado",
                505 => "Se producieron errores en el servidor",
                _ => null
            };
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
