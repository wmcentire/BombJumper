using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCam : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private float ratio = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, ratio);
        }
    }
}
