using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    
    private CharacterController controller;
    private Vector3 moveDiraction;
    public float multyplayer = 5.0f;
    public float speedForward;
    public float speedSide;
    public float speedJump;
    public float gravity;
    public FixedJoystick joy;
    [SerializeField] KeyCode keyLeft;
    [SerializeField] KeyCode keyRight;
    [SerializeField] KeyCode keyJump;
    [SerializeField] KeyCode keySlide;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gaveOverScript.isGameStart)
        {
            return;
        }
        moveDiraction.z = speedForward;
    }

    
    private void FixedUpdate()
    {
        if (!gaveOverScript.isGameStart)
        {
            return;
        }
        moveDiraction.y += gravity * Time.deltaTime;
        if (Input.GetKey(keyLeft))
        {
            moveDiraction.x -= speedSide;
        }
        if (Input.GetKey(keyRight))
        {
            moveDiraction.x += speedSide;
        }
        moveDiraction.x += (joy.Direction.x * multyplayer);
        if (swipeManager.swipeUp)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
            {
                if (controller.isGrounded)
                {
                    moveDiraction.y = speedJump;
                }
                anim.SetBool("isFlip", true);
            }
        }
       
        if (swipeManager.swipeDown)
        {
           if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Flip"))
           {
                StartCoroutine(Slide());
            }
        }
        controller.Move(moveDiraction * Time.fixedDeltaTime);
        moveDiraction.x = 0;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Flip"))
        {
            anim.SetBool("isFlip", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        {
            anim.SetBool("isSlide", false);
        }
    }

    private IEnumerator Slide()
    {
        Animator animator;
        animator = GetComponent<Animator>();
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

        animator.SetBool("isSlide", true);
        yield return new WaitForSeconds(1f);
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSlide", false);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Enemy")
        {
            anim.Play("defeat");
            speedJump = 0;
            speedForward = 0;
            speedSide = 0;
            gaveOverScript.gameOver = true;
        }
        
    }
}
