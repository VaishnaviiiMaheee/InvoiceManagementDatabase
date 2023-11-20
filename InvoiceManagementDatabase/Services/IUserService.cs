using InvoiceManagementDatabase.Models;

namespace InvoiceManagementDatabase.Services
{
    public interface IUserService
    {
        List<User> Get();
        User Get(string id);
        User Create(User user);
        void Update(String id,User user);
        void Remove(String id);
    }
}
