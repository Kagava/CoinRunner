using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 moveDiraction;
    public float speedForward;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
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
        controller.Move(moveDiraction * Time.fixedDeltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Player")
        {
            speedForward = 0;
            moveDiraction.z = 0;
        }

    }
}
