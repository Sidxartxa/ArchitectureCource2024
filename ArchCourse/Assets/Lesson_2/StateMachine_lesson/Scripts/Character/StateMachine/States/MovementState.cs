using UnityEngine;

//Это не конкретное состояние, а скорее базовый класс для всех состояний движения
// этот класс нельзя использовать сам по себе, он должен быть унаследован
public abstract class MovementState : IState
{

    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    private readonly Character _character; // ридонли - значит что переменная не может быть изменена после инициализации
    //чтобы никто случайно не занулил ссылку на персонажа
    
    private Quaternion TurnRight = new Quaternion(0, 0, 0, 0);
    private Quaternion TurnLeft = Quaternion.Euler(0, 180, 0);
    
    //конструктор
    public MovementState(IStateSwitcher stateSwitcher, StateMachineData stateMachineData, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = stateMachineData;
        _character = character;
    }

    protected PlayerInput PlayerInput => _character.PlayerInput;
    protected CharacterController CharacterController => _character.CharacterController;
    protected CharacterView CharacterView => _character.CharacterView;
    protected bool IsHorisontalInputZero() => Data.XInput == 0;

    public virtual void Enter()
    {
        Debug.Log(GetType()); // будет выводить экземпляр с названием класса в котором мы находимся
        AddInputActionsCallback();
        CharacterView.StartMovement();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallback();
        CharacterView.StopMovement();
    }

    public void HandleInput()
    {

        Data.XInput = ReadHorizontalInput();
        Data.XVelocity = Data.XInput * Data.Speed;
    }

    private float ReadHorizontalInput() => PlayerInput.Movement.Move.ReadValue<float>();

    //Делаем обновление виртуальным, чтобы можно было переопределить его в дочерних классах
    public virtual void Update()
    {
        Vector3 velocity = GetConvertedVelocity();
        CharacterController.Move(velocity * Time.deltaTime);
        //поворот
        _character.transform.rotation = GetRotationFrom(velocity);
    }

    //Методы для обработки событий ввода
    // их вызовы добавлены в Enter и Exit 
    //В тех стейтах где нам нужны подписки на события ввода, мы переопределяем эти методы
    protected virtual void AddInputActionsCallback() { } 
    protected virtual void RemoveInputActionsCallback() { }

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        if (velocity.x > 0)
            return TurnRight;
        if (velocity.x < 0)
            return TurnLeft;

        return _character.transform.rotation; // если стоим на месте
    }

    private Vector3 GetConvertedVelocity() => new Vector3(Data.XVelocity, Data.YVelocity, 0);

}
