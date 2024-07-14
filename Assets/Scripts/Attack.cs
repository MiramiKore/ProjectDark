using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private Health health;

    public void IsAttack()
    {
        health.IsDamageble(damage);
    }
}
