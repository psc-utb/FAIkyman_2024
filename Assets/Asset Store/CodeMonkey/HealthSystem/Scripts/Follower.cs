using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(target.transform.position.x, this.transform.position.y);
    }
}
