using System;
using GameForClaim;
using UnityEngine;
using UnityEngine.UI;

public class Counters : MonoBehaviour
{
    private Car player;
    private Text text;

    private void Start()
    {
        player = FindFirstObjectByType<Car>();
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "Structural Integrity: " + Mathf.Floor((float)player.GetHealthLevel() * 100) + "%\nTotal Damage: £" + DamageCalculator.GetInstance().GetValueOfCurrentDamage() + ".00";
    }
}
