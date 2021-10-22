using Microsoft.EntityFrameworkCore;
using Service;
using SpecnoRepository;
using SpecnoRepository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Specno_Assessment.Service
{
    public class RedditService: IRedditService
    {
        RedditDbContext _dbContext;
        public RedditService(RedditDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Post> GetPosts() 
        {
            _dbContext.Likes.ToList();
            _dbContext.Comments.ToList();
            return _dbContext.Posts.ToList();
        }

        public List<User> GetUsers() 
        {
            _dbContext.Posts.ToList();
            return _dbContext.Users.ToList();
        }

        public void Post(Post post) 
        {
            if (post != null) {               
                _dbContext.Posts.Add(post);
                _dbContext.SaveChangesAsync();
            }
        }

        public bool UpdatePost(Post postUpdate) 
        {
            if(postUpdate != null) 
            {
                var post =  _dbContext.Posts
                            .Where(x => x.PostId == postUpdate.PostId)
                            .AsNoTracking().FirstOrDefaultAsync();
                if (post != null)
                {
                    _dbContext.Update(postUpdate);
                    _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

        public bool DeletePost(Post post) 
        {
            var Dept = _dbContext.Posts.Where(x => x.PostId == post.PostId).FirstOrDefaultAsync();
            if (Dept != null)
            {
                _dbContext.Remove(Dept);
                _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public void GetPostsByUsername(string username) { }

        public void Comment(Comment comment)
        {
            if (comment != null)
            {
                _dbContext.Comments.Add(comment);
                _dbContext.SaveChangesAsync();
            }
        }

        public void Like(Like like)
        {
            if (like != null)
            {
                if(like.UpVote == like.DownVote) 
                {
                    like.UpVote = true;
                    like.DownVote = false;
                }
                _dbContext.Likes.Add(like);
                _dbContext.SaveChangesAsync();
            }
        }
    }
}
