using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace sof9
{
    public interface Figure
    {
        PointF Show();
        void Hide();
        void Move();
    }
}
