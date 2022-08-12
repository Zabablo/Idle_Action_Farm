using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haystack : MonoBehaviour
{
    [SerializeField] private RiseWheats riseWheats;

    private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if ("Player" == other.gameObject.name)
        {
            player = other.gameObject.GetComponent<Player>();
            if (player.haystackCount < 40)
            {
                transform.SetParent(other.transform, true);
                player.HaystackInstallation(this.gameObject);
            }
        }
    }
}
