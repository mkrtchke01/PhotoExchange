﻿

namespace PhotoExchangeApi.Domain
{
    public class Like
    {
        public int LikeId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
