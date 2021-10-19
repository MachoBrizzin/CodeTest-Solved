namespace CodeTest.Models
{
    using UnityEngine;

    public class TestModel
    {
        /// <summary>
        /// The spacing between each shape.
        /// </summary>
        public double Spacing { get; set; }

        /// <summary>
        /// The shape definition to fill this model with.
        /// </summary>
        public Shape Shape { get; set; }

        /// <summary>
        /// The "border" dimensions.
        /// </summary>
        public Size Rectangle { get; set; }

        public TestModel(double spacing, Shape shape, Size rect, string Name)
        {
            Spacing = spacing;
            Shape = shape;
            Rectangle = rect;


            //  The following is unique to the visual representation within Unity.
            //  Each TestModel is drawn with a series of line renderers.

            //  Create a GameObject within the Unity scene to track this rectangle and its contents.
            GameObject Rect = new GameObject(Name);
            Rect.transform.position = Vector3.zero;


            //  Create a Line Renderer drawing from the origin upwards.
            LineRenderer Up = CreateLineRenderer(Vector3.zero, new Vector3(0f, 0f, (float)rect.Height), Rect);

            //  Create a Line Renderer drawing right across the top.
            LineRenderer Right = CreateLineRenderer(new Vector3(0f, 0f, (float)rect.Width), new Vector3((float)rect.Width, 0f, 0f), Rect);

            //  Create a Line Renderer drawing down from the top.
            LineRenderer Down = CreateLineRenderer(new Vector3((float)rect.Width, 0f, (float)rect.Height), new Vector3(0f, 0f, -(float)rect.Height), Rect);

            //  Create a Line Renderer drawing left from the bottom.
            LineRenderer Left = CreateLineRenderer(new Vector3((float)rect.Width, 0f, 0f), new Vector3(-(float)rect.Width, 0f, 0f), Rect);
        }

        private LineRenderer CreateLineRenderer(Vector3 position, Vector3 direction, GameObject Rectangle)
        {
            //  Create the line renderer object.
            GameObject LineObject = new GameObject("LineRenderer");

            //  Assign it as the child of this rectangle.
            LineObject.transform.SetParent(Rectangle.transform);

            //  Center its position.
            LineObject.transform.localPosition = position;

            //  Add the LineRenderer component.
            LineRenderer renderer = LineObject.AddComponent<LineRenderer>();

            //  Make the renderer use local space.
            renderer.useWorldSpace = false;

            //  Assign the 3D material.
            renderer.material = Main.Singleton.LineMaterial;

            //  Set line width.
            //renderer.startWidth = 0.1f;
            //renderer.endWidth = 0.1f;

            //  Assign the direction the renderer should point in.
            renderer.SetPosition(1, direction);

            return renderer;
        }
    }
}