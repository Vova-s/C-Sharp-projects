using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableTask
{
    public class User
    {
        public string username;
        public long password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = GetHashForPassword(password);
        }

        public long GetHashForPassword(string password)
        {
            long code = 0;
            for (int i = 0; i < password.Length; i++)
                code += password[i];
            return code;
        }

        public override bool Equals(object obj) => ((User)obj).password == password && ((User)obj).username == username;
    }

    public class UserData
    {
        public string email;
        public DateTime bd;

        public UserData(string email, DateTime birthDate)
        {
            this.email = email;
            this.bd = birthDate;
        }
    }

    public class AgeGroup
    {
        public string ageCategory;
        public static string[] categories = { "18 - 25", "26 - 35", "35 - 50", "50+" };

        public AgeGroup(int category)
        {
            this.ageCategory = categories[category];
        }

        public override bool Equals(object obj) => ((AgeGroup)obj).ageCategory == ageCategory;
    }

    public class UserList
    {
        public List<string> usernames = new List<string>();

        public UserList(List<string> usernames)
        {
            this.usernames = usernames;
        }
    }
}
