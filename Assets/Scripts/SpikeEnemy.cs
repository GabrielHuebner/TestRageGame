using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemy : MonoBehaviour
{
    public float MovementSpeed = 1;

    private Rigidbody2D _rigidbody;
    private Vector3 dir = Vector3.left;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * MovementSpeed * Time.deltaTime);

        if(transform.position.x > -3)
        {
            dir = Vector3.left;
        }
        else if(transform.position.x < -15)
        {
            dir = Vector3.right;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<CharacterMovement>() != null)
        {
            GameManager.Instance.OnDeath();
        }
    }
}
