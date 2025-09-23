namespace App;

class CreateCourse
{
      
}

class Admin : IUser
{
      public string Name;
      public string Username;
      string _password;

      public Admin(string name, string username, string password)
      {
            Name = name;
            Username = username;
            _password = password;
      }

      public bool TryLogin(string username, string password)
      {
            return username == Username && password == _password;
      }
}