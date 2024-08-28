using SmartBox.Model;

namespace SmartBox.Repositorios.Interfaces
{
    public interface IColumnsRepository
    {
    Task<List<ColumnsModel>> GetAllColumns();
    Task<ColumnsModel> GetId(int id);
    Task<ColumnsModel> Insert(ColumnsModel columns);
    Task<ColumnsModel> Update(ColumnsModel columns, int id);
    Task<bool> Delete(int id);

    }
}
