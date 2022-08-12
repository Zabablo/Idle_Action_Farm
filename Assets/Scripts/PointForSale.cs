using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointForSale : MonoBehaviour
{
    [SerializeField] Player player;
    private bool isActive;

    private void OnTriggerEnter(Collider other)
    {
        isActive = true;
        if ((player.haystackCount > 0) && (other.name == "Player"))
        {
            StartCoroutine(Sale());
        }
    }

    IEnumerator Sale()
    {
        player.HaystackSell();
        yield return new WaitForSeconds(0.07f);
        if (isActive && (player.haystackCount > 0))
        {
            StartCoroutine(Sale());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isActive = false;
    }
}
