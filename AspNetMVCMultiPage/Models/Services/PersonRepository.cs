using AspNetMVCMultiPage.Models.Aggreagates.DomainModels;
using AspNetMVCMultiPage.Models.FrameWorks.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspNetMVCMultiPage.Models.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ProjectDbContext _context;

        #region [-ctor-]
        public PersonRepository(ProjectDbContext context)
        {
            _context = context;
        }
        #endregion

        #region [-Select-]
        public async Task<List<Person>> Select()
        {
            using (_context)
            {
                try
                {
                    var p = await _context.Person.ToListAsync();
                    return p;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_context.Person != null) _context.Dispose();
                }
            }
        }
        #endregion

        #region [-Select by Id-]
        public async Task<Person> Select(Guid? id)
        {
            using (_context)
            {
                try
                {
                    var p = await _context.Person.FirstOrDefaultAsync(p => p.Id == id);
                    return p;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (_context.Person != null) _context.Dispose();
                }

            }
        }
        #endregion

        #region [-Insert-]
        public async Task Insert(Person person)
        {
            using (_context)
            {
                try
                {
                    var p = new Person()
                    {
                        Id = Guid.NewGuid(),
                        FName = person.FName,
                        LName = person.LName,
                    };

                    _context.Add(p);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_context.Person != null) _context.Dispose();
                }
            }
        }
        #endregion

        #region [-Update-]
        public async Task Update(Person person)
        {
            using (_context)
            {
                try
                {
                    var p = _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                finally
                {
                    if (_context.Person != null) _context.Dispose();
                }
            }
        }
        #endregion

        #region [-Delete-]
        public async Task Delete(Person person)
        {
            using (_context)
            {
                try
                {
                    var p = _context.Remove(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                finally
                {
                    if (_context.Person != null) _context.Dispose();
                }
            }
        } 
        #endregion
    }
}
