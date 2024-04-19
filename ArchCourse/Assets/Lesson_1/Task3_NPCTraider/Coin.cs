using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Coin : MonoBehaviour
{

    private Transform currentTransform;
    private float speed = 3.0f;
    private float height = 2f;
    private int rotation = 1000;


    public void DestroyCoin()
    { 
    StartCoroutine(DestroyAnimation());
    }

IEnumerator DestroyAnimation()
    {
        currentTransform = this.gameObject.transform;
        var Finalheight = currentTransform.position.y + height;

        GetComponent<Collider>().enabled = false;
    while (transform.position.y < Finalheight)
        {
        transform.position += Vector3.up * Time.deltaTime * speed;
        transform.Rotate(Vector3.forward, rotation * Time.deltaTime);
        yield return null;
    }   
    Destroy(gameObject);
    }
}
