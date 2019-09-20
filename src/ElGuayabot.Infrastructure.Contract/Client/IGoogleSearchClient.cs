using System.Threading.Tasks;
using ElGuayabot.Common.Result;

namespace ElGuayabot.Infrastructure.Contract.Client
{
    public interface IGoogleSearchClient
    {
        Task<Result<string>> Search(params string[] searchParams);
    }
}