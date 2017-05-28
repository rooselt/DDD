using Sisacon.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Enuns;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Application
{
    public class CrudMsgFormater : ICrudMsgFormater
    {
        /// <summary>
        /// Cria a mensagem que será exibida no toastr para o cliente nas operaçõs de CRUD
        /// </summary>
        /// <param name="operationType">Tipo de operação - INSERT, DELETE, UPDATE</param>
        /// <param name="sex">Sexo da mensagem</param>
        /// <param name="entity">Entidade que está sendo manipulada Ex: Material, Fornecedor</param>
        /// <returns></returns>
        public string createClientCrudMessage(eOperationType eOperationType, eSex eSex, string entity)
        {
            var message = string.Empty;

            try
            {
                switch (eOperationType)
                {
                    case eOperationType.Insert:
                        {
                            var messageF = "A {0} foi Salva com Sucesso!";
                            var messageM = "O {0} foi Salvo com Sucesso!";

                            message = createMessageBySex(messageF, messageM, eSex, entity);
                        }
                        break;
                    case eOperationType.Update:
                        {
                            var messageF = "A {0} foi Atualizada com Sucesso!";
                            var messageM = "O {0} foi Atualizado com Sucesso!";

                            message = createMessageBySex(messageF, messageM, eSex, entity);
                        }
                        break;
                    case eOperationType.Select:
                        {
                            var messageF = "A {0} foi Carregada com Sucesso!";
                            var messageM = "O {0} foi Carregado com Sucesso!";

                            message = createMessageBySex(messageF, messageM, eSex, entity);
                        }
                        break;
                    case eOperationType.Delete:
                        {
                            var messageF = "A {0} foi Excluída com Sucesso!";
                            var messageM = "O {0} foi Excluído com Sucesso!";

                            message = createMessageBySex(messageF, messageM, eSex, entity);
                        }
                        break;
                    default:
                        {
                            return "Operação realizada com Sucesso!";
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return message;
        }

        public string createErrorCrudMessage()
        {
            var errorMessage = "Não foi possível concluir a operação. Tente novamente mais tarde.";

            return errorMessage;
        }

        /// <summary>
        /// Formata a mensagem de acordo com o gênero 
        /// </summary>
        /// <param name="messageF">Mensagem para gênero masculino</param>
        /// <param name="messageM">Mensagem para gênero feminino</param>
        /// <param name="sex">genero da entidade que está sendo manipulada</param>
        /// <param name="entity">Entidade</param>
        /// <returns></returns>
        public string createMessageBySex(string messageF, string messageM, eSex eSex, string entity)
        {
            var messageFormated = string.Empty;

            switch (eSex)
            {
                case eSex.Feminino:
                    {
                        messageFormated = string.Format(messageF, entity);
                    }
                    break;
                case eSex.Masculino:
                    {
                        messageFormated = string.Format(messageM, entity);
                    }
                    break;
            }

            return messageFormated;
        }
    }
}
