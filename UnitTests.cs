using NUnit.Framework;
using ShapeLibrary;

namespace ShapeLibraryTests
{
    public class ShapeCalculatorTests
    {
        [Test]
        public void CalculateCircleArea_ValidRadius_ReturnsCorrectArea()
        {
            ShapeCalculator calculator = new ShapeCalculator();
            double radius = 5;
            double expectedArea = 78.53981633974483;
            double actualArea = calculator.CalculateCircleArea(radius);
            Assert.AreEqual(expectedArea, actualArea);
        }

        [Test]
        public void CalculateTriangleArea_ValidSides_ReturnsCorrectArea()
        {
            ShapeCalculator calculator = new ShapeCalculator();
            double side1 = 3;
            double side2 = 4;
            double side3 = 5;
            double expectedArea = 6; 
            double actualArea = calculator.CalculateTriangleArea(side1, side2, side3);
            Assert.AreEqual(expectedArea, actualArea);
        }

        [Test]
        public void IsRightAngleTriangle_RightTriangle_ReturnsTrue()
        {
            ShapeCalculator calculator = new ShapeCalculator();
            double side1 = 3;
            double side2 = 4;
            double side3 = 5;
            bool isRightAngleTriangle = calculator.IsRightAngleTriangle(side1, side2, side3);
            Assert.IsTrue(isRightAngleTriangle);
        }
    }
}
