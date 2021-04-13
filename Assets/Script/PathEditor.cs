using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEditor : MonoBehaviour
{
    public List<Transform> transforms = new List<Transform>();
    Transform[] transformsArray;
    [SerializeField] private float sphere = 0.05f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        transformsArray = GetComponentsInChildren<Transform>();
        transforms.Clear();

        foreach (Transform path in transformsArray)
        {
            if (path != this.transform)
            {
                transforms.Add(path);
            }
        }
        for (int i = 0; i < transforms.Count; i++)
        {
            Vector3 pos = transforms[i].position;
            if (i > 0)
            {
                Vector3 prev = transforms[i - 1].position;
                Gizmos.DrawLine(prev, pos);
                Gizmos.DrawSphere(pos, sphere);
            }
        }
    }
}
