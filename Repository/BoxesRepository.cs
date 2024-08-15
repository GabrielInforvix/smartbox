using Microsoft.EntityFrameworkCore;
using SmartBox.DB;
using SmartBox.Model;
using SmartBox.Repositorios.Interfaces;

namespace SmartBox.Repositorios
{
    public class BoxesRepository : IBoxesRepository
    {
        private readonly SmartBoxDBContext _dbContext;

        public BoxesRepository(SmartBoxDBContext smartBoxDBContext)
        {
            _dbContext = smartBoxDBContext;
        }

        public async Task<List<BoxesModel>> GetAllBoxes()
        {
            return await _dbContext.Boxes.ToListAsync();
        }

        public async Task<BoxesModel> GetId(int id)
        {
            return await _dbContext.Boxes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Delete(int id)
        {
            BoxesModel Boxes = await GetId(id);

            if (Boxes == null)
            {
                throw new Exception($"O armario para o Id:{id} não encontrado.");
            }
                        
            _dbContext.Boxes.Remove(Boxes);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        

        public async Task<BoxesModel> Insert(BoxesModel boxes)
        {
            await _dbContext.Boxes.AddAsync(boxes);
            await _dbContext.SaveChangesAsync();

            return boxes;
        }

        public async Task<BoxesModel> Update(BoxesModel box, int id)
        {
            BoxesModel BoxId = await GetId(id);

            if (BoxId == null)
            {
                throw new Exception($"Box para o Id:{id} não encontrado.");
            }

            BoxId.Id = box.Id;
            BoxId.external_id = box.external_id;
            BoxId.created_at = box.created_at;
            BoxId.updated_at = box.updated_at;
            _dbContext.Boxes.Update(BoxId);
            await _dbContext.SaveChangesAsync();
            return BoxId;
        }
    }
}
