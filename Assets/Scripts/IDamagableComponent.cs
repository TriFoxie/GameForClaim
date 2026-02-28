using System;

namespace GameForClaim
{
    public interface IDamagableComponent
    {
        /// <summary>
        /// Get the original value of the component
        /// </summary>
        /// <returns>The undamaged value of the component</returns>
        public float GetUndamagedValue();
    
        /// <summary>
        /// Get a decimal (positive or negative) representation of the motion of the object to the origin
        /// </summary>
        /// <returns>The motion of this object relative to the origin as a decimal</returns>
        public decimal GetMovement();

        /// <summary>
        /// Retrieve Health level, should be between 0 and 1
        /// </summary>
        /// <returns>Decimal between 0 and 1 representing the current level of health</returns>
        public decimal GetHealthLevel();

        /// <summary>
        /// Set Health level
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">When parameter not in [0,1] (inclusive)</exception>
        /// <returns>Decimal between 0 and 1 representing the current level of health</returns>
        public void SetNewHealthLevel(decimal newHealthLevel);
    }
}