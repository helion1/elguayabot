using System.Threading.Tasks;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Infrastructure.Contract.Service
{
    public interface IGifSearchService
    {
        Task<Result<string>> GetRandomGif(string[] searchParams);
    }
}