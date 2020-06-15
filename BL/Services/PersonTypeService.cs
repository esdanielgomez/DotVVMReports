using AppDemo.BL.Models;
using AppDemo.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.BL.Services
{
    public class PersonTypeService
    {
        private readonly Context DbContext;

        public PersonTypeService(Context DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<PersonTypeModel>> GetAllPersonTypesAsync()
        {

            return await DbContext.Persontype.Select(
                s => new PersonTypeModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description
                }
            ).ToListAsync();
        }


        public async Task<PersonTypeModel> GetPersonTypeByIdAsync(int personTypeId)
        {
            return await DbContext.Persontype.Select(
                    s => new PersonTypeModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Description = s.Description
                    })
                .FirstOrDefaultAsync(s => s.Id == personTypeId);

        }
    }
}
