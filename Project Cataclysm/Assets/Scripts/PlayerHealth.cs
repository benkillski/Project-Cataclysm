using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHeath = 100;
    [SerializeField] TextMeshProUGUI healthDisplayText;

    // Start is called before the first frame update
    void Start()
    {
        playerHeath = 100;
        UpdateHUD();
    }

    public int GetPlayerHealth()
    {
        return playerHeath;
    }

    public void SetPlayerHealth(int newHealth)
    {
        playerHeath = newHealth;

        if (playerHeath <= 0)
            KillPlayer();

        UpdateHUD();

    }

    private void UpdateHUD()
    {
        healthDisplayText.text = "HEALTH: " + playerHeath;
    }

    private void KillPlayer()
    {
        Debug.Log("PLAYER HAS DIED");
    }
}
