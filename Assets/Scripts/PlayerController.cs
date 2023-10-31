using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 10f;

    private float horizontalInput;

    private float xRange = 15f;

    [SerializeField] private GameObject foodPrefab;

    private void Update()
    {
        // Movimiento
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        PlayerInBounds();

        // Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootFood();
        }

    }

    private void PlayerInBounds()
    {
        Vector3 pos = transform.position;

        if(pos.x < -xRange)
        {
            transform.position = new Vector3(-xRange, pos.y, pos.z);
        }

        if(pos.x > xRange)
        {
            transform.position = new Vector3(xRange, pos.y, pos.z);
        }
    }

    private void ShootFood()
    {
        Instantiate(foodPrefab, transform.position, Quaternion.identity);
    }
}
