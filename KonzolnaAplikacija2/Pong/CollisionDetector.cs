using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class CollisionDetector
    {
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            
            if((horizontalOverlaps(a,b) || horizontalOverlaps(b, a)) &&(verticalOverlaps(a, b) || verticalOverlaps(b, a)))
            {
                return true;   
            }   
            return false;
        }
        //horizontal colide a is element with lower x value
        private static bool horizontalOverlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            if ((a.X + a.Width) >= b.X && a.X <= (b.X + b.Width))
            {
                return true;
            }
            return false;
        }
        private static bool verticalOverlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            if ((a.Y + a.Height) >= b.Y && a.Y <= (b.Y + b.Height))
            {
                return true;
            }
            return false;
        }
    }
}
