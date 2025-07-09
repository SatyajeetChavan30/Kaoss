using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 10f;
    //[SerializeField] private float rotateSpeed = 20f;
    private bool isWalking;
    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

       if(Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
        }
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        isWalking = moveDir != Vector3.zero;
        //transform.LookAt(transform.position + moveDir);
        float rotateSpeed = 10f;

        if (moveDir != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        }

        
        

    }
    public bool IsWalking()
    {
        return isWalking;
    }

}
