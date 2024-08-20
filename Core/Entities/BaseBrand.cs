namespace Core.Entities;


// burası tüm projede ortak kullanılabilecek olan bir entity barındırıyor
// o yüzden core'a koyduk


public class BaseBrand<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    
    // burada soru işareti konma sebebi oluşturmasanda da olur demek
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; } 
    
}

