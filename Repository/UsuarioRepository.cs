using Microsoft.EntityFrameworkCore;
using SmartBox.DB;
using SmartBox.Model;
using SmartBox.Repositorios.Interfaces;

namespace SmartBox.Repositorios
{
    public class UsuarioRepository : IUsuariosRepositorio
    {
        private readonly SmartBoxDBContext _dbContext;

        public UsuarioRepository(SmartBoxDBContext smartBoxDBContext)
        {
            _dbContext = smartBoxDBContext;
        }

        public async Task<List<UsuariosModel>> GetAllUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuariosModel> GetId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Delete(int id)
        {
            UsuariosModel Usuario = await GetId(id);

            if (Usuario == null)
            {
                throw new Exception($"Usuario para o Id:{id} não encontrado.");
            }
                        
            _dbContext.Usuarios.Remove(Usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        

        public async Task<UsuariosModel> Insert(UsuariosModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuariosModel> Update(UsuariosModel usuario, int id)
        {
            UsuariosModel UsuarioId = await GetId(id);

            if (UsuarioId == null)
            {
                throw new Exception($"Usuario para o Id:{id} não encontrado.");
            }

            UsuarioId.Email = usuario.Email;
            UsuarioId.Senha = usuario.Senha;
            UsuarioId.Telefone = usuario.Telefone;
            UsuarioId.Nome = usuario.Nome;
            _dbContext.Usuarios.Update(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }
    }
}
