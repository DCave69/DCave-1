using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSword : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    private bool canAttack = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (canAttack)
            {
                player.TakeDamage(1);
                StartCoroutine("AttackDelay");
            }
        }
    }

    IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }
}
