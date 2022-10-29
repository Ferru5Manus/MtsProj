using MySql.Data.MySqlClient;
using Dapper;
namespace Dance
{
    public class UserDatabaseRepository
    {
        public List<string> GetUserByEmail(User user)
        {
            List<string> lst = new List<string>();
            using (MySqlConnection cnx = new MySqlConnection("Server = 127.0.0.1; Database = dance; Uid = root; Pwd = root;"))
            {
                var result = cnx.Query<User>("select * from users where Email = @Email and PasswordS=@Password", new { user.Email,user.Password }).ToList();
                lst = result.Select(news => news.Name.ToString()).ToList();
            }


            return lst;
        }
    }
}
