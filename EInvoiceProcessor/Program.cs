

using EInvoiceProcessor.Envelope;
using System.Xml.Linq;
using System.Xml.Serialization;
using UblSharp;

class Program()
{
    static void Main()
    {
        #region Create an envelope with the given invoice files
        //var invoices = new List<string>
        //{
        //    Path.Combine("Invoices", "Invoice1.xml"),
        //    Path.Combine("Invoices", "Invoice2.xml"),
        //};

        //EnvelopeBuilder.CreateEnvelope
        //    (
        //    invoiceFilePaths: invoices,
        //    sender: "1234567890",
        //    reciever: "0987654321",
        //    outputPath: "../../../envelope.xml");

        //Console.WriteLine("Envelope created: envelope.xml");
        #endregion
        #region Filter Invoice and update values
        var xmlPath = "../../../Invoices/invoices.xml";

        XElement root = XElement.Load(xmlPath);

        var filteredInvoice = root.Elements("Invoice")
            .FirstOrDefault(inv => inv.Element("ID")?.Value == "INV-001");

        if (filteredInvoice != null)
        {
            filteredInvoice.Element("Total")!.Value = "2000.00";
            filteredInvoice.Element("Supplier")!.Value = "New Supplier Name";

            root.Save(xmlPath);

            Console.WriteLine("Invoice is updated");

        }
        else
        {
            Console.WriteLine("Invoice not found.");
        }
        #endregion


    }
}