

using CustomIdentity.Models;

namespace CustomIdentity.Service
{
    public interface IMaterialService
    {
        public Task<List<Material>> GetAll();
        public Task<Material> GetById(int id);
        public Task<int> Save(Material Material);
        public Task<Material> Update(int id, Material Material);
        public Task<List<Material>> DeleteById(int id);
    }
}
