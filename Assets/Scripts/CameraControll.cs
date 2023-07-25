using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControll : MonoBehaviour
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
            transform.position += (moveDirection.normalized * Time.deltaTime * moveSpeed);

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
    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var mouseInput = context.ReadValue<Vector2>();

            yRotateMove = mouseInput.x * rotateSpeed * Time.deltaTime;
            xRotateMove = -mouseInput.y * rotateSpeed * Time.deltaTime;

            yRotate = transform.eulerAngles.y + yRotateMove;

            xRotate = xRotate + xRotateMove;

            xRotate = Mathf.Clamp(xRotate, -30f, 35f);

            

            transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        }
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



