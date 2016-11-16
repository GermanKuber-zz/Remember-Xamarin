using System.Threading.Tasks;
using Remember.Droid.CrossImplementations;
using Remember.Interfaces;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(QrCodeScanningService))]

namespace Remember.Droid.CrossImplementations
{
    public class QrCodeScanningService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var options = new MobileBarcodeScanningOptions();
            var scanner = new MobileBarcodeScanner();
            var scanResults = await scanner.Scan(options);
            return scanResults.Text;
        }
    }
}
