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
        StartCoroutine(DestroyAfterSeconds(2f));
    }

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Arrow" && collision.gameObject.tag != "Player")
        {
            print(collision.gameObject.tag);
            Destroy(this.gameObject.GetComponent<Rigidbody>());
            Destroy(this.gameObject.GetComponent<BoxCollider>());

        }
        if (collision.gameObject.tag == "Enemy") {
            this.gameObject.SetActive(false);
            collision.gameObject.GetComponent<BossStats>().TakeDamage(10);
        }
    }
}
