using ZoobySoft.CyclePlot.Analysis;
using Xunit;

namespace ZoobySoft.CyclePlot.AnalysisTest
{
    public class SpeedTests
    {
        public class SpeedInMetresPerSecond
        {
            private Speed Speed;

            public SpeedInMetresPerSecond()
            {
                Speed = Speed.ForMetresPerSecond(10);
            }

            [Fact]
            public void TenMetresPerSecond_ShouldReturnTenMetresPerSecond()
            {
                Assert.Equal(10, Speed.GetMetresPerSecond());
            }

            [Fact]
            public void TenMetresPerSecond_ShouldReturnCorrectNumberOfKilometresPerHour()
            {
                Assert.Equal(36, Speed.GetKilometresPerHour());
            }

            [Fact]
            public void TenMetresPerSecond_ShouldReturnCorrectNumberOfMilesPerHour()
            {
                Assert.Equal(22.37, Speed.GetMilesPerHour(), 2);
            }
        }

        public class SpeedInKilometresPerHour
        {
            private Speed Speed;

            public SpeedInKilometresPerHour()
            {
                Speed = Speed.ForKilometresPerHour(100);
            }

            [Fact]
            public void OneHundredKilometresPerHour_ShouldReturnCorrectNumberOfMetresPerSecond()
            {
                Assert.Equal(27.78, Speed.GetMetresPerSecond(), 2);
            }

            [Fact]
            public void OneHundredKilometresPerHour_ShouldReturnOneHundredKilometresPerHour()
            {
                Assert.Equal(100, Speed.GetKilometresPerHour());
            }

            [Fact]
            public void OneHundredKilometresPerHour_ShouldReturnCorrectNumberOfMilesPerHour()
            {
                Assert.Equal(62.14, Speed.GetMilesPerHour(), 2);
            }
        }

        public class SpeedInMilesPerHour
        {
            private Speed Speed;

            public SpeedInMilesPerHour()
            {
                Speed = Speed.ForMilesPerHour(10);
            }

            [Fact]
            public void TenMilesPerHour_ShouldReturnCorrectNumberOfMetresPerSecond()
            {
                Assert.Equal(4.47, Speed.GetMetresPerSecond(), 3);
            }

            [Fact]
            public void TenMilesPerHour_ShouldReturnCorrectNumberOfKilometresPerHour()
            {
                Assert.Equal(16.09, Speed.GetKilometresPerHour(), 2);
            }

            [Fact]
            public void TenMilesPerHour_ShouldReturnTenMilesPerHour()
            {
                Assert.Equal(10, Speed.GetMilesPerHour());
            }
        }
    }
}
