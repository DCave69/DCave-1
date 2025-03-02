using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : CharacterStats
{
    [SerializeField] private GameObject explosionPrefab;
    private int damageDivisor = 5;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 20;
        currentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            GetDamaged((int)collision.impulse.magnitude / damageDivisor);
            Destroy(collision.gameObject);
            if (currentHealth < 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        DisableChildren();
        var explo = Instantiate(explosionPrefab, this.gameObject.transform);
        explo.GetComponent<ParticleSystem>().Play();
        StartCoroutine("DeleteGameObject");
    }

    IEnumerator DeleteGameObject()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    void DisableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActiveRecursively(false);
        }
    }
}
