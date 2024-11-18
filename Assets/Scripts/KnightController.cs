using System.Collections;
using System.Collections.Generic;
using CodeMonkey.HealthSystemCM;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class KnightController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    GameObject sword;

    Animator _animator;

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    bool isAttacking = false;
    // Update is called once per frame
    void Update()
    {
        if (isAttacking == false)
        {
            float vx = Input.GetAxisRaw("Horizontal");
            if (vx != 0)
            {
                _animator.SetBool("IsMoving", true);
            }
            else
            {
                _animator.SetBool("IsMoving", false);
            }
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        if(Input.GetButtonDown("Fire1") && isAttacking == false)
        {
            _animator.SetTrigger("Attack");
            isAttacking = true;
            sword.SetActive(true);
        }
    }

    public void EndOfAttack()
    {
        isAttacking = false;
        sword.SetActive(false);
    }

    private void LateUpdate()
    {
        if (isAttacking == false)
        {
            float vx = Input.GetAxisRaw("Horizontal");
            if (vx != 0)
            {
                transform.Translate(new Vector3(vx * speed * Time.deltaTime, 0, 0));
            }

            if (vx > 0 && transform.localScale.x < 0
                ||
                vx < 0 && transform.localScale.x > 0)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
    }
}
