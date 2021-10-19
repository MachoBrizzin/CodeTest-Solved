using CodeTest.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Define various shapes.
            Shape fiveUnitRectangle = CreateFiveUnitRectangle();
            Shape triangle = CreateTriangle();
            Shape fourUnitRectangle = CreateFourUnitRectangle();

            //  Create boundaries to contain these shapes.
            TestModel test1 = new TestModel(1, fiveUnitRectangle, new Size(50, 50));
            TestModel test2 = new TestModel(1, triangle, new Size(50, 50));
            TestModel test3 = new TestModel(1, fourUnitRectangle, new Size(26, 26));

            //  Store contents within first boundary.
            List<Shape> placedShapes1 = GetInsertedShapePositions(test1);


            //  Output
            Console.WriteLine("Test1: ");

            foreach (var shape in placedShapes1)
            {
                Console.WriteLine(shape.ToString());
            }


            Console.WriteLine();


            //  Store contents within second boundary.
            List<Shape> placedShapes2 = GetInsertedShapePositions(test2);

            Console.WriteLine("Test2: ");

            foreach (var shape in placedShapes2)
            {
                Console.WriteLine(shape.ToString());
            }


            Console.WriteLine();

            //  Store contents within third boundary.
            List<Shape> placedShapes3 = GetInsertedShapePositions(test3);

            Console.WriteLine("Test3: ");

            foreach (var shape in placedShapes3)
            {
                Console.WriteLine(shape.ToString());
            }


            Console.Read();
        }

        /// <summary>
        /// Determines where each part will fit on the given Rectangle (in testModel).
        /// </summary>
        /// <param name="test">The test to evaluate.</param>
        /// <returns>A list of complete shapes, each with where they should start.</returns>
        private static List<Shape> GetInsertedShapePositions(TestModel test)
        {
            //  We will insert a shape within the border via a while loop.
            //  The condition for said loop will be whether or not there exists room for a new shape.
            //  This is evaluated by taking the max index of the shape list and comparing its StartingPosition
            //  with the dimensions of the border.
            //  
            //  If the shape overlaps on the X axis, move it up the Y axis and reset the X position.
            //  If the shape overlaps on the Y, we have reached the top and should only process X axis.
            //  If the shape overlaps with both, then there is no room available.

            //  A shape's position is calculated by the previous shape's starting position plus the shape size, plus the spacing offset. 

            List<Shape> tempList = new List<Shape>();

            //  Loop until tempList is the size of the maximum point of both axes.
            /*for (bool room = false; tempList.Count <= test.Rectangle.Width || tempList.Count <= test.Rectangle.Height; room = RoomForNewShape(test, tempList))
            {
                //Console.WriteLine($"{tempList.Count} : {test.Rectangle.Width}");

                if (room)
                {
                    tempList.Add(CreateNewShape(test, new Point(tempList.Last().StartingPoint.X + test.Shape.Width + test.Spacing, 0)));
                }
                else
                    break;
            }*/

            while (RoomOnGrid(test, tempList))
            {
                /*var shape = CreateNewShape(test,
                    new Point(Y_Axis ? tempList.Last().StartingPoint.X : tempList.Last().StartingPoint.X + test.Shape.Width + test.Spacing,
                    Y_Axis ? tempList.Last().StartingPoint.Y + test.Shape.Height + test.Spacing : tempList.Last().StartingPoint.Y));
                tempList.Add(shape);*/

                //var shape = CreateNewShape(test, new Point(tempList.Last().StartingPoint.X + test.Shape.Width + test.Spacing, 0));

                //tempList.Add(CreateNewShape(test, tempList.Last()));

                //Console.WriteLine($"{shape.StartingPoint.ToString()}");
            }

            /*while (RoomOnY(test, tempList))
            {
                var shape = CreateNewShape(test, new Point(tempList.Last().StartingPoint.Y + test.Shape.Height + test.Spacing, 0));

                tempList.Add(shape);
            }*/

            return tempList;
        }


        /// <summary>
        /// Determines if there is sufficient room available on the grid to fit the desired shape.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shapes"></param>
        /// <param name="Y_Axis"></param>
        /// <returns></returns>
        private static bool RoomOnGrid(TestModel model, List<Shape> shapes)
        {
            //  Before we do anything, let's make certain that our list is valid.
            //  If not, create a new shape to start with.
            if (shapes.Count <= 0)
            {
                shapes.Add(CreateShapeInstance(model.Shape, new Point(0 + model.Spacing, 0 + model.Spacing)));
                return true;
            }

            //  If the list is valid, then move on to processing the next move.

            //  Calculate how many "spaces" that next move would use, then compare to the overall grid size.

            //  The amount of spaces needed to fit along the X axis.
            double SpacesNeededX = model.Shape.Width;

            //  The amount of spaces needed to fit along the Y axis.
            double SpacesNeededY = model.Shape.Height;

            //  The remaining amount of spaces along the X axis when subtracting the starting point of the last member of the collection.
            double RemainingSpacesX = model.Rectangle.Width - (shapes.Last().StartingPoint.X + shapes.Last().Width);

            //  The remaining amount of spaces along the Y axis when subtracting the starting point of the last member of the collection from the border height.
            double RemainingSpacesY = model.Rectangle.Height - (shapes.Last().StartingPoint.Y + shapes.Last().Height);

            //  Debug output.
            //Console.WriteLine($"There are {RemainingSlotsX} remaining spaces along the X axis. We need at least {SpacesNeededX} to fit another shape with spacing.");
            //Console.WriteLine($"There are {RemainingSlotsY} remaining spaces along the Y axis. We need at least {SpacesNeededY} to fit another shape with spacing.");

            //  Ensure there is sufficient space. If not, abort.

            bool IncrementYAxis = RemainingSpacesX < SpacesNeededX;

            //  Cancel if there are no spaces left.
            if (RemainingSpacesY < SpacesNeededY && RemainingSpacesX < SpacesNeededX)
            {
                return false;
            }

            //  Otherwise create the new shape.
            Shape NewShape = new Shape();
            Point NewPoint = new Point(0, 0);

            if (IncrementYAxis)
            {
                NewPoint.X = 0 + model.Spacing;
                NewPoint.Y = shapes.Last().StartingPoint.Y + shapes.Last().Height + model.Spacing;
                //Console.WriteLine("y axis.");
            }
            else
            {
                NewPoint.X = shapes.Last().StartingPoint.X + shapes.Last().Width + model.Spacing;
                NewPoint.Y = shapes.Last().StartingPoint.Y;
                //Console.WriteLine("x axis.");
            }

            NewShape.StartingPoint = NewPoint;
            NewShape.ShapePoints = model.Shape.ShapePoints;

            shapes.Add(NewShape);

            return true;

            /*//  Let's find out if we currently have room to fit another shape.

            //  Before we do anything, see if the list is empty. If so, create a new shape.
            if (shapes.Count <= 0)
            {
                shapes.Add(CreateNewShape(model, new Point(0, 0)));
                Y_Axis = false;
                return true;
            }

            //  First, cache a reference to the last shape within the shapes list.
            Shape FinalShape = shapes.Last();

            //  Now calculate the next assumed position along the X axis.
            double NextX = FinalShape.StartingPoint.X + FinalShape.Width + model.Spacing;

            //  Ensure there is sufficient room along the X axis.
            if ((NextX + FinalShape.Width) >= model.Rectangle.Width)
            {
                //Console.WriteLine("There is not enough space on the X axis for a new whole shape." +
                //    " Checking Y to see if we can shift upwards...");
                Y_Axis = false;
                return false;
            }
            else
            {
                Y_Axis = true;
                return true;
            }*/
        }

        /// <summary>
        /// Creates an instanced copy of the referenced shape.
        /// </summary>
        /// <param name="reference">The shape to reference.</param>
        private static Shape CreateShapeInstance(Shape reference)
        {
            //  Create the shape in memory.
            Shape NewShape = new Shape();

            //  Copy the data from the reference shape.
            NewShape.ShapePoints = reference.ShapePoints;

            //  Return the new shape.
            return NewShape;
        }

        /// <summary>
        /// Creates an instanced copy of the referenced shape with the specified starting point.
        /// </summary>
        /// <param name="reference">The shape to reference.</param>
        /// <param name="startingPoint">The point within the grid to start this shape.</param>
        private static Shape CreateShapeInstance(Shape reference, Point startingPoint)
        {
            //  Create the shape within memory.
            Shape NewShape = new Shape();

            //  Set the starting point to the specified argument.
            NewShape.StartingPoint = startingPoint;

            //  Copy the shape point data.
            NewShape.ShapePoints = reference.ShapePoints;

            //  Return the new shape.
            return NewShape;
        }

        private static Shape CreateFiveUnitRectangle()
        {
            Shape fiveUnitRectangle = new Shape();
            fiveUnitRectangle.ShapePoints.Add(new Point(0, 0));
            fiveUnitRectangle.ShapePoints.Add(new Point(0, 5));
            fiveUnitRectangle.ShapePoints.Add(new Point(5, 5));
            fiveUnitRectangle.ShapePoints.Add(new Point(5, 0));
            fiveUnitRectangle.ShapePoints.Add(new Point(0, 0));
            return fiveUnitRectangle;
        }

        private static Shape CreateTriangle()
        {
            Shape triangle = new Shape();
            triangle.ShapePoints.Add(new Point(0, 0));
            triangle.ShapePoints.Add(new Point(5, 5));
            triangle.ShapePoints.Add(new Point(10, 0));
            triangle.ShapePoints.Add(new Point(0, 0));
            return triangle;
        }

        private static Shape CreateFourUnitRectangle()
        {
            Shape fourUnitRectangle = new Shape();
            fourUnitRectangle.ShapePoints.Add(new Point(0, 0));
            fourUnitRectangle.ShapePoints.Add(new Point(0, 4));
            fourUnitRectangle.ShapePoints.Add(new Point(4, 4));
            fourUnitRectangle.ShapePoints.Add(new Point(4, 0));
            fourUnitRectangle.ShapePoints.Add(new Point(0, 0));
            return fourUnitRectangle;
        }
    }
}
