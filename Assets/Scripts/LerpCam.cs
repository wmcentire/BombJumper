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
//<<<<<<< HEAD
            transform.position = Vector2.Lerp(transform.position, target.position, ratio);
//=======
            var temp = Vector3.Lerp(transform.position, target.position, ratio);

            Vector3 halfway = new Vector3(temp.x, temp.y, transform.position.z);

            transform.position = halfway;
//>>>>>>> 89e8406a875b73897f11a5e298ffdbe8915430ed
        }
    }
}
