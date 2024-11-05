using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DeathAnimController : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayDeathAnimation(GameObject go)
    {
        animator.SetTrigger("Death");
    }

    public void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
}
