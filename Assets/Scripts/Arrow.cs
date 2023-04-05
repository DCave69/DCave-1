using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.GetComponent<BoxCollider>().enabled = false;
    }

    public void Shoot(float speed)
    {
        this.GetComponent<BoxCollider>().enabled = true;
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        StartCoroutine(DestroyAfterSeconds(5f));
    }

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}
