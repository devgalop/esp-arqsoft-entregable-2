using devgalop.learning.esp.solid.document;
using devgalop.learning.esp.solid.patient;
using devgalop.learning.esp.solid.provider;

namespace devgalop.learning.esp.solid.request
{
    public enum ERequestType
    {
        MEDICATION,
        PROCEDURE,
        EMERGENCY_CARE,
        DIAGNOSTIC_TEST
    }

    public enum ERequestState
    {
        DRAFT,
        SUBMITTED,
        UNDER_REVIEW,
        APPROVED,
        REJECTED
    }

    public record RequestResult(ERequestState State, string Message);

    public class Request
    {
        public Guid Id {get; private set;}
        public ERequestType RequestType {get; set;}
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; private set; }
        public List<Document> Attachments { get; set; }
        public Patient? Patient { get; set; }
        public Provider? Provider { get; set; }
        public ERequestState State { get; set; }
        public RequestResult? Result { get; set; }

        public Request()
        {
            Id = Guid.CreateVersion7();
            CreatedAt = DateTime.UtcNow;
            Attachments = new List<Document>();
            State = ERequestState.DRAFT;
        }

        public void AssignState(ERequestState newState)
        {
            State = newState;
        }

        public void AssignResult(RequestResult result)
        {
            Result = result;
        }
    }
}