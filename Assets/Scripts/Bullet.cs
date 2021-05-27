using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 5.0f;
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if(transform.position.y > 5.2f){
            Destroy(gameObject); 
        }
    }
}
