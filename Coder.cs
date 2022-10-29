using IronBarCode;

namespace QR_ZXing
{
    class Program
    {
        static void Main(string[] args)
        {
            // ввод айди юзера
            string uid = "1234567890";
            var CreatedQRCode = QRCodeWriter.CreateQrCode(uid, 500, QRCodeWriter.QrErrorCorrectionLevel.Medium);
            // создание *.png файла
            string PathToPNGFile = string.Format("C:/Users/Diman/source/repos/QR_ZXing/{0}.png", uid);
            CreatedQRCode.SaveAsPng(PathToPNGFile);
            // создание *.html файла
            string PathToHTMLFile = string.Format("C:/Users/Diman/source/repos/QR_ZXing/{0}.html", uid);
            CreatedQRCode.SaveAsHtmlFile(PathToHTMLFile);
            // проверка QR кода вместе с выводом
            BarcodeResult Result = BarcodeReader.QuicklyReadOneBarcode(PathToPNGFile, BarcodeEncoding.QRCode);
            if (Result != null) Console.WriteLine(Result.Value);
        }
    }
}