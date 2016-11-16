using System.Threading.Tasks;
using Remember.iOS.CrossImplementations;
using Remember.Interfaces;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(QrCodeScanningService))]

namespace Remember.iOS.CrossImplementations
{
    public class QrCodeScanningService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new MobileBarcodeScanner();
            var scanResults = await scanner.Scan();
            return scanResults.Text;
        }
    }
}
