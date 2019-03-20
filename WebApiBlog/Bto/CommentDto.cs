using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.Bto
{
    public class CommentDto
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int ?PostId { get; set; }
        public string CommentImage { get; set; }
        public string CommentContent { get; set; }

    }
}