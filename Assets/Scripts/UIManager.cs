using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinText;
    [SerializeField] private TextMeshProUGUI StackText;
    [SerializeField] private Player player;

    private void Update()
    {
        CoinText.text = Convert.ToString(player.coinsCounter);
        StackText.text = Convert.ToString(player.haystackCount) + "/40";
    }
}
