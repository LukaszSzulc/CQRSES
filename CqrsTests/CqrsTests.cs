namespace CqrsTests
{
    using Xunit;
    public class CqrsTests : IClassFixture<RavenFixture>
    {
        private readonly RavenFixture fixture;

        public CqrsTests (RavenFixture fixture)
        {
            this.fixture = fixture;
        }
    }
}
