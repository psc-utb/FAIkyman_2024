using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MainCameraController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayCameraFinalMove(GameObject go)
    {
        animator.SetTrigger("final");
    }
}
