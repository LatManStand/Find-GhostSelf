using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour
{
    [Header("Movement")]
    public bool canMove = true;
    public float maxSpeed = 15f;
    public bool lookToMouse;
    public string movementAxis;
    private bool _facingRight = true;

    [Header("Jump")]
    public bool CanJump;
    public string jumpAxis;
    private bool _jumpKeyPressed;
    public float jumpForce = 1700f;
    public bool hasDoubleJump;
    private bool _doubleJump;
    private bool _grounded;
    public Transform groundCheck;
    private float groundRadious = 0.2f;
    public LayerMask whatIsGround;
    private bool wasGrounded = false;
    public GameObject particlesObj;
    private ParticleSystem particles;

    // others
    private Animator _anim;

    // Use this for initialization
    void Start()
    {
        _anim = GetComponent<Animator>();
        particles = particlesObj.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CanJump)
        {
            wasGrounded = _grounded;
            CheckJump();
            _grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadious, whatIsGround);
            if(!wasGrounded && _grounded)
            {
                //Instantiate(particles, transform).Play();
            }
        }
        if (canMove)
        {
            CheckMovement();
        }
    }

    private void CheckMovement()
    {
        float move = 0;

        move = Input.GetAxis(movementAxis);

        int direction = _facingRight ? 1 : -1;
        transform.Translate(move * maxSpeed * direction * Time.deltaTime, 0, 0);

        if (!lookToMouse && ((move > 0 && !_facingRight) || (move < 0 && _facingRight)))
        {
            Flip();
        }

        if (lookToMouse)
        {
            float mouseXPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            if ((transform.position.x < mouseXPos && !_facingRight) || (transform.position.x > mouseXPos && _facingRight))
            {
                Flip();
            }
        }
        else if ((move > 0 && !_facingRight) || (move < 0 && _facingRight))
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
    }

    private void CheckJump()
    {
        if ((_grounded || (hasDoubleJump && !_doubleJump)) && Input.GetAxis(jumpAxis) > 0)
        {
            if (_jumpKeyPressed == false)
            {
                _jumpKeyPressed = true;
                _grounded = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
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
}
