using System;
using System.Threading.Tasks;
using Remember.Interfaces;
using Remember.Services.Interfaces;
using Xamarin.Forms;

namespace Remember.Services
{
    public class ScanService : IScanService
    {

        public async Task<string> ScannerSku()
        {
            try
            {
                var scanner = DependencyService.Get<IQrCodeScanningService>();
                var result = await scanner.ScanAsync();
                return result.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
