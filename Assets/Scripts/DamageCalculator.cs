
public class DamageCalculator : IDamageCalculator
{
    private static DamageCalculator _instance;
    
    public IDamageCalculator GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DamageCalculator();
        }
        else
        {
            return _instance;
        }
    }

    private DamageCalculator()
    {
    }

    public void CalculateDamage(DamagableComponent component1, DamagableComponent component2)
    {
        throw new System.NotImplementedException();
    }

    public float GetValueOfCurrentDamage()
    {
        throw new System.NotImplementedException();
    }

    public void ResetValues()
    {
        throw new System.NotImplementedException();
    }
}