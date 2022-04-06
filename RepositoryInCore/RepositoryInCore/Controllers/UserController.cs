using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryInCore.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryInCore.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _imapper;
        public UserController(IMapper mapper)
        {
            _imapper = mapper;
        }
        public IActionResult Index()
        {
            var user = GetUserDetails();
            var UserView = _imapper.Map<UserViewModal>(user);
            return View(UserView);
        }
        private static Models.User GetUserDetails()
        {
            return new Models.User
            {
                id = 1,
                FirstName = "ASD",
                LastName = "XCV",
                Email = "asd@gmail.com"
            };
        }
    }
}
