using EarlySummer.BusinessModules.PetModules.Models;
using System.Collections.Generic;

namespace EarlySummer.BusinessModules.PetModules.Domains
{
    public interface IPetService
    {
        List<PetModel> GetPetList(string id);
    }
}
