using LiveStreamReaderApp;

namespace LiveStreamReaderTests
{
    [TestFixture]
    public class RedditApiClientTests
    {
        private RedditApiClient _redditApiClient;

        [SetUp]
        public void SetUp()
        {
            _redditApiClient = new RedditApiClient();
        }

        [Test]
        public async Task GetLiveStreamingThread_ValidThreadId_ReturnsThreadData()
        {
            // Arrange
            string validThreadId = "w7xvfiywng54";

            // Act
            string threadData = await _redditApiClient.GetLiveStreamingThread(validThreadId);

            // Assert
            Assert.IsNotNull(threadData);
            Assert.IsNotEmpty(threadData);
        }

        [Test]
        public async Task GetLiveStreamingThread_InvalidThreadId_ReturnsNull()
        {
            // Arrange
            string invalidThreadId = "invalid_thread_id";

            // Act
            string threadData = await _redditApiClient.GetLiveStreamingThread(invalidThreadId);

            // Assert
            Assert.IsNull(threadData);
        }
    }
}
