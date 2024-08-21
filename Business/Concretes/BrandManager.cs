using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class BrandManager: IBrandService
{
    private readonly IBrandDal _brandDal;
    
    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }
    
    public CreatedBrandResponse Add(CreateBrandRequest createBrandRequest)
    {
        // kullanıcıdan gelen veri isteği için
        // direkt kullanıcıya vermemek vermemek gerekiyor dolaylı yoldan alacağız

        // bu işleme de mapping deniyor
        
        // kullanıcadan gelen marka isteği oluştur komutunda sadece gelen marka değerini alıp 
        // veritabanı nesnesine-entity'e dönüştürüp kayıt ediyoruz daha sonra 
        // İşlemin başarı ile yapıldığına dair kullanıcıya veri döndürmek için ise 
        // CreatedBrandResponse türünde nesne oluşturup o nesnenin değerlerine
        // Brand'den yani entity den özellikleri alıp atıyoruz.
        
        // mapping -> automapper
        Brand brand = new();
        brand.Name = createBrandRequest.Name;
        brand.CreatedDate = DateTime.Now;
        _brandDal.Add(brand);
        
        CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
        createdBrandResponse.Id = 4;
        createdBrandResponse.Name = brand.Name;
        createdBrandResponse.CreatedDate = brand.CreatedDate;

        return createdBrandResponse;
        
    }

    public List<GetAllBrandResponse> GetAll()
    {
        List<Brand> brands = _brandDal.GetAll();
        
        List<GetAllBrandResponse> getAllBrandResponses = new List<GetAllBrandResponse>();

        foreach (var brand in brands)
        {
            GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();
            getAllBrandResponse.Id = brand.Id;
            getAllBrandResponse.Name = brand.Name;
            getAllBrandResponse.CreatedDate = brand.CreatedDate;
            
            getAllBrandResponses.Add(getAllBrandResponse);
            
        }
        
        return getAllBrandResponses;
    }
}