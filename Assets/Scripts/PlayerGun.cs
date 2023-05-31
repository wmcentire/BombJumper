using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0;
    [SerializeField] public GameObject parent;
    [SerializeField] private float pushStrength;
    [SerializeField] private int MaxAmmo = 1;

    private int CurrAmmo;
    private Rigidbody2D ParRB;
    private PlayerMovement ParMovement;


    private void Awake()
    {
        CurrAmmo = MaxAmmo;
        if(parent != null)
        {
            ParRB = parent.GetComponent<Rigidbody2D>();
            ParMovement = parent.GetComponent<PlayerMovement>();
        }
    }

    void Update()
    {
        if (parent != null)
        {
            transform.position = parent.transform.position;
            if(ParMovement.CanJump()) CurrAmmo = MaxAmmo;
        }

        Debug.Log("AMMO: " + CurrAmmo);

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);

        if (Input.GetButtonDown("Fire1") & ParRB != null && CurrAmmo > 0)
        {
            ParRB.AddForce(direction.normalized * -pushStrength, ForceMode2D.Impulse);
            CurrAmmo--;
        }
    }
}
