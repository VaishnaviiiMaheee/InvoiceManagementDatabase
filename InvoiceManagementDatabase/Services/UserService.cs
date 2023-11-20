using InvoiceManagementDatabase.Models;
using MongoDB.Driver;
namespace InvoiceManagementDatabase.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IUserStoreDatabaseSettings settings,IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users=database.GetCollection<User>(settings.UserCollectionName);
        }
        public User Create(User user)
        {
            user.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            _users.InsertOne(user);
            return user;
        }

        public List<User> Get()
        {
            return _users.Find(user=>true).ToList();
        }

        public User Get(string id)
        {
          
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public void Update(string id, User user)
        {
             _users.ReplaceOne(user => user.Id == id, user);
        }
    }
}
