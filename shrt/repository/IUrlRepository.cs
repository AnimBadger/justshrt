using shrt.models;

namespace shrt.repository;

public interface IUrlRepository
{
    Task AddUrlAsync(Url url);
    Task<string?> OriginalUrlAsync(string url);
    //Task<Url?> UrLAnalticsAsync(string url);
    Task<bool> DeleteUrlAsync(string url);
}
