public abstract class DamagableComponent
{
    private decimal _currentHealthLevel = 1;
    
    /// <summary>
    /// Get the original value of the component
    /// </summary>
    /// <returns>The undamaged value of the component</returns>
    public abstract float GetUndamagedValue();
    
    /// <summary>
    /// Get a decimal (positive or negative) representation of the motion of the object to the origin
    /// </summary>
    /// <returns>The motion of this object relative to the origin as a decimal</returns>
    public abstract decimal GetMovement();
    
    public decimal GetHealthLevel()
    {
        return _currentHealthLevel;
    }

    public void SetNewHealthLevel(decimal newHealthLevel)
    {
        _currentHealthLevel = newHealthLevel;
    }
}