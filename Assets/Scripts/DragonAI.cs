using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class DragonAI : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float distanceToAttack = 1;

    [SerializeField]
    float speed = 2;

    Animator _animator;
    Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    bool isAttacking = false;
    float direction;
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float distance = target.position.x - this.transform.position.x;
            direction = Mathf.Sign(distance);

            if (Mathf.Abs(distance) < distanceToAttack && isAttacking == false)
            {
                //attack
                _animator.SetTrigger("Attack");
                isAttacking = true;

                //stop moving
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
                _animator.SetBool("IsMoving", false);
            }
            else if (isAttacking == false)
            {
                //start moving
                _rigidbody2D.velocity = new Vector2(direction * speed, _rigidbody2D.velocity.y);
                _animator.SetBool("IsMoving", true);
            }
        }
        else
        {
            //stop moving
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            _animator.SetBool("IsMoving", false);
        }
    }
    private void LateUpdate()
    {
        if (transform.localScale.x > 0
            && direction < 0
            ||
            transform.localScale.x < 0
            && direction > 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    public void StopAttacking()
    {
        isAttacking = false;
    }

    public void TargetIsDeath()
    {
        target = null;
    }
}
