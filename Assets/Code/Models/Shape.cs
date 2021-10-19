namespace CodeTest.Models
{
    using System.Linq;
    using System.Collections.Generic;

    public class Shape
    {
        public Point StartingPoint;

        public List<Point> ShapePoints { get; set; }

        public Shape() => ShapePoints = new List<Point>();

        public int Width => (int)ShapePoints.Max(item => item.X);
        public int Height => (int)ShapePoints.Max(item => item.Y);

        public override string ToString()
        {
            return $"{StartingPoint.X},{StartingPoint.Y}";
        }
    }
}