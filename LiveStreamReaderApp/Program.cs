using System;
using LiveStreamReaderApp;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            IRedditApiClient redditApiClient = new RedditApiClient();
            StreamListener streamListener = new StreamListener(redditApiClient);
            // Subscribe to the UpdateReceived event
            streamListener.UpdateReceived += StreamListener_UpdateReceived;
            // Start listening to the live streaming thread
            string threadId = "w7xvfiywng54";
            streamListener.StartListeningToThread(threadId).Wait();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void StreamListener_UpdateReceived(object sender, string update)
        {
            Console.WriteLine($"New update received: {update}");
        }
    }
}
