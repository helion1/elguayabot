using System.Threading.Tasks;
using ElGuayabot.Common.Result;
using ElGuayabot.Infrastructure.Implementation.Model;

namespace ElGuayabot.Infrastructure.Contract.Client
{
    public interface IGiphyClient
    {
        Task<Result<GiphySearchResponse>> Search(params string[] searchParams);
    }
}