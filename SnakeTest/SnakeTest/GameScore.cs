using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class GameScore
    {
        private int pointCount;

        private DateTime timeStamp;

        public GameScore(int pointCount, DateTime timeStamp)
        {
            this.PointCount = pointCount;
            this.Timestamp = timeStamp;
        }

        public int PointCount
        {
            get
            {
                return this.pointCount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of the point count cannot be less than 0!");
                }

                this.pointCount = value;
            }
        }

        public DateTime Timestamp
        {
            get
            {
                return this.timeStamp;
            }

            set
            {
                if (value > DateTime.Now)
                {
                    throw new InvalidTimeZoneException("The given timestamp exists in the future!");
                }

                this.timeStamp = value;
            }
        }
    }
}
