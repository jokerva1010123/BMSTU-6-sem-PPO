using InterfaceDB;
using Models;
using MongoDB.Driver;

namespace MongoDB
{
	public class UserMongo : IUserDB
	{
		private string connectionString = "";
		private const string database = "PPO";
		private const string UserCollection = "Users";
		private readonly IMongoCollection<User> userCollection;	

		public UserMongo(string connectionString) 
		{
			this.connectionString = connectionString;
			var client = new MongoClient(this.connectionString);
			var db = client.GetDatabase(database);
			userCollection = db.GetCollection<User>(UserCollection);
		}

		public int getIdUser(string login)
		{
			User user = userCollection.AsQueryable().Where(u => u.Login == login).FirstOrDefault();
			if (user == null)
				return -1;
			return user.Id;
		}

		public User getUser(int id)
		{
			return userCollection.AsQueryable().Where(u => u.Id == id).FirstOrDefault();
		}
		
		public List<User> getAllUsers()
		{
			return userCollection.Find(_ => true).ToList();
		}

		public void addUser(string login, string password, Levels level)
		{
			int id = getAllUsers().Count + 1;
			User user = new User(id, login, password, level);
			userCollection.InsertOne(user);
		}
	}
}
