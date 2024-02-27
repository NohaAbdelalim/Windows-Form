using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace try1
{
    public class RectangleWithText
    {
            public Rectangle Rectangle { get; set; }
            public string Text { get; set; }

            public RectangleWithText(Rectangle rectangle, string text)
            {
                Rectangle = rectangle;
                Text = text;
            }
    }
}
