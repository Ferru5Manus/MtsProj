

namespace Dance
{
    public class AuthManager
    {
        private UserDatabaseRepository _databaseRepository = new UserDatabaseRepository();
        public bool Login(string email, string pwd)
        {
            if (_databaseRepository.GetUserByEmail(new User() { Email=email,Password=pwd}).Count>0){
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
