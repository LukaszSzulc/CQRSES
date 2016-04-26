namespace CqrsTests
{
    using Xunit;
    public class CqrsTests : IClassFixture<RavenFixture>,IClassFixture<AutoFacFixture>
    {
        private readonly RavenFixture fixture;

        private readonly AutoFacFixture autoFacFixture;

        public CqrsTests (RavenFixture fixture, AutoFacFixture autoFacFixture)
        {
            this.fixture = fixture;
            this.autoFacFixture = autoFacFixture;
        }

        [Fact]
        public void Test()
        {
            
        }
    }
}
