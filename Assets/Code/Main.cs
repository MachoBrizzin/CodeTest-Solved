namespace CodeTest
{
    using UnityEngine;

    using System;
    using System.Linq;
    using System.Collections.Generic;

    using CodeTest.Models;

    /// <summary>
    /// This class manages the CodeTest application. "MonoBehaviour" is a class within Unity that allows for deep interaction with the engine.
    /// </summary>
    public class Main : MonoBehaviour
    {
        /// <summary>
        /// The default 3D material to use for the line renderers.
        /// </summary>
        public Material LineMaterial;

        public Transform Prefab5x5;
        public Transform Prefab4x4;
        public Transform PrefabTri;

        #region Initialization

        /// <summary>
        /// The Singleton instance of Main.
        /// </summary>
        public static Main Singleton;

        #endregion

        #region Startup



        #endregion

        #region Public Methods



        #endregion

        #region Private Methods

        /// <summary>
        /// Called by Unity during the first frame following initialization of this object.
        /// </summary>
        private void Start()
        {
            //  Set the static instance.

            Singleton = this;

            //  Process the shape tests.
            ProcessShapes();
        }

        /// <summary>
        /// This is our Main method in this example.
        /// </summary>
        private void ProcessShapes()
        {
            //  Create the shapes in memory.
            Shape fiveUnitRectangle = CreateFiveUnitRectangle();
            Shape triangle = CreateTriangle();
            Shape fourUnitRectangle = CreateFourUnitRectangle();

            //  Create the bounds to contain these shapes.
            TestModel test1 = new TestModel(1, fiveUnitRectangle, new Size(50, 50), "TestModel_1");
            //TestModel test2 = new TestModel(1, triangle, new Size(50, 50), "TestModel_2");
            //TestModel test3 = new TestModel(1, fourUnitRectangle, new Size(26, 26), "TestModel_3");

            //  Store the shapes within the first boundary.
            List<Shape> placedShapes1 = GetInsertedShapePositions(test1);

            Debug.Log("Test1: ");

            foreach (var shape in placedShapes1)
                Debug.Log(shape.ToString());

            //  Store the shapes within the second boundary.
            /*List<Shape> placedShapes2 = GetInsertedShapePositions(test2);

            Debug.Log("Test2: ");

            foreach (var shape in placedShapes2)
                Debug.Log(shape.ToString());

            //  Store the shapes within the third boundary.
            List<Shape> placedShapes3 = GetInsertedShapePositions(test3);

            Debug.Log("Test3: ");

            foreach (var shape in placedShapes3)
                Debug.Log(shape.ToString());*/
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Determines where each part will fit on the given Rectangle.
        /// </summary>
        /// <param name="model">The test to evaluate.</param>
        /// <returns>A list of complete shapes, each with where they should start.</returns>
        private static List<Shape> GetInsertedShapePositions(TestModel model)
        {
            //  Create the list that will hold all the shapes.
            List<Shape> result = new List<Shape>();

            //  Create new shapes as long as there is room available to do so.
            while (RoomOnGrid(model, result)) ;

            //  Return the result.
            return result;
        }

        /// <summary>
        /// Determines if there is sufficient room available on the grid to fit the desired shape.
        /// </summary>
        /// <param name="model">The test to evaluate within.</param>
        /// <param name="shapes">The list of shapes to add to and compare with.</param>
        /// <returns></returns>
        private static bool RoomOnGrid(TestModel model, List<Shape> shapes)
        {
            //  Before we do anything, ensure the list is valid.
            //  If not, create a new shape to start with.
            if (shapes.Count <= 0)
            {
                shapes.Add(CreateShapeInstance(model.Shape, new Point(0 + model.Spacing, 0 + model.Spacing)));
                return true;
            }

            //  If the list is valid, then move on and process the next shape.
            //  Calculate how many spaces that the next move will need, then compare that to the overall grid size.

            //  The amount of spaces needed to fit along the X axis.
            double SpacesNeededX = model.Shape.Width;

            //  The amount of spaces needed to fit along the Y axis.
            double SpacesNeededY = model.Shape.Height;

            //  The remaining amount of spaces along the X axis when subtracting the starting point of the last member of the collection.
            double RemainingSpacesX = model.Rectangle.Width - (shapes.Last().StartingPoint.X + shapes.Last().Width);

            //  The remaining amount of spaces along the Y axis when subtracting the starting point of the last member of the collection from the border height.
            double RemainingSpacesY = model.Rectangle.Height - (shapes.Last().StartingPoint.Y + shapes.Last().Height);

            //  True if there is no longer any room on the X axis and we need to try to shift up to the next row on the Y axis.
            bool IncrementYAxis = RemainingSpacesX < SpacesNeededX;

            //  Cancel if there are no spaces left.
            if (RemainingSpacesY < SpacesNeededY && RemainingSpacesX < SpacesNeededX)
            {
                return false;
            }

            //  Otherwise create the new shape.
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

            Shape NewShape = CreateShapeInstance(model.Shape, NewPoint);

            NewShape.StartingPoint = NewPoint;
            NewShape.ShapePoints = model.Shape.ShapePoints;

            shapes.Add(NewShape);

            return true;
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

            //  The following is exclusive to the Unity engine and visualizes the shapes with their spacing.

            GameObject shapeObj = Instantiate(Singleton.Prefab5x5, new Vector3((float)startingPoint.X, 0f, (float)startingPoint.Y), Quaternion.identity).gameObject;

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

        #endregion
    }
}