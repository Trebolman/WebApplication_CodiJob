using System;

namespace Application.DTOs
{
    public class UserDTO
    {
        public Guid UsuperId { get; set; }
        public string UsuperDesc { get; set; }
        public string UsuperGit { get; set; }
        public string UsuperBlog { get; set; }
        public string UsuperWeb { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
