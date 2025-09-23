namespace App;

class UploadFile
{
      public string StudentName { get; set; }
      public string FileName { get; set; }
      public string Grade { get; set; }
}

class Student : IUser
{
      public string Name;
      public string Username;
      string _password;
      public string ClassRoom;

      public Student(string name, string username, string password, string classroom)
      {
            Name = name;
            Username = username;
            _password = password;
            ClassRoom = classroom;
      }

      public bool TryLogin(string username, string password)
      {
            return username == Username && password == _password;
      }
}