using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    Vector3 offset;
    [SerializeField]
    Transform target;

    void Start()
    {
        this.offset = transform.position - target.position;
    }

    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, this.target.position + offset, 8f * Time.deltaTime);
    }
}
