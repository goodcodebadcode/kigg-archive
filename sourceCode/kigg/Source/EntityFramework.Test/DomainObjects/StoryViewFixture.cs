using Xunit;

namespace Kigg.Infrastructure.EF.Test
{
    using Kigg.EF.DomainObjects;

    public class StoryViewFixture
    {
        private readonly StoryView _view;

        public StoryViewFixture()
        {
            _view = new StoryView();
        }

        [Fact]
        public void ForStory_Should_Return_The_Story()
        {
            _view.Story = new Story();

            Assert.Same(_view.ForStory, _view.Story);
        }

        [Fact]
        public void FromIpAddress_Should_Return_The_IpAddress()
        {
            _view.IpAddress = "192.168.0.1";

            Assert.Equal(_view.IpAddress, _view.FromIPAddress);
        }

        [Fact]
        public void ViewedAt_Should_Return_The_Timestamp()
        {
            _view.Timestamp = SystemTime.Now();

            Assert.Equal(_view.Timestamp, _view.ViewedAt);
        }
    }
}