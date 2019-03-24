namespace P02.Graphic_Editor
{
    using System;

    public class GraphicEditor
    {
        public string DrawShape(IShape shape)
        {
                return $"I'm {shape.GetType().Name}";
           
        }
    }
}
