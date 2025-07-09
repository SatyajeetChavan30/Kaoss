using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    //[SerializeField] private float rotateSpeed = 20f;
    private bool isWalking;
    private void Update()
    {
        ;
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        float playerRadius = 0.7f;
        float playerHeight = 2f;
        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);
        if (canMove)
        {
            Vector3 moveDirX = new Vector3(moveDirection.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
        }
        if (canMove) 
        { 
        transform.position += moveDirection * moveDistance;
         }

        isWalking = moveDirection != Vector3.zero;
        //transform.LookAt(transform.position + moveDir);
        float rotateSpeed = 10f;

        if (moveDirection != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
        }

        
        

    }
    public bool IsWalking()
    {
        return isWalking;
    }

}
