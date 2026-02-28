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
            int speed =  CalculateRelativeSpeed(component1, component2);
        }

        public float GetValueOfCurrentDamage()
        {
            return _monetaryLoss;
        }

        public void ResetValues()
        {
            _damageCalculator = new DamageCalculator();
        }

        private int CalculateRelativeSpeed(IDamagableComponent component1, IDamagableComponent component2)
        {
            Vector2 motion1 = component1.GetMovement();
            Vector2 motion2 = component2.GetMovement();

            Vector2 relativeMotion = Vector2.Add(motion1, motion2);
        }
    }
}