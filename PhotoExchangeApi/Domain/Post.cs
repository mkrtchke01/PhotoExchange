﻿
namespace Domain
{
    public class Post
    {
        public int PostId { get; set; }
        public string Photo { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        //public User User { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
