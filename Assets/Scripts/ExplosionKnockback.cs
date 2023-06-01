using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ExplosionKnockback : MonoBehaviour
{
    [SerializeField] public float force = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!collision.gameObject.CompareTag("Player")) return;

        Vector2 direction = collision.transform.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        var otherRB = collision.gameObject.GetComponent<Rigidbody2D>();

        if (otherRB != null)
        {
            float str = Mathf.Lerp(force / 2, force, direction.magnitude / this.GetComponent<CircleCollider2D>().radius);
            Vector2 finalForce = direction.normalized * str;
            otherRB.AddForce(finalForce);
        }
    }

}
