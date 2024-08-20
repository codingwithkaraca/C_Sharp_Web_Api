using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IBrandService
{
    // burada kullanıcıya veritabanı nesnesini göstermemek için Brand türünde döndürüyoruz
        
    CreatedBrandResponse Add(CreateBrandRequest createBrandRequest);
    List<GetAllBrandResponse> GetAll();
    
}