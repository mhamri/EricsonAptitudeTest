using Shouldly;
using Xunit;

namespace Ericson.AmriAnswers.Question2
{
    public class VectorTest
    {
        [Fact]
        public void VectorSumAgainstDirectionSameMagnitude()
        {
            //arrange
            var u = new Vector
            {
                Magnitude = 5,
                Degree = 180
            };
            var v = new Vector
            {
                Magnitude = 5,
                Degree = 0
            };

            //act
            var result = u + v;
            //assert
            result.Magnitude.ShouldBe(0);
            result.Degree.ShouldBe(180);
        }

        [Fact]
        public void VectorSumSameDirection()
        {
            //arrange
            var u = new Vector
            {
                Magnitude = 5,
                Degree = 0
            };
            var v = new Vector
            {
                Magnitude = 5,
                Degree = 0
            };

            //act
            var result = u + v;
            //assert
            result.Magnitude.ShouldBe(10);
            result.Degree.ShouldBe(0);
        }

        [Fact]
        public void VectorSumSameDirectionDifferentMagnitude()
        {
            //arrange
            var u = new Vector
            {
                Magnitude = 10,
                Degree = 0
            };
            var v = new Vector
            {
                Magnitude = 5,
                Degree = 0
            };

            //act
            var result = u + v;
            //assert
            result.Magnitude.ShouldBe(15);
            result.Degree.ShouldBe(0);
        }

        [Fact]
        public void VectorSumTipToToe()
        {
            //https://www.physicsclassroom.com/class/vectors/Lesson-1/Vector-Addition

            //arrange
            var u = new Vector
            {
                Magnitude = 20,
                Degree = 45
            };
            var v = new Vector
            {
                Magnitude = 25,
                Degree = 300
            };
            var z = new Vector
            {
                Magnitude = 15,
                Degree = 210
            };

            //act
            var result = u + v + z;
            //assert
            result.Magnitude.ShouldBe(20.36);
            result.Degree.ShouldBe(312);
        }

        [Fact]
        public void VectorSumTriangleExample1()
        {
            //https://www.physicsclassroom.com/class/vectors/Lesson-1/Vector-Addition

            //arrange
            var u = new Vector
            {
                Magnitude = 11,
                Degree = 90
            };
            var v = new Vector
            {
                Magnitude = 11,
                Degree = 0
            };

            //act
            var result = u + v;
            //assert
            result.Magnitude.ShouldBe(15.56);
            result.Degree.ShouldBe(45);
        }

        [Fact]
        public void VectorSumTriangleExample2()
        {
            //https://www.youtube.com/watch?v=8YsMNFWvgpk

            //arrange
            var u = new Vector
            {
                Magnitude = 12,
                Degree = 70
            };
            var v = new Vector
            {
                Magnitude = 21,
                Degree = 0
            };

            //act
            var result = u + v;
            //assert
            result.Magnitude.ShouldBe(27.52);
            result.Degree.ShouldBe(24);
        }
    }
}