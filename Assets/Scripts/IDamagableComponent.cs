using System;
using System.Numerics;

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
        /// Get the vector 2 that represents this objects movement
        /// </summary>
        /// <returns>A vector 2 that represents this objects movement</returns>
        public Vector2 GetMovement();

        /// <summary>
        /// Retrieves the vulnerability of the damagable component, where an item with vunerability 1 is less
        /// resilient than one with vunerability 0.2
        /// </summary>
        /// <remarks>
        /// Must be between (0,1] (inclusive only for 1). 
        /// </remarks>
        /// <returns>Decimal in bound (0, 1]</returns>
        public decimal GetVunerability();

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