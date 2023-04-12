using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSword : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    [SerializeField] private WarriorLocomotion warrior;

    private bool onAttackDelay = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (warrior.canAttack && !onAttackDelay)
            {
                player.TakeDamage(1);
                StartCoroutine("AttackDelay");
            }
        }
    }

    IEnumerator AttackDelay()
    {
        onAttackDelay = true;
        yield return new WaitForSeconds(1f);
        onAttackDelay = false;
    }
}
