using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class KnightController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    Animator _animator;

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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

    private void LateUpdate()
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
