namespace CodeTest.Models
{
    [System.Serializable]
    public class Size
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Size(double w, double h)
        {
            Width = w;
            Height = h;
        }
    }
}