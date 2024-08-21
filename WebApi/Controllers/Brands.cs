using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //attributs 
    [Route("api/[controller]")]
    [ApiController]
    public class Brands : ControllerBase
    {
        
        private IBrandService _brandService;

        public Brands(IBrandService brandService)
        {
            _brandService = brandService;
        }
        
        


        [HttpPost]
        public IActionResult Add(CreateBrandRequest createBrandRequest)
        {
            CreatedBrandResponse createdBrandResponse = _brandService.Add(createBrandRequest);
            
            return Ok(createdBrandResponse);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_brandService.GetAll());
        }


    }
}
