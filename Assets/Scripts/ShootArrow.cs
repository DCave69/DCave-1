using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnpoint; // in order to spawn the arrow in the right place
    [SerializeField] private TextMeshProUGUI firePowerText;
    private float maxFirePower = 10f;
    private float firePowerSpeed = 10f;
    private float firePower = 0;
    private bool isChargingBow = false;

    private GameObject currentArrow;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isChargingBow = true;
            AddArrow();
        }

        if (isChargingBow)
        {
            // keep increasing until maxFirePower is reached
            if (firePower < maxFirePower)
            {
                firePower += Time.deltaTime * firePowerSpeed;
            }

            if (Input.GetMouseButtonUp(1))
            {
                Shoot();
                firePower = 0;
                isChargingBow = false;
            }

            firePowerText.text = "Fire Power = " + String.Format("{0:.##}", firePower);
        }
    }

    void Shoot()
    {
        print("Shot an arrow!");
        currentArrow.GetComponent<Arrow>().Shoot(firePower);
        currentArrow.GetComponent<Rigidbody>().useGravity = true;
    }

    void AddArrow()
    {
        print("Instantiate arrow");
        currentArrow = Instantiate(arrowPrefab, arrowSpawnpoint);
        currentArrow.GetComponent<Rigidbody>().useGravity = false;
    }
}