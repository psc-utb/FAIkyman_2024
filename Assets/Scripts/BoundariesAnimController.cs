using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BoundariesController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayBoundariesFinalMove(GameObject go)
    {
        animator.SetTrigger("MoveBoundaries");
    }
}
