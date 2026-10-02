using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IUserRepository _userRepository;

        public TweetService(
            ITweetRepository tweetRepository,
            IUserRepository userRepository)
        {
            _tweetRepository = tweetRepository;
            _userRepository = userRepository;
        }

        public List<TweetDto> GetTweets(Guid? userId)
        {
            List<Tweet> tweets;

            if (userId.HasValue)
            {
                tweets = _tweetRepository.GetTweetsByUserId(userId.Value);
            }
            else
            {
                tweets = _tweetRepository.GetTweets();
            }

            var tweetDtos = tweets.Select(tweet => new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            }).ToList();

            return tweetDtos;
        }

        public TweetDto? GetTweetById(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return null;
            }

            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            };

            return tweetDto;
        }

        public TweetDto? CreateTweet(CreateTweetDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Content))
            {
                return null;
            }

            var user = _userRepository.GetUserById(request.UserId);

            if (user == null)
            {
                return null;
            }

            var tweet = new Tweet(request.Content)
            {
                UserId = request.UserId
            };

            _tweetRepository.AddTweet(tweet);

            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            };

            return tweetDto;
        }

        public TweetDto? UpdateTweet(Guid id, UpdateTweetDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Content))
            {
                return null;
            }

            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return null;
            }

            tweet.Content = request.Content;

            _tweetRepository.UpdateTweet(tweet);

            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            };

            return tweetDto;
        }

        public bool DeleteTweet(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return false;
            }

            return _tweetRepository.DeleteTweet(tweet);
        }
    }
}
