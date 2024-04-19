using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2_preset : IShoot
    //в этом пресете стреляем одиночными пулями, но количество пуль не ограничено
{
    private Gun _gun;    

    public void Initialize(Gun _gun)
    {
        this._gun = _gun;        
    }

    public void Shoot(GameObject _shootPoint, GameObject _bulletPrefab)
    {
            GameObject bullet = GameObject.Instantiate(_bulletPrefab, _shootPoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000);
    }
}
