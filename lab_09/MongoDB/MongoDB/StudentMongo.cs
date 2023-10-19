using InterfaceDB;
using Models;
using MongoDB.Driver;

namespace MongoDB
{
	public class StudentMongo : IStudentDB
	{
		private string connectionString = "";
		private const string database = "PPO";
		private const string StudentCollection = "Students";
		private readonly IMongoCollection<Student> studentCollection;
		public StudentMongo(string connectionString)
		{
			this.connectionString = connectionString;
			var client = new MongoClient(connectionString);
			var db = client.GetDatabase(database);
			studentCollection = db.GetCollection<Student>(StudentCollection);
		}
		public List<Student> getAllStudent()
		{
			var projection = Builders<Student>.Projection.Exclude("_id");
			var all = studentCollection.Find(_ => true).Project(projection).ToList();
			List<Student> students = new List<Student>();
			foreach (var student in all)
				students.Add(new Student(student["Id_student"].ToInt32(), student["Name"].ToString(), student["Group"].ToString(), student["StudentCode"].ToString(), 
					student["Id_room"].ToInt32(), DateTime.Parse(student["DataIn"].ToString()), student["Id_user"].ToInt32()));
			return students;
		}
		public void addStudent(Student student)
		{
			student.Id_student = getAllStudent().Count + 1;
			studentCollection.InsertOne(student);
		}
		public int getIdStudentFromCode(string code)
		{
			var projection = Builders<Student>.Projection.Exclude("_id");
			var student = studentCollection.Find(s => s.StudentCode == code).Project(projection).ToList();
			return student[0]["Id_student"].ToInt32();
		}
		public void changeStudent(int id_student, Student newStudent)
		{
			studentCollection.ReplaceOne(n => n.Id_student == newStudent.Id_student, newStudent);
		}
		public Student getStudent(int id_student)
		{
			var projection = Builders<Student>.Projection.Exclude("_id");
			var student = studentCollection.Find(s => s.Id_student == id_student).Project(projection).ToList();
			Student result = new Student(student[0]["Id_student"].ToInt32(), student[0]["Name"].ToString(), student[0]["Group"].ToString(), student[0]["StudentCode"].ToString(),
				student[0]["Id_room"].ToInt32(), DateTime.Parse(student[0]["DataIn"].ToString()), student[0]["Id_user"].ToInt32());
			return result;
		}
		public void transferStudent(int id_student, int id_room)
		{
			var filter = Builders<Student>.Filter.Eq(s => s.Id_student, id_student);
			var update = Builders<Student>.Update.Set(s => s.Id_room, id_room);
			studentCollection.UpdateOne(filter, update);
		}
		public void deleteStudent(int id_student)
		{
			var filter = Builders<Student>.Filter.Eq(s => s.Id_student, id_student);
			studentCollection.DeleteOne(filter);
		}
		public void returnRoom(int id_student)
		{
			var filter = Builders<Student>.Filter.Eq(s => s.Id_student, id_student);
			var update = Builders<Student>.Update.Set(t => t.Id_room, -1);
			studentCollection.UpdateOne(filter, update);
		}
	}
}
