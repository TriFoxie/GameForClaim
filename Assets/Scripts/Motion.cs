using System;
using Unity.VisualScripting;

namespace GameForClaim
{
    public struct Motion
    {
        /// <summary>
        /// The speed of the object in miles per hour
        /// </summary>
        private int Speed { get; set; }

        /// <summary>
        /// The direction in degrees relative to the north of the origin. <br/>
        /// Please ensure the angle is relative to a fixed origin and not the direction of travel of the object
        /// (as this would clearly be self-defeating).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Set only to values [0, 360]</exception>
        public int Direction
        {
            get => this.Direction;

            set
            {
                if (value < 0 || value > 360) throw new ArgumentOutOfRangeException(nameof(value), 
                    "New direction must be between 0 and 360 degrees. Please see documentation.");
                this.Direction = value;
            }
        }
    }
}