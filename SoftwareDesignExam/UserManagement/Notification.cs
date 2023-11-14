using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SoftwareDesignExam.UserManagement
{
    public class Notification
    {
        private string _id;
        private string _message;
        private User _user;

        public Notification(string id, string message, User user)
        {
            _id = id;
            _message = message;
            _user = user;
        }

        public void Send()
        {
            Console.WriteLine($"Notification for {_user.Username}: {_message}");
        }
    }

    
}
