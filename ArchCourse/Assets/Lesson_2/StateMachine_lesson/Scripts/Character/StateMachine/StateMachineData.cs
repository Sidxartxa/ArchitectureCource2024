using System;

// в этом классе будут храниться единые данные по движению для всех стейтов
// во всех стейтах мы будем обращаться к этому классу чтобы получить актуальные данные по движению

public class StateMachineData
{

    // вектор скорости
    public float YVelocity;
    public float XVelocity;

    // модуль скорости. Не ниже 0.
    public float _speed;

    // входные данные которые нужно провалидировать в свойстве
    private float _xInput;

    public float XInput
    {
        get => _xInput;
        set
        {
            if (value > 1 && value < 1)
            { throw new ArgumentOutOfRangeException("XInput must be between -1 and 1"); }

            _xInput = value;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
            { throw new ArgumentOutOfRangeException("Speed must be greater than 0"); }

            _speed = value;
        }
    }
}
