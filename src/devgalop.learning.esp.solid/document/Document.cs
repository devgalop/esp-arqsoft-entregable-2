
namespace devgalop.learning.esp.solid.document
{
    public enum EDocumentType
    {
        INVOICE,
        PRESCRIPTION,
        MEDICAL_RECORD,
        MEDICAL_ORDER,
        DIAGNOSTIC_RESULT
    }
    public class Document
    {
        public Guid Id { get; private set; }
        public EDocumentType DocumentType { get; set; }
        public string Content { get; set; }

        public Document(EDocumentType documentType, string content)
        {
            Id = Guid.CreateVersion7();
            DocumentType = documentType;
            Content = content;
        }
    }
}