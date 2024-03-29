﻿
namespace PhotoExchangeApi.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
