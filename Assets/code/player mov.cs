using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovemante : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;
    public float Forcemode = 5f;
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpForce = 5f;

    [Header("Pickup Settings")]
    public Transform holdPoint;
    public GameObject objectToPickup;
    private bool isHolding = false;

    private bool isRunning;
    private bool isGrounded;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
        Vector3 moveDir = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * direction * currentSpeed;

        if (isGrounded || direction.magnitude > 0.1f)
        {
            rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
        }

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetTrigger("isDodging");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetBool("dead", true);
        }

        anim.SetBool("is work", direction.magnitude > 0.1f && !Input.GetKey(KeyCode.LeftShift));
        anim.SetBool("run", direction.magnitude > 0.1f && Input.GetKey(KeyCode.LeftShift));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Pickup()
    {
        if (objectToPickup != null)
        {
            Rigidbody rbObj = objectToPickup.GetComponent<Rigidbody>();
            if (rbObj != null) rbObj.isKinematic = true;

            objectToPickup.transform.SetParent(holdPoint);
            objectToPickup.transform.localPosition = Vector3.zero;
            objectToPickup.transform.localRotation = Quaternion.identity;
            isHolding = true;
        }
    }

    void Drop()
    {
        if (objectToPickup != null)
        {
            objectToPickup.transform.SetParent(null);
            Rigidbody rbObj = objectToPickup.GetComponent<Rigidbody>();
            if (rbObj != null) rbObj.isKinematic = false;

            isHolding = false;
        }
    }
}
