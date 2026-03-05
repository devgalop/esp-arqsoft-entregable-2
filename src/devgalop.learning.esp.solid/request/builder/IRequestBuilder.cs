using devgalop.learning.esp.solid.document;
using devgalop.learning.esp.solid.patient;
using devgalop.learning.esp.solid.provider;

namespace devgalop.learning.esp.solid.request.builder
{
    /// <summary>
    /// Interfaz que define el contrato para construir una Request.
    /// </summary>
    public interface IRequestBuilder
    {
        /// <summary>
        /// Asocia un tipo de request especifico.
        /// </summary>
        /// <param name="requestType">El tipo de request a asociar.</param>
        /// <returns>El constructor de la request con el tipo asociado.</returns>
        public IRequestBuilder AssociateRequestType(ERequestType requestType);
        /// <summary>
        /// Asigna un monto a la request.
        /// </summary>
        /// <param name="amount">El monto a asignar.</param>
        /// <returns>El constructor de la request con el monto asignado.</returns>
        public IRequestBuilder AssignAmmount(decimal amount);
        /// <summary>
        /// Agrega un documento adjunto a la request.
        /// </summary>
        /// <param name="document">El documento a agregar.</param>
        /// <returns>El constructor de la request con el documento agregado.</returns>
        public IRequestBuilder AddAttachment(Document document);
        /// <summary>
        /// Agrega múltiples documentos adjuntos a la request.
        /// </summary>
        /// <param name="documents">La lista de documentos a agregar.</param>
        /// <returns>El constructor de la request con los documentos agregados.</returns>
        public IRequestBuilder AddAttachments(List<Document> documents);
        /// <summary>
        /// Asigna un paciente a la request.
        /// </summary>
        /// <param name="patient">El paciente a asignar.</param>
        /// <returns>El constructor de la request con el paciente asignado.</returns>
        public IRequestBuilder AssignPatient(Patient patient);
        /// <summary>
        /// Asigna un proveedor a la request.
        /// </summary>
        /// <param name="provider">El proveedor a asignar.</param>
        /// <returns>El constructor de la request con el proveedor asignado.</returns>
        public IRequestBuilder AssignProvider(Provider provider);
        /// <summary>
        /// Construye y retorna la request con todos sus atributos asignados.
        /// </summary>
        /// <returns>La request construida con todos sus atributos asignados.</returns>
        public Request Build();
    }

    public class RequestBuilder : IRequestBuilder
    {
        private readonly Request _request;

        public RequestBuilder()
        {
            _request = new Request();
        }
        public IRequestBuilder AddAttachment(Document document)
        {
            _request.Attachments.Add(document);
            return this;
        }

        public IRequestBuilder AddAttachments(List<Document> documents)
        {
            _request.Attachments.AddRange(documents);
            return this;
        }

        public IRequestBuilder AssignAmmount(decimal amount)
        {
            _request.Value = amount;
            return this;
        }

        public IRequestBuilder AssignPatient(Patient patient)
        {
            _request.Patient = patient;
            return this;
        }

        public IRequestBuilder AssignProvider(Provider provider)
        {
            _request.Provider = provider;
            return this;
        }

        public IRequestBuilder AssociateRequestType(ERequestType requestType)
        {
            _request.RequestType = requestType;
            return this;
        }

        public Request Build()
        {
            return _request;
        }
    }
}