using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _characterConfig;
    [SerializeField] private CharacterView _characterView;
    [SerializeField] private GroundChecker _groundChecker;

    private PlayerInput _playerInput;
    private CharacterStateMachine _stateMachine;
    private CharacterController _characterController;

    // свойства для доступа к полям (на чтение)
    public PlayerInput PlayerInput => _playerInput;
    public CharacterController CharacterController => _characterController;
    public CharacterConfig CharacterConfig => _characterConfig;
    public CharacterView CharacterView => _characterView;
    public GroundChecker GroundChecker => _groundChecker;

    private void Awake()
    {
        _characterView.Initialize();
        _playerInput = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        _stateMachine.HandleInput(); // обработка ввода
        _stateMachine.Update(); // обновление состояния
    }

    private void OnEnable() => _playerInput.Enable();
    private void OnDisable() => _playerInput.Disable();
    
}
