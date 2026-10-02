
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface ITweetService
    {
        List<TweetDto> GetTweets(Guid? userId);
        TweetDto? GetTweetById(Guid id);
        TweetDto? CreateTweet(CreateTweetDto request);
        TweetDto? UpdateTweet(Guid id, UpdateTweetDto request);
        bool DeleteTweet(Guid id);
    }
}
