using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private float turnSpeed = 5f;
    private NavMeshAgent navMeshAgent;
    private Animator animComponent;
    private float distanceToTarget = Mathf.Infinity;
    private bool _isProvoked;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animComponent = GetComponent<Animator>();
    }

    private void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        animComponent.SetBool("Attack", false);
        animComponent.SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        animComponent.SetBool("Attack", true);
        FaceTarget();
    }
    public void OnDamageTaken()
    {
        _isProvoked = true;
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x , 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, Time.deltaTime * turnSpeed);
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if(_isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            _isProvoked = true;
            //navMeshAgent.SetDestination(target.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
