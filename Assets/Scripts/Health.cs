using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    
    private void Awake()
    {
        currentHealth = maxHealth;
    }
    
    public void IsDamageble(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            IsDie();
        }
    }

    private void IsDie()
    {
        Debug.Log("Объект разрушен");
    }
}
