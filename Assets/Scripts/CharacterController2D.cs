using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour
{
    [Header("Movement")]
    public bool canMove = true;
    public float maxSpeed = 15f;
    public string movementAxis;
    private bool _facingRight = true;

    [Header("Jump")]
    public bool CanJump;
    public string jumpAxis;
    private bool _jumpKeyPressed;
    public float jumpForce = 1700f;
    public bool hasDoubleJump;
    private bool _doubleJump;
    public bool _grounded;
    public Transform groundCheck;
    private float groundRadious = 0.2f;
    public LayerMask whatIsGround;
    private bool wasGrounded = false;


    public GameObject particlesObj;
    public float fallHeightForParticles;
    private float jumpStartHeight = -99999f;
    private Rigidbody2D rb;
    private float jumpMaxHeight;
    private GameObject instanciatedParticles;

    private AudioSource aS;

    public bool aceptamosInput = true;



    // others
    private Animator _anim;

    // Use this for initialization
    void Start()
    {
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (aceptamosInput)
        {
            if (CanJump)
            {
                wasGrounded = _grounded;
                CheckJump();
                _grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadious, whatIsGround);
                if (!wasGrounded && _grounded && rb.velocity.y <= 0.1f)
                {
                    jumpStartHeight = -99999f;
                    aS.PlayOneShot(aS.clip);
                    if (jumpMaxHeight > transform.position.y + fallHeightForParticles)
                    {
                        instanciatedParticles = Instantiate(particlesObj, groundCheck.transform.position, particlesObj.transform.rotation);
                        instanciatedParticles.GetComponent<TimedDestroy>().CallDestroy();
                        instanciatedParticles.GetComponent<ParticleSystem>().Play();
                    }
                }
                else if (!_grounded && wasGrounded)
                {
                    jumpStartHeight = transform.position.y;
                    StopCoroutine(nameof(HighestHeight));
                    StartCoroutine(nameof(HighestHeight));
                }
            }
            if (canMove)
            {
                CheckMovement();
            }
        }
    }

    private void CheckMovement()
    {
        float move = 0;

        move = Input.GetAxis(movementAxis);

        int direction = _facingRight ? 1 : -1;
        transform.Translate(move * maxSpeed * direction * Time.deltaTime, 0, 0);

        if ((move > 0 && !_facingRight) || (move < 0 && _facingRight))
        {
            Flip();
        }

        if (_anim != null)
        {
            _anim.SetFloat("Speed", Mathf.Abs(move));
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(new Vector3(0, 180, 0), Space.World);
        //sr.flipX = !sr.flipX;
    }

    private void CheckJump()
    {
        if ((_grounded || (hasDoubleJump && !_doubleJump)) && Input.GetAxis(jumpAxis) > 0)
        {
            if (_jumpKeyPressed == false)
            {
                _jumpKeyPressed = true;
                _grounded = false;
                rb.velocity = new Vector2(0.0f, 0.0f);
                rb.AddForce(new Vector2(0, jumpForce));
                jumpStartHeight = transform.position.y;
                StopCoroutine(nameof(HighestHeight));
                StartCoroutine(nameof(HighestHeight));
                if (!_doubleJump && !_grounded)
                {
                    _doubleJump = true;
                }
            }
        }

        if (_grounded)
        {
            _doubleJump = false;
        }

        if (Input.GetAxis(jumpAxis) == 0 && _jumpKeyPressed)
        {
            _jumpKeyPressed = false;
        }
    }

    private IEnumerator HighestHeight()
    {
        jumpMaxHeight = jumpStartHeight;
        while (rb.velocity.y > 0)
        {
            yield return null;
        }
        jumpMaxHeight = transform.position.y;
    }



}
