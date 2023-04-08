using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;

namespace lab_04.Tests
{
    [TestClass()]
    public class UserDATests
    {
        [TestMethod()]
        public void getUserTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            UserDA userDA = new UserDA(args);
            UserServices userServices = new UserServices(userDA);

            User tmpUser = userServices.getUser(1);
            Assert.AreEqual(tmpUser.Id, 1);
            Assert.AreEqual(tmpUser.UserLevel, Levels.STUDENT);
        }
        [TestMethod()]
        public void getUserFailTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            UserDA userDA = new UserDA(args);
            UserServices userServices = new UserServices(userDA);

            Assert.ThrowsException<UserNotFoundException>(() => userServices.getUser(999));
        }
        [TestMethod()]
        public void getIdUserTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            UserDA userDA = new UserDA(args);
            UserServices userServices = new UserServices(userDA);

            int id = userServices.getIdUser("alex");
            Assert.AreEqual(id, 1);
        }
        [TestMethod()]
        public void getIdUserFailTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            UserDA userDA = new UserDA(args);
            UserServices userServices = new UserServices(userDA);

            Assert.ThrowsException<UserNotFoundException>(() => userServices.getIdUser("abc"));
        }
        [TestMethod()]
        public void addUserTest()
        {
            ConnectionArgs args = new ConnectionArgs("postgres", "localhost", "ppo", "0612", 5432);
            UserDA userDA = new UserDA(args);
            UserServices userServices = new UserServices(userDA);

            userServices.addUser("student", "student", Levels.STUDENT);

            NpgsqlCommand command = new NpgsqlCommand(userDA.getStrGetUser(2), userDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32(0);
            reader.Close();

            Assert.AreEqual(id, 2);
        }
    }
}