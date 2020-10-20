using BlazorServerUi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerUi.Data
{
    public interface IPersonCrud
    {
        Task InsertPerson(PersonModel personModel);
        Task<List<PersonModel>> LoadPeople();
        Task DeletePerson(Guid guid);
        Task UpdatePerson(PersonModel pm);
    }
}