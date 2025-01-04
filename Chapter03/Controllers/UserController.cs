using Chapter03.Models;
using Chapter03.Services;

namespace Chapter03.Controllers
{
    public class UserController

    {

        private readonly INotificationService _notificationService;


        public UserController(INotificationService notificationService)
        {

            _notificationService = notificationService;

        }

        public void UpdateUser(User user)
        {

            // Code to update the user 

            _notificationService.SendNotification("User updated");

        }

    }
}
