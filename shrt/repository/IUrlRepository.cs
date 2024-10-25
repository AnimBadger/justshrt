using shrt.Dtos.requests;
using shrt.models;

namespace shrt.repository;

public interface IUrlRepository
{
    Task AddUrlAsync(Url url);
}
