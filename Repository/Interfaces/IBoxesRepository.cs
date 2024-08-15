using SmartBox.Model;

namespace SmartBox.Repositorios.Interfaces
{
    public interface IBoxesRepository
    {
    Task<List<BoxesModel>> GetAllBoxes();
    Task<BoxesModel> GetId(int id);
    Task<BoxesModel> Insert(BoxesModel boxes);
    Task<BoxesModel> Update(BoxesModel boxes, int id);
    Task<bool> Delete(int id);

    }
}
