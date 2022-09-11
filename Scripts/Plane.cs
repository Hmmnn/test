using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;

    private float horizontalValue = 0.0f;
    private float verticalValue = 0.0f;

    private Vector2 direction;

    private void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");

        direction = transform.right * horizontalValue + transform.up * verticalValue;

        if (direction.sqrMagnitude > 1.0f)
            direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);

        FixPosition();
    }

    private void FixPosition()
    {
        Vector2 limitRange;
        limitRange.x = -5.0f;
        limitRange.y = 5.0f;

        if (transform.position.x < limitRange.x)
        {
            Vector2 temp;
            temp.x = transform.position.x - limitRange.x;
            temp.y = 0;

            transform.Translate(-temp);
        }
        else if(transform.position.x > limitRange.y)
        {
            Vector2 temp;
            temp.x = transform.position.x - limitRange.y;
            temp.y = 0;

            transform.Translate(-temp);
        }
    }

    private void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            BulletManager.instance.Fire(transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
