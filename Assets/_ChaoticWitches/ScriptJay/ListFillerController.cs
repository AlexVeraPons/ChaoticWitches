using UnityEngine;
using UnityEngine.AI;

public class ListFillerController : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject myPlayer;
    private MoveToTarget moveToTarget;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        moveToTarget = myPlayer.GetComponent<MoveToTarget>();
        
    }

    // Update is called once per frame
    void Update()
    {
        target = moveToTarget.target;
        GoToTarget();
    }

    private void GoToTarget()
    {
        if(agent != null)
        {
            agent.SetDestination(target.position);
        } return;
    }

    public void NextTarget(Transform nextTarget)
    {
        target = nextTarget;
    }
}
