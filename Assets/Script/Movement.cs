using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController character;
    [SerializeField] private Vector3 move;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] public MoveNRotate trigger;
    Vector3 rotate;
    public static Movement M;

    void Start()
    {
        M = this;
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (trigger == MoveNRotate.left)
            {
                move = Vector3.left;
                rotate = new Vector3(0, 270, 0);
            }
            else if (trigger == MoveNRotate.right)
            {
                move = Vector3.right;
                rotate = new Vector3(0, 90, 0); ;
            }
            else if (trigger == MoveNRotate.forward)
            {
                move = Vector3.forward;
                rotate = new Vector3(0, 0, 0); ;
            }
            else if (trigger == MoveNRotate.backward)
            {
                move = Vector3.back;
                rotate = new Vector3(0, 180, 0); ;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(rotate);
        character.Move(move * speed);
    }
}

public enum MoveNRotate
{
    left,
    right,
    forward,
    backward
}