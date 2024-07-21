using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    [SerializeField] ushort healthPoints = 60;

    public void GetDamage(float damage)
    {
        if(healthPoints - damage <= 0)
        {
            SendMessage("HandleDeath"); //String reference!!
        }
        else
        {
            healthPoints -= (ushort)damage;
        }
    }
}
