using Microsoft.EntityFrameworkCore;
using SmartBox.DB;
using SmartBox.Model;
using SmartBox.Repositorios.Interfaces;

namespace SmartBox.Repositorios
{
    public class PackageRepository : IPackageRepository
    {
        private readonly SmartBoxDBContext _dbContext;

        public PackageRepository(SmartBoxDBContext smartBoxDBContext)
        {
            _dbContext = smartBoxDBContext;
        }

        public async Task<List<PackageModel>> GetAllPackage()
        {
            return await _dbContext.Packages.ToListAsync();
        }

        public async Task<PackageModel> GetId(int id)
        {
            return await _dbContext.Packages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Delete(int id)
        {
            PackageModel Package = await GetId(id);

            if (Package == null)
            {
                throw new Exception($"Pacote para o Id:{id} não encontrado.");
            }
                        
            _dbContext.Packages.Remove(Package);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PackageModel> Insert(PackageModel package)
        {
            await _dbContext.Packages.AddAsync(package);
            await _dbContext.SaveChangesAsync();

            return package;
        }

        public async Task<PackageModel> Update(PackageModel package, int id)
        {
            PackageModel PackageId = await GetId(id);

            if (PackageId == null)
            {
                throw new Exception($"Pacote para o Id:{id} não encontrado.");
            }

            PackageId.created_at = package.created_at;
            PackageId.custumerId = package.custumerId;
            PackageId.created_at = package.created_at;
            PackageId.picked_up_at = package.picked_up_at;
            PackageId.state = package.state;
            PackageId.delivered_at = package.delivered_at;
            PackageId.updated_at = package.updated_at;
            _dbContext.Packages.Update(PackageId);
            await _dbContext.SaveChangesAsync();
            return PackageId;
        }
    }
}
