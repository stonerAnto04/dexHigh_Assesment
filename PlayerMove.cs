using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public CharacterController charController;
    public Animator animator;
    public GameObject detectionFightE;

    [Header("Movement")]
    public float moveSpeed = 1f;
    public float gravity = -9.10f;
    public float jumpHeight = 1f;
    public float rotationSpeed = 0.15f;
    public float rotateDps;

    //FIREBALL
    //public Transform ballSpawnPoint;
    //public GameObject ballPrefab;
    //public float ballSpeed = 10;


    [Header("Ground Check")]
    public Transform groundCheck;
    public float ground_Distance;
    public LayerMask ground_Mask;

    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, ground_Distance, ground_Mask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        animator.SetFloat("forward", y);
        animator.SetFloat("strafe", x);

        Vector3 move = transform.right * x + transform.forward * y;

        charController.Move(move * moveSpeed * Time.deltaTime);


        //JUMP ANIM
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
           
        }
        if (isGrounded)
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }


        //TALEA ATTACK ANIM
        if(Input.GetButtonUp("Fire1") && isGrounded)
        {
            
            animator.SetBool("tailattack", true);
        }
        else
        {
            animator.SetBool("tailattack", false);
        }


        //FIREATTACK ANIM
        if(Input.GetButtonUp("Fire2") && isGrounded)
        {        
            animator.SetBool("fireattack", true);
            //var ball = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
            //ball.GetComponent<Rigidbody>().velocity = ballSpawnPoint.forward * ballSpeed;
            Debug.Log("ball spawned");
        }
        else
        {
            animator.SetBool("fireattack", false);
        }

        velocity.y += gravity * Time.deltaTime;

        charController.Move(velocity * Time.deltaTime);

        //Rotate();
    }

    /*void Rotate()
    {
        Vector3 rotation_Direction = Vector3.zero;

        if(Input.GetAxis("Horizontal") < 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.left);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.right);
        }
        
        if(rotation_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotation_Direction),rotateDps * Time.deltaTime);
        }
    }*/

    public void Death()
    {
        animator.SetTrigger("Died");
        SceneManager.LoadScene(2);

    }

    

   }
