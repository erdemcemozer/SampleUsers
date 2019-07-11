using SampleUsers.Models;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SampleUsers.Controllers
{
    public class UsersController : Controller
    {
        private static List<User> _users = new List<User>(){
            new User
            {
                Id = 1,
                Name = "Mahmoud",
                Surname = "Slama",
                IsChecked = true
            },
            new User
            {
                Id = 2,
                Name = "Oguz",
                Surname = "Taha",
                IsChecked = true
            }
        };
        // GET: Users
        public ActionResult Index()
        {
            return View(_users);
        }

        [HttpPost]
        public ActionResult AddNewUser(User user)
        {
            int id = 1;
            if (_users.Count > 0)
            {
                id = _users[_users.Count - 1].Id + 1;
            }

            Models.User newUser = new User()
            {
                Id = id,
                Name = user.Name,
                Surname = user.Surname,
                IsChecked = true
            };

            _users.Add(newUser);

            return View("Index", _users);
        }

        [HttpGet]
        public ActionResult DeleteById(int id)
        {
            _users.Remove(_users.Find(x => x.Id == id));
            return View("Index", _users);
        }
    }
}