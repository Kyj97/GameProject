using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CharacterControll : MonoBehaviour
{
    Rigidbody rigid;
    TargetSelect targetSelect;

    private Vector3 moveDirection;
    private float moveSpeed = 4f;

    private float xRotate, yRotate, xRotateMove, yRotateMove;
    public float rotateSpeed = 500.0f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        bool hasControl = (moveDirection != Vector3.zero);
        if (hasControl)
        {
            transform.position += (moveDirection.normalized* Time.deltaTime * moveSpeed);
            
        }
    }



    public void OnMove(InputAction.CallbackContext context)   
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (input != null)
        {
            moveDirection = (transform.forward * input.x) + (transform.right * input.y);
        }

    }


    public void OnJump(InputAction.CallbackContext context)
    {
        rigid.AddForce(0f, 50f, 0f);
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        var mouseInput = context.ReadValue<Vector2>();
        yRotate = mouseInput.x * Time.deltaTime * rotateSpeed;
        transform.eulerAngles += new Vector3(transform.eulerAngles.x, yRotate, 0);

    }

    public void OnReaction(InputAction.CallbackContext context)
    {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

       RaycastHit hit = new RaycastHit();

       if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))  
        {
          if (hit.transform.gameObject.CompareTag("target"))
          {
                targetSelect.ScoreUp();
                
          }
          else if (hit.transform.gameObject.CompareTag("dummy"))
           {
                targetSelect.ScoreDown();
           }

            }

        
    }

}
