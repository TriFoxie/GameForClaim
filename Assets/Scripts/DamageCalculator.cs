using System;
using System.Numerics;

namespace GameForClaim
{
    public class DamageCalculator : IDamageCalculator
    {
        private float _monetaryLoss;
        private static IDamageCalculator _damageCalculator;
        
        public IDamageCalculator GetInstance()
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
            
            // Do damage
            float relativeSpeed =  CalculateRelativeSpeed(component1, component2);
            
            int damageFactor = (int) Math.Ceiling((relativeSpeed * relativeSpeed)/35);
            
            component1.SetNewHealthLevel(component1.GetHealthLevel() / damageFactor);
            component2.SetNewHealthLevel(component2.GetHealthLevel() / damageFactor);
            
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