using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phototagger
{
    public interface IOverlapFilter
    {
        List<Rectangle> Filter(IEnumerable<Rectangle> faces);
    }
}
