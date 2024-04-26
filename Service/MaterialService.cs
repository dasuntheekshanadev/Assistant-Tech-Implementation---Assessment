using CustomIdentity.Data;
using CustomIdentity.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentity.Service
{
    public class MaterialService : IMaterialService
    {
        private readonly AppDbContext dbContext;

        public MaterialService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Material>> DeleteById(int id)
        {
            var Material = await dbContext.Materials
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (Material is not null)
            {
                Material.IsActive = false;
                dbContext.Materials.Update(Material);
                await dbContext.SaveChangesAsync();
            }
            return await GetAll();

        }

        public async Task<List<Material>> GetAll()
        {
            var Materials = await dbContext.Materials.Where(x => x.IsActive).ToListAsync();
            return Materials;
        }

        public async Task<Material> GetById(int id)
        {
            var Material = await dbContext.Materials.FindAsync(id);
            return Material;
        }

        public async Task<int> Save(Material Material)
        {
             await dbContext.Materials.AddAsync(Material);
            var result = await dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<Material> Update(int id ,Material Material)
        {
            var result = await dbContext.Materials.FindAsync(id);
            result.Description = Material.Description;
            result.UnitPrice = Material.UnitPrice;
            result.Name = Material.Name;
            result.Supplier = Material.Supplier;
            result.Quantity = Material.Quantity;

            dbContext.Update(result);
            var effect = await dbContext.SaveChangesAsync();
            return result;
        }
    }
}
