using AppDemo.BL.Models;
using AppDemo.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.BL.Services
{
    public class PersonService
    {
        private readonly Context DbContext;

        public PersonService(Context DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<PersonModel>> GetAllPersonsAsync()
        {
            return await DbContext.Person.Select(
                s => new PersonModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    IdPersonType = s.IdPersonTypeNavigation.Id,
                    NamePersonType = s.IdPersonTypeNavigation.Name
                }
            ).ToListAsync();
        }

        public async Task<PersonModel> GetPersonByIdAsync(int personId)
        {
            return await DbContext.Person.Select(
                    s => new PersonModel
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        IdPersonType = s.IdPersonTypeNavigation.Id,
                        NamePersonType = s.IdPersonTypeNavigation.Name
                    })
                .FirstOrDefaultAsync(s => s.Id == personId);

        }

        public async Task<PersonModel> GetPersonByIdAndTypeAsync(int personId, int personTypeId)
        {
            return await DbContext.Person.Select(
                    s => new PersonModel
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        IdPersonType = s.IdPersonTypeNavigation.Id,
                        NamePersonType = s.IdPersonTypeNavigation.Name
                    })
                .FirstOrDefaultAsync(s => s.Id == personId & s.IdPersonType == personTypeId);
        }

        public async Task<List<PersonModel>> GetAllPersonsByTypeAsync(int personTypeId)
        {
            return await (
                from s in DbContext.Person
                where s.IdPersonTypeNavigation.Id == personTypeId
                select new PersonModel()
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    IdPersonType = s.IdPersonTypeNavigation.Id,
                    NamePersonType = s.IdPersonTypeNavigation.Name
                }).ToListAsync();
        }
    }
}