using BlogSite.Bto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogSite.Controllers
{
    public class UserController : ApiController
    {
        BlogSiteEntities db;

        public UserController()
        {
            db = new BlogSiteEntities();

        }

        [HttpPost]
        public IHttpActionResult Add(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                return Json<string>("Kullanıcı Adı boş geçilemez !");
            }
            db.User.Add(user);
            db.SaveChanges();
            return Json("User added");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                User deletedUser = db.User.Find(id);
                db.User.Remove(deletedUser);
                db.SaveChanges();
                return Json("Kullanıcı Silindi !");
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                return Json("User name cannot be empty!");
            }
            User updateUser = db.User.Find(user.UserName);
            updateUser.UserName = user.UserName;
            updateUser.Password = user.Password;
            updateUser.Name = user.Name;
            updateUser.Surname = user.Surname;

            db.SaveChanges();
            return Json("User Updated");

        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                User getUser = db.User.Find(id);
                if(getUser == null)
                {
                    return Json("User not found !");
                }
                UserDto u = new UserDto();
                u.Name = getUser.Name;
                u.Surname = getUser.Surname;
                u.Username = getUser.UserName;
                u.Email = getUser.Email;
                u.Password = getUser.Password;
                return Json(u);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<UserDto> users = new List<UserDto>();
                foreach (User item in db.User.ToList())
                {
                    UserDto u = new UserDto();
                    u.Name = item.Name;
                    u.Surname = item.Surname;
                    u.Username = item.UserName;
                    u.Email = item.Email;
                    u.Password = item.Password;
                    u.UserRole = item.UserRole.Name;
                    users.Add(u);  
                }
                return Json(users);
             }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IHttpActionResult GetUserByLogin(string mail,string password)
        {
            User u = db.User.Where(x => x.Email == mail && x.Password == password).SingleOrDefault();
            if(u == null)
            {
                return Json("Wrong email or password !");
            }
            UserDto uDto = new UserDto();
            uDto.Name = u.Name;
            uDto.Surname = u.Surname;
            uDto.Username = u.UserName;
            uDto.Email = u.Email;
            uDto.Password = u.Password;
            uDto.UserRole = u.UserRole.Name        ;
            return Json(uDto);


        }

    }
}
