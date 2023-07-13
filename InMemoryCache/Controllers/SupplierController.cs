using InMemoryCache.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        private readonly DbContextClass _dbContext;

        public SupplierController(ICacheService cacheService,DbContextClass dbContext)
        {
            _cacheService = cacheService;
            _dbContext = dbContext;
                
        }
        [HttpGet("suppliers")]
        public IEnumerable<Supplier> Get()
        {
            var cacheData = _cacheService.GetData<IEnumerable<Supplier>>("supplier");
            if(cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            cacheData = _dbContext.Suppliers.ToList();
            _cacheService.SetData<IEnumerable<Supplier>>("supplier", cacheData, expirationTime);
            return cacheData;
        }
        [HttpPost("addSupplier")]
        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            var obj = await _dbContext.Suppliers.AddAsync(supplier);
            _cacheService.RemoveData("supplier");
            _dbContext.SaveChanges();
            return obj.Entity;
        }
    }
}
