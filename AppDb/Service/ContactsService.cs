﻿using AppDb.Models;
using Microsoft.EntityFrameworkCore;

namespace AppDb.Service
{
    public class ContactsService : IContacts
    {
        private readonly AppDbContext _context;

        public ContactsService(AppDbContext context)
        {
            _context = context;
        }

        //This is a comment
        public void Create(Contacts contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Contacts.FirstOrDefaultAsync(n => n.Id == id);
            _context.Contacts.Remove(result);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Contacts>> GetAll()
        {
            var data = await _context.Contacts.ToListAsync();
            return data;

        }

        public async Task<Contacts> GetById(int id)
        {
           
                var result = await _context.Contacts.FirstOrDefaultAsync(n => n.Id == id);
                return result;
            
        }

        public async  Task<Contacts> Update(int id, Contacts contact)
        {
           await _context.Update(contact);
            _context.SaveChangesAsync();
            return contact;
        }

        Contacts IContacts.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
