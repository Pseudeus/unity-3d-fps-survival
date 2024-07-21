using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] ushort hitPoints = 100;

    public void TakeDamage(byte damage)
    {
        

        if(hitPoints - damage > 0)
        {
            BroadcastMessage("OnDamageTaken");
            hitPoints -= damage;
        }
        else
        {
            KillHostage();
        }
    }

    private void KillHostage()
    {
        Destroy(gameObject);
    }
}
