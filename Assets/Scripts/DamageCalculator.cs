using System;
using System.Numerics;

namespace GameForClaim
{
    public class DamageCalculator : IDamageCalculator
    {
        private float _monetaryLoss;
        private static IDamageCalculator _damageCalculator;
        
        public static IDamageCalculator GetInstance()
        {
            if (_damageCalculator == null)
            {
                _damageCalculator = new DamageCalculator();
            }
            return _damageCalculator;
        }

        private DamageCalculator()
        {
            _monetaryLoss = 0f;
            _damageCalculator = this;
        }

        public void CalculateDamage(IDamagableComponent component1, IDamagableComponent component2)
        {
            // Calculate the current value (for future use to compare pre-post damage values
            float currentValue1 = CalculateCurrentObjectValue(component1);
            float currentValue2 = CalculateCurrentObjectValue(component2);
            
            // Calculate the damage factor which defines how both objects are affected
            float relativeSpeed =  CalculateRelativeSpeed(component1, component2);
            
            int damageFactor = (int) Math.Ceiling((relativeSpeed * relativeSpeed)/35);
            
            // Calculate the new health of the objects using the damage factor and vulnerability
            decimal damage1 = (component1.GetHealthLevel()) / (damageFactor * component1.GetVulnerability());
            decimal damage2 = (component2.GetHealthLevel()) / (damageFactor * component2.GetVulnerability());
            
            // Deal the damage
            component1.SetNewHealthLevel(component1.GetHealthLevel() - damage1);
            component2.SetNewHealthLevel(component2.GetHealthLevel() - damage2);
            
            // Calculate the difference in value for both objects and add it to the current finances
            _monetaryLoss += currentValue1 - CalculateCurrentObjectValue(component1);
            _monetaryLoss += currentValue1 - CalculateCurrentObjectValue(component2);
        }

        public float GetValueOfCurrentDamage()
        {
            return _monetaryLoss;
        }

        public void ResetValues()
        {
            _damageCalculator = new DamageCalculator();
        }

        /// <summary>
        /// Calculates the relative speed of two damagable components with vector motion
        /// </summary>
        /// <param name="component1">The first damagable component</param>
        /// <param name="component2">The second damagable component</param>
        /// <returns>Decimal representing the relative speed.</returns>
        private float CalculateRelativeSpeed(IDamagableComponent component1, IDamagableComponent component2)
        {
            Vector2 motion1 = component1.GetMovement();
            Vector2 motion2 = component2.GetMovement();

            Vector2 relativeMotion = Vector2.Subtract(motion1, motion2);
            return relativeMotion.Length();
        }

        private float CalculateCurrentObjectValue(IDamagableComponent component)
        {
            return component.GetUndamagedValue() * (float) component.GetHealthLevel();
        }
    }
}