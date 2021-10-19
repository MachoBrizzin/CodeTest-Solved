using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CodeTest.Models
{
    public class TestModel
    {

        /// <summary>
        /// The spacing between each shape.
        /// </summary>
        public double Spacing { get; set; }

        /// <summary>
        /// The kind of shape to fill this model with.
        /// </summary>
        public Shape Shape { get; set; }

        /// <summary>
        /// The "border" dimensions.
        /// </summary>
        public Size Rectangle { get; set; }


        public TestModel(double spacing, Shape shape, Size rectangle)
        {
            Spacing = spacing;
            Shape = shape;
            Rectangle = rectangle;
        }

    }
}
