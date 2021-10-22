using SpecnoRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IRedditService
    {
        List<Post> GetPosts();
        List<User> GetUsers();
        void Post(Post post);
        bool UpdatePost(Post post);
        bool DeletePost(Post post);
        void Comment(Comment comment);
        void Like(Like like);
    }
}
