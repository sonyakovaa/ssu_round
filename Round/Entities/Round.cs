using System;
using System.Collections.Generic;
using System.Text;

namespace RoundProject.Entities
{
    [Serializable]
    public class Round
    {
        public int Id { get; set; }
        public Point A { get; set; }
        public int RADIUS { get; set; }

        public override String ToString()
        {
            return "ID - " + Id + ", centre - (" + A.X + ", " + A.Y + "), radius - " + RADIUS;
        }
        public double LengthCircle(int r)
        {
            return 2 * Math.PI * r;
        }

        public double SquareCircle(int r)
        {
            return Math.PI * r * r;
        }
    }
}
