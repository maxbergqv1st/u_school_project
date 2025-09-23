namespace App;

class Teacher : IUser
{
      public string Name;
      public string Username;
      string _password;

      public Teacher(string name, string username, string password)
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