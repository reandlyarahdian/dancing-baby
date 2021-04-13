using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController character;
    [SerializeField] private Vector3 move = Vector3.forward;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    private float gravity = 9.81f;
    Vector3 rotate;
    public static Movement M;

    void Start()
    {
        M = this;
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && character.isGrounded)
        {
            StartCoroutine(jumping());
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move = Vector3.left;
            rotate = new Vector3(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            move = Vector3.forward;
            rotate = new Vector3(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(rotate);
        move.y -= gravity * Time.deltaTime;
        character.Move(move * speed);
    }

    IEnumerator jumping()
    {
        move = Vector3.up * jump;
        yield return new WaitForSeconds(0.5f);
        move = Vector3.forward;
    }
}