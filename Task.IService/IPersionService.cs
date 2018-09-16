using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TASK.DTO;

namespace TASK.IService
{
    public interface IPersonService
    {
        Task<long> AddAsync(PersonDTO personDto);

        Task<bool> UpdateAsync(PersonDTO personDto);

        Task<PersonDTO> GetPersonByIdAsync(long id);

        Task<bool> DeleteAsync(long id);

        Task<IEnumerable<PersonDTO>> GetAll(string where);
    }
}
