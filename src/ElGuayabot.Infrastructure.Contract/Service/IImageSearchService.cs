using System.Threading.Tasks;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Infrastructure.Contract.Service
{
    public interface IImageSearchService
    {
        Task<Result<string>> GetRandomUrl(params string[] searchParams);
    }
}