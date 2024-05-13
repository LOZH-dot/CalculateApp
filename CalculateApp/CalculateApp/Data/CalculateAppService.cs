using CalculateApp.Data.CalculateApp;
using Microsoft.EntityFrameworkCore;

namespace CalculateApp.Data
{
    public class CalculateAppService
    {
        private readonly CalculateAppDBContext _context;
        public CalculateAppService(CalculateAppDBContext context)
        {
            _context = context;
        }

        public async Task<Estimate> CreateEstimateAsync(Estimate estimate)
        {
            _context.Estimates.Add(estimate);
            _context.SaveChanges();
            return await Task.FromResult(estimate);
        }

        public async Task<Estimate> CloseActiveEstimateAsync()
        {
            var activeEstimate = _context.Estimates
                .Where(x => x.IsActive == true)
                .FirstOrDefault();
            activeEstimate.IsActive = false;
            _context.SaveChanges();
            return await Task.FromResult(activeEstimate);
        }

        public async Task<bool> DeleteProductEstimateAsync(ProductsEstimate productsEstimate)
        {
            _context.ProductsEstimates.Remove(productsEstimate);
            _context.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<List<ProductsEstimate>> GetActiveProductsEstimatesAsync(string AspUserId)
        {
            return await _context.ProductsEstimates
                .Include(x => x.Product)
                .Include(x => x.Estimate)
                .Where(x => x.Estimate.AspUserId == AspUserId
                && x.Estimate.IsActive == true)
                .ToListAsync();
        }

        public async Task<ProductsEstimate> CreateProductEstimateAsync(ProductsEstimate productsEstimate)
        {
            _context.ProductsEstimates.Add(productsEstimate);
            _context.SaveChanges();
            return await Task.FromResult(productsEstimate);
        }
        public async Task<Estimate> GetActiveEstimateAsync(string AspUserId)
        {
            return await Task.FromResult(_context.Estimates
                .Include(x => x.ProductsEstimates)
                .Where(x => x.AspUserId == AspUserId
                && x.IsActive == true)
                .FirstOrDefault());
        }

        public async Task<List<Estimate>> GetDoneEstimatesAsync(string AspUserId)
        {
            return await _context.Estimates
                .Include(x => x.ProductsEstimates)
                .Where(x => x.AspUserId == AspUserId
                && x.IsActive == false)
                .ToListAsync();
        }

        public async Task<bool> DeleteRoomAsync(Room room)
        {
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<Room> CreateRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return await Task.FromResult(room);
        }
        public async Task<List<Room>> GetRoomsAsync(string AspUserId)
        {
            return await _context.Rooms
                .Where(x => x.AspNetUserId == AspUserId)
                .ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var cProduct = _context.Products.Find(product.Id);
            cProduct.Name = product.Name;
            cProduct.Description = product.Description; 
            cProduct.Image = product.Image;
            cProduct.Price = product.Price;
            cProduct.CategoryId = product.CategoryId;
            cProduct.Characteristics = product.Characteristics;
            _context.SaveChanges();
            return await Task.FromResult(cProduct);
        }
        public async Task<bool> DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _context.Products
                .Include(x => x.Characteristics)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return await Task.FromResult(product);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(x => x.Characteristics)
                .Include(x => x.Category)
                .ToListAsync();
        }
    }
}
