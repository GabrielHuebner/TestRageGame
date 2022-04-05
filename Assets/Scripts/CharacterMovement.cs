using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public float gravityMultilier = 1;

    private Rigidbody2D _rigidbody;
    private bool isOnGround = true;
    private int doubleJump;


    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || doubleJump > 0)){
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            --doubleJump;
        }

        if (!isOnGround)
        {
            _rigidbody.velocity += Vector2.down * gravityMultilier;
        }

        if(transform.position.y < -15)
        {
            GameManager.Instance.OnDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOnGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnGround = false;
        doubleJump = 1;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.GetComponent<OnCollisonDeath>()!= null)
        {
            GameManager.Instance.OnDeath();
        }
    }
}
