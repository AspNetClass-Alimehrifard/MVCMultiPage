using AspNetMVCMultiPage.Models.Aggreagates.DomainModels;

namespace AspNetMVCMultiPage.Models.FrameWorks.Contracts
{
    public interface IPersonRepository
    {
        Task<List<Person>> Select();
        Task<Person> Select(Guid? id);
        Task Insert(Person person);
        Task Update(Person person);
        Task Delete(Person person);
    }
}
