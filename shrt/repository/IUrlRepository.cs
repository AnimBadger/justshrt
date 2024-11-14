using shrt.Dtos.requests;
using shrt.Dtos.response;
using shrt.models;

namespace shrt.repository;

public interface IUrlRepository
{
    Task<UrlResponse?> AddUrlAsync(CreateUrlRequest url);
    //Task<string?> OriginalUrlAsync(string url);
    //Task<Url?> UrLAnalticsAsync(string url);
    //Task<bool> DeleteUrlAsync(string url);
}
