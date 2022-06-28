using eCommenceAPI.Application.Abstractions.Storage;
using eCommenceAPI.Application.IRepositories;
using eCommenceAPI.Application.RequestParameters;
using eCommenceAPI.Application.ViewModels.Products;
using eCommenceAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace eCommenceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        private readonly IProductImageFileReadRepository _productImageFileReadRepository;
        private readonly IStorageService _storageService;

        public ProductsController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IWebHostEnvironment webHostEnvironment,
            IProductImageFileWriteRepository productImageFileWriteRepository,
            IProductImageFileReadRepository productImageFileReadRepository, IStorageService storageService)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _storageService = storageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository
                .GetAll(false)
                .Skip(pagination.Page * pagination.Size)
                .Take(pagination.Size)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.CreatedDate,
                    p.UpdatedDate
                });
            return Ok(new
            {
                totalCount,
                products,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductViewModel createProductViewModel)
        {
            if (ModelState.IsValid)
            {

            }
            await _productWriteRepository.AddAsync(new()
            {
                Name = createProductViewModel.Name,
                Price = createProductViewModel.Price,
                Stock = createProductViewModel.Stock
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();

            return Ok(new
            {
                message = "Product is deleted successfully."
            });
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            //var datas = await _fileService.UploadAsync("resource/product-images", Request.Form.Files);

            var datas = await _storageService.UploadAsync("product-images", Request.Form.Files);

            await _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            {
                FileName = d.fileName,
                Path = d.pathOrContainerName,
                Storage = _storageService.StorageName
            }).ToList());
            await _productImageFileWriteRepository.SaveAsync();

            return Ok();
        }
    }
}
