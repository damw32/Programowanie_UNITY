using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 3f;
    private float jump = 7f;
   // [SerializeField] private LayerMask layerMask;
    
    private Rigidbody2D body;
    private Animator animation;
    private BoxCollider2D box;
    private bool grounded;
    private float horizontalInput;



    private void Awake()
    {
        body = transform.GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(horizontalInput * speed, body.velocity.y);
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.1412639f, 0.1543184f, 0.97414f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.1412639f, 0.1543184f, 0.97414f);
        }


        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
            
        }
      
        animation.SetBool("walk", horizontalInput != 0);
        animation.SetBool("grounded", grounded);

    }
   /* private bool IsGrounded()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, Vector2.down, 0.1f, layerMask);
        Debug.Log(raycast.collider);
        return raycast.collider != null;
    }*/

    private void Jump()
    {
        body.velocity = Vector2.up * jump;
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    public bool canAttack()
    {
        return horizontalInput == 0;
    }
}
