using EngineeringServices.DataAccess.EntityFramework.Context;
using EngineeringServices.DataAccess.Interfaces;
using EngineeringServices.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace EngineeringServices.DataAccess.EntityFramework.Repositories
{
    public class NoteRepository : BaseRepository<Note, EngineeringServicesDataContext>, INoteRepository
    {
        public async Task<Note> GetByIdAsync(int noteId, params string[] includeList)
        {
            return await GetAsync(note => note.Id == noteId, includeList);
        }
    }
}
