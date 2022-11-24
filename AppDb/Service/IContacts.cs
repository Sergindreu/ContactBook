using AppDb.Models;

namespace AppDb.Service
{
    public interface IContacts
    {
        Task<IEnumerable<Contacts>> GetAll();
        void Create(Contacts contact);
        Task Delete(int id);
        public Contacts GetById(int id);
    }
}
