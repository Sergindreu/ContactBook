using AppDb.Models;

namespace AppDb.Service
{
    public interface IContacts
    {
        Task<IEnumerable<Contacts>> GetAll();
        void Create(Contacts contact);
        Task Delete(int id);
        Task<Contacts> Update(int id , Contacts contact);
        public Contacts GetById(int id);
    }
}
