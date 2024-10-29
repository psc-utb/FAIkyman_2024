using CodeMonkey.HealthSystemCM;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField]
    int damage_min = 1;
    [SerializeField]
    int damage_max = 5;

    [SerializeField]
    GameObject numberPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.gameObject.GetComponent<HealthSystemComponent>();

        if (character != null)
        {
            int damage = Random.Range(damage_min, damage_max + 1);
            character.GetHealthSystem().Damage(damage);
            //Debug.Log("Attacked");
            if(numberPrefab != null)
            {
                var go = Instantiate(numberPrefab);

                go.transform.position = new Vector2(character.transform.position.x, go.transform.position.y);

                TextMeshPro textMeshPro = go.GetComponent<TextMeshPro>();
                textMeshPro.text = "-" + damage;

                Rigidbody2D rb2D = go.GetComponent<Rigidbody2D>();
                rb2D.velocity = new Vector2(0, 2);

                Destroy(go, 3);
            }
        }
    }
}
