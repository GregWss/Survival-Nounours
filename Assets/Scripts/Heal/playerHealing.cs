using UnityEngine;

public class playerHealing : MonoBehaviour
{
    public int amountHealing = 10;

    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    bool healed = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            HealingZone(playerHealth);
        }

        if (healed)
        {
            Destroy(gameObject);
        }
    }

    void HealingZone(PlayerHealth playerHealth)
    {
        if (playerHealth.currentHealth != 0 && playerHealth.currentHealth != 100)
        {
            if (playerHealth.Heal(amountHealing))
            {
                healed = true;
            }
        }
    }
}
