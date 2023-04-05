using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnpoint;
    [SerializeField] private TextMeshProUGUI firePowerText;
    [SerializeField] private Transform sceneUtilsTransform; // in order to unchild the arrow when shooting

    private float maxFirePower = 50f;
    private float firePowerSpeed = 40f;
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
        currentArrow.GetComponent<Arrow>().Shoot(firePower);
        currentArrow.GetComponent<Arrow>().transform.SetParent(sceneUtilsTransform, true);
        currentArrow.GetComponent<Rigidbody>().useGravity = true;
        
        
    }

    void AddArrow()
    {
        currentArrow = Instantiate(arrowPrefab, arrowSpawnpoint);
        currentArrow.GetComponent<Rigidbody>().useGravity = false;
    }
}