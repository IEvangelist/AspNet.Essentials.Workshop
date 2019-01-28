using System.Threading.Tasks;
using AspNet.Essentials.Workshop.Models;

namespace AspNet.Essentials.Workshop.Abstractions
{
    public interface IBreweryClient
    {
        Task<Results> GetBeersAsync();
    }
}