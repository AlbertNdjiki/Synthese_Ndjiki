using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public ParticleSystem dust;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private float _delai = 0.5f;

    private bool facR = true;
    private float dirX = 0f;

    private float _canFire = -1;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource fireSoundEffect;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
        Tir();
    }

    private void Tir()
    {
        //Debug.Log(Input.GetAxis("Fire1"));
        if (Input.GetAxis("Fire1") == 1 && Time.time > _canFire)
        {
            _canFire = Time.time + _delai;
            fireSoundEffect.Play();

        }
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0f && facR)
        {

            createDust();
            state = MovementState.running;
          
            flip();
            

        }
        else if (dirX < 0f  && !facR)
        {

            state = MovementState.running;
           
           
            flip();
            sprite.flipX = true;


            createDust();
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
            createDust();
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    void createDust()
    {
        dust.Play();
    }

    void flip()
    {
        facR = !facR;
        transform.Rotate(0f, 180f, 0f);
        
    }


}