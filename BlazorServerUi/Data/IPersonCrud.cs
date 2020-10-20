using BlazorServerUi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerUi.Data
{
    public interface IPersonCrud
    {
        Task InsertPerson(PersonModel personModel);
        Task<List<PersonModel>> LoadPeople();
    }
}