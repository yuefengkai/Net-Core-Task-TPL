using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TASK.DTO;
using TASK.IService;
using TASK.Service.Data;

namespace TASK.Service
{
    public class PersonService : IPersonService
    {
        private readonly MyDbContext context;
        public PersonService(MyDbContext myDbContext)
        {
            context = myDbContext;
        }

        public async Task<long> AddAsync(PersonDTO personDto)
        {
            Person person = new Person()
            {
                Name = personDto.Name,
                Age = personDto.Age
            };

            context.Persons.Add(person);

            var id = await context.SaveChangesAsync();

            return id;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var person = await context.Persons.FirstAsync(m => m.Id == id);

            if (person == null)
            {
                return false;
            }

            context.Entry(person).State = EntityState.Deleted;

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<PersonDTO>> GetAll(string where)
        {
            List<PersonDTO> list = new List<PersonDTO>();
            if (!await context.Persons.AnyAsync())
            {
                return list;
            }
            await context.Persons.Where(m => m.Age > 1).ForEachAsync(m =>
            {
                list.Add(new PersonDTO()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Age = m.Age
                });
            });

            return list;
        }

        public async Task<PersonDTO> GetPersonByIdAsync(long id)
        {
            var person = await context.Persons.FirstAsync(m => m.Id == id);

            PersonDTO personDto = new PersonDTO()
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age
            };
            return personDto;
        }

        public async Task<bool> UpdateAsync(PersonDTO personDto)
        {
            var person = await context.Persons.FirstAsync(m => m.Id == personDto.Id);

            person.Id = personDto.Id;
            person.Name = personDto.Name;
            person.Age = personDto.Age;

            context.Entry(person).State = EntityState.Modified;

            return await context.SaveChangesAsync() > 0;
        }
    }
}
