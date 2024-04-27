using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField , Range(0.01f,1)] private float _distanceToCheck;

    public bool IsTouches { get; private set; }
    
    private void Update()
    {
        //Вешаем этот компонент на объект, который должен проверять касается ли он земли        
        IsTouches = Physics.CheckSphere(transform.position, _distanceToCheck, _ground);
    }
}
