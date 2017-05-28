using System.Collections.Generic;
using System.Net;
using static Sisacon.Domain.Enuns.OperationType;

namespace Sisacon.Application
{
    public class ResponseMessage<T> where T : class
    {
        #region Propeties

        public ResponseMessage()
        {
            StatusCode = HttpStatusCode.OK;
            LogicalTest = false;
        }

        public int Quantity { get; set; }
        public T Value { get; set; }
        public List<T> ValueList { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public bool LogicalTest { get; set; }
        public bool UpdateNotifications { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public eOperationType OperationType { get; set; }

        #endregion

        #region Methods

        public ResponseMessage<T> createErrorResponse()
        {
            var response = new ResponseMessage<T>();

            response.LogicalTest = false;
            response.Message = "Ops! Algo de errado aconteceu. Nossa equipe de suporte já foi informada deste erro. Favor tente novamente mais tarde.";
            response.StatusCode = HttpStatusCode.BadRequest;

            return response;
        }

        public ResponseMessage<T> createInvalidResponse()
        {
            var response = new ResponseMessage<T>();

            response.LogicalTest = false;
            response.Message = "Os dados informados estão Incorretos.";
            response.StatusCode = HttpStatusCode.BadRequest;

            return response;
        }

        #endregion
    }
}
