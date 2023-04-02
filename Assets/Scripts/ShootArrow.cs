using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform bowPosition; // in order to spawn the arrow in the right place
    [SerializeField] private TextMeshProUGUI firePowerText;
    private double maxFirePower = 5;
    private double firePowerSpeed = 5f;
    private double firePower = 0;
    private bool isChargingBow = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isChargingBow = true;
            addArrow();
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
                shootArrow();
                firePower = 0;
                isChargingBow = false;
            }

            firePowerText.text = "Fire Power = " + String.Format("{0:.##}", firePower);
        }
    }

    void shootArrow()
    {
        print("Shot an arrow!");
    }

    void addArrow()
    {
        print("Instantiate arrow");
        Instantiate(arrowPrefab, bowPosition);
    }
}