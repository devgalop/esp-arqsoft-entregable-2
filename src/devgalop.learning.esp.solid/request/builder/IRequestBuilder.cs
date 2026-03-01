using devgalop.learning.esp.solid.document;
using devgalop.learning.esp.solid.patient;
using devgalop.learning.esp.solid.provider;

namespace devgalop.learning.esp.solid.request.builder
{
    public interface IRequestBuilder
    {
        public IRequestBuilder AssociateRequestType(ERequestType requestType);
        public IRequestBuilder AssignAmmount(decimal amount);
        public IRequestBuilder AddAttachment(Document document);
        public IRequestBuilder AddAttachments(List<Document> documents);
        public IRequestBuilder AssignPatient(Patient patient);
        public IRequestBuilder AssignProvider(Provider provider);
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