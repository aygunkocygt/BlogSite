using BlogSite.Bto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogSite.Controllers
{
    public class CommentController : ApiController
    {
        BlogSiteEntities db;
        public CommentController()
        {
            db = new BlogSiteEntities();
        }

        [HttpPost]
        public IHttpActionResult Add(Comment comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                return Json("Content cannot be empty!");
            }
            db.Comment.Add(comment);
            db.SaveChanges();
            return Json("Comment Added");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Comment deletedComment = db.Comment.Find(id);
                db.Comment.Remove(deletedComment);
                db.SaveChanges();
                return Json("Comment Deleted");
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(Comment comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                return Json("Content cannot be empty!");
            }
            Comment updatedComment = db.Comment.Find(comment.CommentID);
            updatedComment.Content = comment.Content;
            updatedComment.Image = comment.Image;
            db.SaveChanges();
            return Json("Updated Comment");
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Comment getComment = db.Comment.Find(id);
                if (getComment == null)
                {
                    return Json("Comment not found");
                }
                CommentDto c = new CommentDto();
                c.UserId = getComment.User.UserID;
                c.UserName = getComment.User.UserName;
                c.PostId = getComment.PostID;
                c.CommentContent = getComment.Content;
                c.CommentImage = getComment.Image;
                return Json(c);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllPassive()
        {
            try
            {
                List<CommentDto> comments = new List<CommentDto>();
                foreach (Comment item in db.Comment.Where(x => !x.Active.Value))
                {
                    CommentDto c = new CommentDto();
                    c.UserId = item.User.UserID;
                    c.UserName = item.User.UserName;
                    c.PostId = item.PostID;
                    c.CommentContent = item.Content;
                    c.CommentImage = item.Image;
                    comments.Add(c);
                }
                return Json(comments);
            }
           catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllByPost(int postId)
        {
            try
            {
                List<CommentDto> comments = new List<CommentDto>();
                foreach(Comment item in db.Comment.Where(x=>x.PostID == postId))
                {
                    CommentDto c = new CommentDto();
                    c.UserId = item.User.UserID;
                    c.UserName = item.User.UserName;
                    c.PostId = item.PostID;
                    c.CommentContent = item.Content;
                    c.CommentImage = item.Image;
                    comments.Add(c);
                }
                return Json(comments);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }



    }
}
