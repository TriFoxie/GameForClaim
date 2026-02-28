using System;

namespace GameForClaim
{
    public interface IDamageCalculator
    {
        /// <summary>
        /// Get the damage calculator or instantiate a new one if none exists
        /// </summary>
        /// <returns>Singleton DamageCalculator Object</returns>
        IDamageCalculator GetInstance();

        /// <summary>
        /// Calculate the value of the damage caused
        /// and adjust the relative damage states of the parameter objects
        /// </summary>
        /// <remarks>
        /// The sum of the damage will be updated to reflect the financial losses after the damage. <br/>
        /// The states of the damaged objects will be updated to reflect new damage levels
        /// </remarks>
        /// <param name="component1">The object colliding with <paramref name="component2"/></param>
        /// <param name="component2">The object being collided into by <paramref name="component1"/></param>
        public void CalculateDamage(IDamagableComponent component1, IDamagableComponent component2);

        /// <summary>
        /// Returns the sum of all financial loss since last damage reset
        /// </summary>
        /// <returns>The value of damage</returns>
        public float GetValueOfCurrentDamage();

        /// <summary>
        /// The current sum of the finanical impact of damage will be reset. <br/>
        /// Damage is still retained on an object by object basis.
        /// </summary>
        public void ResetValues();
    }
    
}
