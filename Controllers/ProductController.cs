using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Product.Helpers;
using Product.Models;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly DbAccess _db;
        public ProductController(DbAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> Get()
            {
                var found = await _db.Collection.Find(Builders<ProductModel>.Filter.Empty).ToListAsync();
                if(found.Count == 0)
                {
                    return NotFound();
                }

                return found;
            }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> Get(Guid id)
            {
                var found = await _db.Collection.Find(Builders<ProductModel>.Filter.Eq("Id", id)).FirstAsync();
                if(found == null)
                {
                    return NotFound();
                }

                return found;
            }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] ProductCreateInputModel model)
        {
            var generatedId = Guid.NewGuid();

            await _db.Collection.InsertOneAsync(new ProductModel{Id=generatedId, Name = model.Name, Price = model.Price});

            return generatedId;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductUpdateInputModel model)
        {
            await _db.Collection.UpdateOneAsync(
                Builders<ProductModel>.Filter.Eq("Id", model.Id),
                Builders<ProductModel>.Update.Set(x => x.Name, model.Name).Set(x => x.Price, model.Price));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async void Delete(Guid id)
            =>
                await _db.Collection.DeleteOneAsync(Builders<ProductModel>.Filter.Eq("Id", id));
    }
}