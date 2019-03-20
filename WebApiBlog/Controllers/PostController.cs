using BlogSite.Bto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogSite.Controllers
{
    public class PostController : ApiController
    {
        BlogSiteEntities db;

        public PostController()
        {
            db = new BlogSiteEntities();
        }

        [HttpPost]
        public IHttpActionResult Add(Post post)
        {
            if(string.IsNullOrWhiteSpace(post.Content))
            {
                return Json("Post Content cannot be empty");
            }
            db.Post.Add(post);
            db.SaveChanges();

            return Json("Post Added");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Post deletedPost = db.Post.Find(id);
                db.Post.Remove(deletedPost);
                db.SaveChanges();
                return Json("Post deleted");
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(Post post)
        {
            if(string.IsNullOrWhiteSpace(post.Content))
            {
                return Json("Post content cannot be empty");
            }
            Post updatedPost = db.Post.Find(post.PostID);
            updatedPost.Content = post.Content;
            updatedPost.Image = post.Image;
            db.SaveChanges();
            return Json("Post Updated");
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Post getPost = db.Post.Find(id);
                if (getPost == null)
                {
                    return Json("Post not found");
                }
                PostDto p = new PostDto();
                p.City = getPost.City.CityName;
                p.Content = getPost.Content;
                p.Image = getPost.Image;
                return Json(p);
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
                List<PostDto> posts = new List<PostDto>();
                foreach (Post item in db.Post)
                {
                    PostDto p = new PostDto();
                    p.City = item.City.CityName;
                    p.Content = item.Content;
                    p.Image = item.Image;
                    posts.Add(p);
                }
                return Json(posts);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
           
        }


    }
}
