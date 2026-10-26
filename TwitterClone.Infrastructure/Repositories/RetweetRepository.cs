using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class RetweetRepository : IRetweetRepository
    {
        private readonly TwitterCloneDbContext _context;

        public RetweetRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Retweet AddRetweet(Retweet retweet)
        {
            _context.Retweets.Add(retweet);
            _context.SaveChanges();

            return retweet;
        }

        public Retweet UpdateRetweet(Retweet retweet)
        {
            _context.Retweets.Update(retweet);
            _context.SaveChanges();

            return retweet;
        }

        public bool DeleteRetweet(Retweet retweet)
        {
            var existingRetweet = _context.Retweets
                .SingleOrDefault(r => r.Id == retweet.Id);

            if (existingRetweet is null)
                return false;

            _context.Retweets.Remove(existingRetweet);
            _context.SaveChanges();

            return true;
        }

        public int DeleteRetweetsByUserId(Guid userId)
        {
            var retweets = _context.Retweets
                .Where(r => r.UserId == userId)
                .ToList();

            if (retweets.Count == 0)
                return 0;

            _context.Retweets.RemoveRange(retweets);
            _context.SaveChanges();

            return retweets.Count;
        }

        public int DeleteRetweetsByTweetId(Guid tweetId)
        {
            var retweets = _context.Retweets
                .Where(r => r.TweetId == tweetId)
                .ToList();

            if (retweets.Count == 0)
                return 0;

            _context.Retweets.RemoveRange(retweets);
            _context.SaveChanges();

            return retweets.Count;
        }

        public Retweet? GetRetweetById(Guid id)
        {
            return _context.Retweets
                .SingleOrDefault(r => r.Id == id);
        }

        public List<Retweet> GetRetweets(Guid? userId, Guid? tweetId)
        {
            return _context.Retweets
                .Where(r =>
                    (userId == null || r.UserId == userId) &&
                    (tweetId == null || r.TweetId == tweetId))
                .ToList();
        }
    }
}
