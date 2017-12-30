using ZoobySoft.CyclePlot.Analysis;
using Xunit;

namespace ZoobySoft.CyclePlot.AnalysisTest
{
    public class DistanceTests
    {
        public class DistanceInMetres
        {
            private Distance Distance;

            public DistanceInMetres()
            {
                Distance = Distance.ForMetres(1000);
            }


            [Fact]
            public void OneThousandMetres_ShouldReturnOneThousandMetres()
            {
                Assert.Equal(1000, Distance.GetMetres());
            }

            [Fact]
            public void OneThousandMetres_ShouldReturnOneKilometre()
            {
                Assert.Equal(1, Distance.GetKilometres());
            }

            [Fact]
            public void OneThousandMetres_ShouldReturnCorrectNumberOfMiles()
            {
                Assert.Equal(0.621, Distance.Miles, 3);
            }
        }

        public class DistanceInKilometres
        {
            private Distance Distance;

            public DistanceInKilometres()
            {
                Distance = Distance.ForKilometres(1);
            }


            [Fact]
            public void OneKilometre_ShouldReturnOneThousandMetres()
            {
                Assert.Equal(1000, Distance.GetMetres());
            }

            [Fact]
            public void OneKilometre_ShouldReturnOneKilometre()
            {
                Assert.Equal(1, Distance.GetKilometres());
            }

            [Fact]
            public void OneKilometre_ShouldReturnCorrectNumberOfMiles()
            {
                Assert.Equal(0.621, Distance.Miles, 3);
            }
        }

        public class DistanceInMiles
        {
            private Distance Distance;

            public DistanceInMiles()
            {
                Distance = Distance.ForMiles(1);
            }


            [Fact]
            public void OneMile_ShouldReturnCorrectNumberOfMetres()
            {
                Assert.Equal(1609, Distance.GetMetres(), 0);
            }

            [Fact]
            public void OneMile_ShouldReturnCorrectNumberOfKilometres()
            {
                Assert.Equal(1.609, Distance.GetKilometres(), 3);
            }

            [Fact]
            public void OneMile_ShouldReturnOneMile()
            {
                Assert.Equal(1, Distance.Miles);
            }
        }
    }
}
