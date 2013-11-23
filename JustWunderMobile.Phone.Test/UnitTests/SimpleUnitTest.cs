using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Phone.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JustWunderMobile.Phone.Test.UnitTests
{
    [TestClass]
    public class SimpleUnitTest : WorkItemTest
    {
        [Tag("SimpleTests")]
        [TestMethod]
        public void SimpleTest()
        {
            int a = 1;
            int b = 2;

            int c = a + b;

            Assert.IsTrue(c == 3);
        }

        [TestMethod]
        public void SimpleFailedTest()
        {
            int a = 1;
            int b = 2;

            int c = a + b;

            Assert.IsTrue(c == 3);
        }

        [TestMethod]
        [Asynchronous]
        public async void AsyncMethod()
        {
            var client = new WebClient();
            string s = await client.DownloadStringTaskAsync("http://www.emulroom.com");
            Assert.IsTrue(s.Length != 0);

            EnqueueTestComplete();
        }

        [TestMethod]
        [Asynchronous]
        public void AsyncEventMethod()
        {
            var client = new WebClient();
            client.DownloadStringCompleted += (sender, args) =>
            {
                Assert.IsTrue(!String.IsNullOrEmpty(args.Result.ToString()));
                EnqueueTestComplete();
            };

            client.DownloadStringAsync(new Uri("http://www.emulroom.com"));
        }

        [TestMethod]
        public async void ComplexTest()
        {
            var tcs = new TaskCompletionSource<string>();
            tcs.SetResult("done");

            var mock = new Mock<INetworkService>();
            mock.Setup(x => x.GetContent(It.IsAny<string>())).Returns(tcs.Task);

            var provider = new DataProvider(mock.Object);
            int length = await provider.GetLength("http://www.emulroom.com");

            Assert.IsTrue(length > 0);
        }
    }


    public interface INetworkService
    {
        Task<string> GetContent(string url);
    }

    public class NetworkService : INetworkService
    {
        public async Task<string> GetContent(string url)
        {
            var client = new WebClient();
            string content = await client.DownloadStringTaskAsync(new Uri("http://www.emulroom.com"));
            return content;
        }
    }

    public class DataProvider
    {
        private readonly INetworkService networkService;

        public DataProvider(INetworkService networkService)
        {
            this.networkService = networkService;
        }

        public async Task<int> GetLength(string url)
        {
            string content = await networkService.GetContent(url);
            return content.Length;
        }
    }
}
