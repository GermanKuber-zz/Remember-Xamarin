using System.Threading.Tasks;

namespace Remember.Services.Interfaces
{
    public interface IScanService
    {
        Task<string> ScannerSku();
    }
}