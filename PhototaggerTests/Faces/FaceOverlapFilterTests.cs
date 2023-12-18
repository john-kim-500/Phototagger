using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Phototagger.Faces;
using System.Collections.Generic;
using System;

namespace PhototaggerTests.Faces
{
    [TestClass]
    public class FaceOverlapFilterTests
    {
        [TestMethod]
        public void Filter_WithRectangles_ReturnsEmpty()
        {
            // Configure
            List<Rectangle> rectangles = new List<Rectangle>();
            FaceOverlapFilter filter = new FaceOverlapFilter();

            // Act
            List<Rectangle> filtered = filter.Filter(rectangles);

            // Assert
            Assert.AreEqual(0, filtered.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Filter_WithRectangles_ThrowsArgumentNullException()
        {
            // Configure
            FaceOverlapFilter filter = new FaceOverlapFilter();

            // Act
            List<Rectangle> filtered = filter.Filter(null);

        }


        [TestMethod]
        public void Filter_WithNoOverlaps_ReturnsSameRectangles()
        {
            // Configure
            List<Rectangle> rectangles = new List<Rectangle>();
            rectangles.Add(new Rectangle(0, 0, 10, 10));
            rectangles.Add(new Rectangle(20, 20, 10, 10));
            FaceOverlapFilter filter = new FaceOverlapFilter();

            // Act
            List<Rectangle> filtered = filter.Filter(rectangles);

            // Assert
            Assert.AreEqual(rectangles.Count, filtered.Count);
            foreach (Rectangle rect in rectangles)
            {
                Assert.IsTrue(filtered.Contains(rect));
            }
        }

        [TestMethod]
        public void Filter_WithSmallerRectanglesInlarger_ReturnsLargestOnly()
        {
            // Configure
            List<Rectangle> rectangles = new List<Rectangle>();
            var large = new Rectangle(0, 0, 100, 100);
            rectangles.Add(large);
            rectangles.Add(new Rectangle(0, 0, 10, 10));
            rectangles.Add(new Rectangle(0, 0, 50, 50));
            rectangles.Add(new Rectangle(51, 51, 10, 10));
            FaceOverlapFilter filter = new FaceOverlapFilter();

            // Act
            List<Rectangle> filtered = filter.Filter(rectangles);

            // Assert
            Assert.AreEqual(1, filtered.Count);
            Assert.IsTrue(filtered.Contains(large));
        }

        [TestMethod]
        public void Filter_WithOverlappingRectangles_ReturnsLargestOnly()
        {
            // Configure
            List<Rectangle> rectangles = new List<Rectangle>();
            var largest = new Rectangle(0, 0, 100, 100);
            rectangles.Add(new Rectangle(20, 20, 95, 95));
            rectangles.Add(largest);
            rectangles.Add(new Rectangle(10, 10, 99, 99));

            FaceOverlapFilter filter = new FaceOverlapFilter();

            // Act
            List<Rectangle> filtered = filter.Filter(rectangles);

            // Assert
            Assert.AreEqual(1, filtered.Count);
            Assert.IsTrue(filtered.Contains(largest));
        }
    }
}
