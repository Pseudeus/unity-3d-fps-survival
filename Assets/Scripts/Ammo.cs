using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private ushort ammoAmount = 10;

    public bool IsAmmoAvailable()
    {
        if (ammoAmount > 0) return true;
        return false;
    }

    public void ReduceAmmo()
    {
        ammoAmount--;
    }
}
