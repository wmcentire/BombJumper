using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCam : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] private float ratio = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            var temp = Vector3.Lerp(transform.position, target.transform.position, ratio);

            Vector3 halfway = new Vector3(temp.x, temp.y, transform.position.z);

            transform.position = halfway;
        }
    }
}
