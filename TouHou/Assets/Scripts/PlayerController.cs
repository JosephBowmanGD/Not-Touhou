using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private float InputHorizontal;
    private float InputVertical;

    [Header("Speed Variables")]
    [SerializeField] private float MoveSpeed = 6;
    [SerializeField] private float speedLimit = 0.7f;
    [SerializeField] private float slowDownSpeed = 3;
   
    private float currSpeed;
    private bool isSlowed;

    [Header("Animation")]
    public Animator anim;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currSpeed = MoveSpeed;
    }

    void Update()
    {
        InputHorizontal = Input.GetAxisRaw("Horizontal");
        InputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSlowed = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSlowed = false;
        }

        currSpeed = isSlowed ? slowDownSpeed : MoveSpeed;

        if(InputHorizontal == -1)
        {
            anim.SetBool("IsFlyingLeft", true);
        }
        else if(InputHorizontal == 1)
        {
            anim.SetBool("IsFlyingRight", true);
        }
        else if(InputHorizontal == 1 && InputHorizontal == -1 || InputHorizontal == 0)
        {
            anim.SetBool("IsFlyingRight", false);
            anim.SetBool("IsFlyingLeft", false);
        }
    }

    private void FixedUpdate()
    {
        if (InputHorizontal != 0 || InputVertical != 0)
        {
            if (InputHorizontal != 0 && InputVertical != 0)
            {
                InputHorizontal *= speedLimit;
                InputVertical *= speedLimit;
            }

            rb.velocity = new Vector2(InputHorizontal * currSpeed, InputVertical * currSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}