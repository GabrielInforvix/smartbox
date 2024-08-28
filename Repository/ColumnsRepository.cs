using Microsoft.EntityFrameworkCore;
using SmartBox.DB;
using SmartBox.Model;
using SmartBox.Repositorios.Interfaces;

namespace SmartBox.Repositorios
{
    public class ColumnsRepository : IColumnsRepository
    {
        private readonly SmartBoxDBContext _dbContext;

        public ColumnsRepository(SmartBoxDBContext smartBoxDBContext)
        {
            _dbContext = smartBoxDBContext;
        }

        public async Task<List<ColumnsModel>> GetAllColumns()
        {
            return await _dbContext.Columns.ToListAsync();
        }

        public async Task<ColumnsModel> GetId(int id)
        {
            return await _dbContext.Columns.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Delete(int id)
        {
            ColumnsModel Column = await GetId(id);

            if (Column == null)
            {
                throw new Exception($"Coluna para o Id:{id} não encontrado.");
            }
                        
            _dbContext.Columns.Remove(Column);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ColumnsModel> Insert(ColumnsModel column)
        {
            await _dbContext.Columns.AddAsync(column);
            await _dbContext.SaveChangesAsync();

            return column;
        }

        public async Task<ColumnsModel> Update(ColumnsModel column, int id)
        {
            ColumnsModel ColumnId = await GetId(id);

            if (ColumnId == null)
            {
                throw new Exception($"Coluna para o Id:{id} não encontrada.");
            }

            ColumnId.created_at = column.created_at;
            ColumnId.pos = column.pos;  
            ColumnId.updated_at = column.updated_at;
            _dbContext.Columns.Update(ColumnId);
            await _dbContext.SaveChangesAsync();
            return ColumnId;
        }
    }
}
