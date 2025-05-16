using System.Xml.Linq;

namespace EInvoiceProcessor.Envelope
{
    public class EnvelopeBuilder
    {
        public static void CreateEnvelope(List<string> invoiceFilePaths, string sender, string reciever, string outputPath)
        {

            var envelope = new XElement("Envelope",
                new XElement("Sender", sender),
                new XElement("Receiver", reciever),
                new XElement("InvoicesList")
            );

            foreach (var filePath in invoiceFilePaths)
            {
                var uuid = Guid.NewGuid().ToString();
                var fileName = Path.GetFileName(filePath);

                envelope.Element("InvoicesList").Add(
                    new XElement("Invoice",
                        new XElement("UUID", uuid),
                        new XElement("FileName", fileName),
                        new XElement("FilePath", filePath)
                    )
                );
            }

            var doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), envelope);

            doc.Save(outputPath);
        }
    }
}
