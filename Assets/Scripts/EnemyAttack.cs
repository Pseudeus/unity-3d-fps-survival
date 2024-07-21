using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth _target;
    [SerializeField] float damage = 40f;
    void Start()
    {
        _target = FindObjectOfType<PlayerHealth>();
    }

    private void AttackHitEvent()
    {
        if(_target == null) return;

        _target.GetDamage(damage);
    }
}
