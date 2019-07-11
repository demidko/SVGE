using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shapes
{
    class Line
    {
        private readonly Printer Print;
        public readonly Point From;
        public readonly Point To;

        public Line(in Printer tool, in Point a, in Point b)
        {
            Print = tool;
            From = a;
            To = b;
        }

        public void Show()
        {
            
        }
    }
}
