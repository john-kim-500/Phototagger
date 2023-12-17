using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accordNetProject
{
    public interface IOverlapFilter
    {
        List<Rectangle> Filter(IEnumerable<Rectangle> faces);
    }
}
