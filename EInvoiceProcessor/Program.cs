

using EInvoiceProcessor.Envelope;
using System.Xml.Serialization;
using UblSharp;

class Program()
{
    static void Main()
    {
        var invoices = new List<string>
        {
            Path.Combine("Invoices", "Invoice1.xml"),
            Path.Combine("Invoices", "Invoice2.xml"),
        };

        EnvelopeBuilder.CreateEnvelope
            (
            invoiceFilePaths: invoices,
            sender: "1234567890",
            reciever: "0987654321",
            outputPath: "../../../envelope.xml");

        Console.WriteLine("Envelope created: envelop.xml");

    }
}