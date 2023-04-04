namespace lab_03
{
    [Serializable]
    public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException() { }
        public RoomNotFoundException(string information = "\nКомната не найдена!\n") : base(information) { }
        public RoomNotFoundException(Exception inner, string information = "\nКомната не найдена!\n") : base(information, inner) { }
    }
    [Serializable]
    public class RoomExistsException : Exception
    {
        public RoomExistsException() { }
        public RoomExistsException(string information = "\nКомната уже существует!\n") : base(information) { }
        public RoomExistsException(Exception inner, string information = "\nКомната уже существует!\n") : base(information, inner) { }
    }
    [Serializable]
    public class DeleteRoomErrorException : Exception
    {
        public DeleteRoomErrorException() { }
        public DeleteRoomErrorException(string information = "\nНе удалось осуществить действие!\n") : base(information) { }
        public DeleteRoomErrorException(Exception inner, string information = "\nНе удалось осуществить действие!\n") : base(information, inner) { }
    }
    [Serializable]
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException() { }
        public StudentNotFoundException(string information = "\nСтудент не найден!\n") : base(information) { }
        public StudentNotFoundException(Exception inner, string information = "\nСтудент не найден!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddStudentErrorException : Exception
    {
        public AddStudentErrorException() { }
        public AddStudentErrorException(string information = "\nСтудента не удалось добавить!\n") : base(information) { }
        public AddStudentErrorException(Exception inner, string information = "\nСтудента не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class ChangeStudentGroupErrorException : Exception
    {
        public ChangeStudentGroupErrorException() { }
        public ChangeStudentGroupErrorException(string information = "\nСтудента не удалось добавить!\n") : base(information) { }
        public ChangeStudentGroupErrorException(Exception inner, string information = "\nСтудента не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class ChangeStudentNameErrorException : Exception
    {
        public ChangeStudentNameErrorException() { }
        public ChangeStudentNameErrorException(string information = "\nСтудента не удалось добавить!\n") : base(information) { }
        public ChangeStudentNameErrorException(Exception inner, string information = "\nСтудента не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class ThingNotFoundException : Exception
    {
        public ThingNotFoundException() { }
        public ThingNotFoundException(string information = "\nВещь не найдена!\n") : base(information) { }
        public ThingNotFoundException(Exception inner, string information = "\nВещь не найдена!\n") : base(information, inner) { }
    }
    [Serializable]
    public class CodeThingExistsException : Exception
    {
        public CodeThingExistsException() { }
        public CodeThingExistsException(string information = "\nКод вещи уже существует!\n") : base(information) { }
        public CodeThingExistsException(Exception inner, string information = "\nКод вещи уже существует!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddThingErrorException : Exception
    {
        public AddThingErrorException() { }
        public AddThingErrorException(string information = "\nВещь не удалось добавить!\n") : base(information) { }
        public AddThingErrorException(Exception inner, string information = "\nВещь не удалось добавить!\n") : base(information, inner) { }
    }
    [Serializable]
    public class ChangeRoomThingErrorException : Exception
    {
        public ChangeRoomThingErrorException() { }
        public ChangeRoomThingErrorException(string information = "\nНе удалось осуществить действие!\n") : base(information) { }
        public ChangeRoomThingErrorException(Exception inner, string information = "\nНе удалось осуществить действие!\n") : base(information, inner) { }
    }
    [Serializable]
    public class ThingNotInRoomException : Exception
    {
        public ThingNotInRoomException() { }
        public ThingNotInRoomException(string information = "\nВещь не находится в этой комнате!\n") : base(information) { }
        public ThingNotInRoomException(Exception inner, string information = "\nВещь не находится в этой комнате!\n") : base(information, inner) { }
    }
    [Serializable]
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() { }
        public UserNotFoundException(string information = "\nПользователь не найден!\n") : base(information) { }
        public UserNotFoundException(Exception inner, string information = "\nПользователь не найден!\n") : base(information, inner) { }
    }
    [Serializable]
    public class AddUserErrorException : Exception
    {
        public AddUserErrorException() { }
        public AddUserErrorException(string information = "Пользователя не удалось добавить!\n") : base(information) { }
        public AddUserErrorException(Exception inner, string information = "Пользователя не удалось добавить!\n") : base(information, inner) { }
    }
    public class UserExistsException : Exception
    {
        public UserExistsException() { }
        public UserExistsException(string information = "Пользователя уже существует\n") : base(information) { }
        public UserExistsException(Exception inner, string information = "Пользователя уже существует\n") : base(information, inner) { }
    }
}
