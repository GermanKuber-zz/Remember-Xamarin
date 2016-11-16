using System.Threading.Tasks;
using Remember.Interfaces;
using Remember.UWP.CrossImplementations;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(QrCodeScanningService))]

namespace Remember.UWP.CrossImplementations
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
