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
        Brand brand = new();
        brand.Name = createBrandRequest.Name;
        brand.CreatedDate = DateTime.Now;
        _brandDal.Add(brand);
        
        CreatedBrandResponse response = new CreatedBrandResponse();
        response.Id = 4;
        response.Name = brand.Name;
        response.CreatedDate = brand.CreatedDate;

        return response;
        
    }

    public List<GetAllBrandResponse> GetAll()
    {
        throw new NotImplementedException();
    }
}