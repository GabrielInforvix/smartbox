using SmartBox.Model;

namespace SmartBox.Repositorios.Interfaces
{
    public interface IPackageRepository
    {
    Task<List<PackageModel>> GetAllPackage();
    Task<PackageModel> GetId(int id);
    Task<PackageModel> Insert(PackageModel package);
    Task<PackageModel> Update(PackageModel package, int id);
    Task<bool> Delete(int id);

    }
}
