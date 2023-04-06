using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04
{
    [Serializable]
    public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException(string information = "\nКомната не найдена!\n") : base(information) { }
        public RoomNotFoundException(Exception inner, string information = "\nКомната не найдена!\n") : base(information, inner) { }
    }
    [Serializable]
    public class RoomExistsException : Exception
    {
        public RoomExistsException(string information = "\nКомната уже существует!\n") : base(information) { }
        public RoomExistsException(Exception inner, string information = "\nКомната уже существует!\n") : base(information, inner) { }
    }
    [Serializable]
    public class DeleteRoomErrorException : Exception
    {
        public DeleteRoomErrorException(string information = "\nНе удалось осуществить действие!\n") : base(information) { }
        public DeleteRoomErrorException(Exception inner, string information = "\nНе удалось осуществить действие!\n") : base(information, inner) { }
    }
    [Serializable]
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string information = "\nСтудент не найден!\n") : base(information) { }
        public StudentNotFoundException(Exception inner, string information = "\nСтудент не найден!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddStudentErrorException : Exception
    {
        public AddStudentErrorException(string information = "\nСтудента не удалось добавить!\n") : base(information) { }
        public AddStudentErrorException(Exception inner, string information = "\nСтудента не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class ChangeStudentGroupErrorException : Exception
    {
        public ChangeStudentGroupErrorException(string information = "\nСтудента не удалось добавить!\n") : base(information) { }
        public ChangeStudentGroupErrorException(Exception inner, string information = "\nСтудента не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class ChangeStudentNameErrorException : Exception
    {
        public ChangeStudentNameErrorException(string information = "\nСтудента не удалось добавить!\n") : base(information) { }
        public ChangeStudentNameErrorException(Exception inner, string information = "\nСтудента не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class ThingNotFoundException : Exception
    {
        public ThingNotFoundException(string information = "\nВещь не найдена!\n") : base(information) { }
        public ThingNotFoundException(Exception inner, string information = "\nВещь не найдена!\n") : base(information, inner) { }
    }
    [Serializable]
    public class CodeThingExistsException : Exception
    {
        public CodeThingExistsException(string information = "\nКод вещи уже существует!\n") : base(information) { }
        public CodeThingExistsException(Exception inner, string information = "\nКод вещи уже существует!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddThingErrorException : Exception
    {
        public AddThingErrorException(string information = "\nВещь не удалось добавить!\n") : base(information) { }
        public AddThingErrorException(Exception inner, string information = "\nВещь не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class ChangeRoomThingErrorException : Exception
    {
        public ChangeRoomThingErrorException(string information = "\nНе удалось осуществить действие!\n") : base(information) { }
        public ChangeRoomThingErrorException(Exception inner, string information = "\nНе удалось осуществить действие!\n") : base(information, inner) { }
    }
    [Serializable]
    public class ThingNotInRoomException : Exception
    {
        public ThingNotInRoomException(string information = "\nВещь не находится в этой комнате!\n") : base(information) { }
        public ThingNotInRoomException(Exception inner, string information = "\nВещь не находится в этой комнате!\n") : base(information, inner) { }
    }
    [Serializable]
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string information = "\nПользователь не найден!\n") : base(information) { }
        public UserNotFoundException(Exception inner, string information = "\nПользователь не найден!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddUserErrorException : Exception
    {
        public AddUserErrorException(string information = "Пользователя не удалось добавить!\n") : base(information) { }
        public AddUserErrorException(Exception inner, string information = "Пользователя не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class UserExistsException : Exception
    {
        public UserExistsException(string information = "Пользователя уже существует\n") : base(information) { }
        public UserExistsException(Exception inner, string information = "Пользователя уже существует\n") : base(information, inner) { }
    }
    [Serializable]
    public class DataBaseConnectException : Exception
    {
        public DataBaseConnectException(string information = "Не получилось подключиться к Базе данных!\n") : base(information) { }
        public DataBaseConnectException(Exception inner, string information = "Не получилось подключиться к Базе данных!\n") : base(information, inner) { }
    }
    [Serializable]
    public class DataBaseRunErrorException : Exception
    {
        public DataBaseRunErrorException(string information = "Ошибка в БД\n") : base(information) { }
        public DataBaseRunErrorException(Exception inner, string information = "Ошибка в БД\n") : base(information, inner) { }
    }
}
