using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate = 0.4f;
    private float _canFire = -0.5f;

    void Start()
    {
        transform.position = new Vector3(0, -4, 0);
    }

    void Update()
    {
        CalculateMovement();

        if(Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }

    }


    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);

        if(transform.position.y >= -0.5f)
        {
            transform.position = new Vector3(transform.position.x, -0.5f, 0);
        }
        else if(transform.position.y <= -4.3f)
        {
            transform.position = new Vector3(transform.position.x, -4.3f, 0);
        }

        if(transform.position.x <= -2.1f)
        {
            transform.position = new Vector3(-2.1f, transform.position.y, 0);
        }
        else if(transform.position.x >= 2.1f)
        {
            transform.position = new Vector3(2.1f, transform.position.y, 0);
        }
    }
}
