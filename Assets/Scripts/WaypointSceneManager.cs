using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaypointSceneManager : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    [SerializeField]
    float delay = 1;

    [SerializeField]
    GameObject triggerGO;

    [SerializeField]
    TMP_FontAsset font;

    [SerializeField]
    string ShowText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == triggerGO)
        {
            var go = new GameObject();
            go.name = $"TextGeneratedFromScript";
            go.transform.position = new Vector2(transform.position.x, transform.position.y + 1);

            var text = go.AddComponent<TextMeshPro>();

            if (font != null)
                text.font = font;
            text.fontSize = 4.5f;

            text.enableWordWrapping = false;

            text.alignment = TextAlignmentOptions.Center;

            text.text = ShowText;
            text.color = Color.cyan;

            text.renderer.sortingLayerName = "UI";
            text.rectTransform.sizeDelta = new Vector2(2, 2);

            Rigidbody2D rb2D = go.AddComponent<Rigidbody2D>();
            rb2D.isKinematic = true;
            rb2D.velocity = new Vector2(0, 1);

            GameObject.Destroy(go, delay);


            StartCoroutine(nameof(LoadSceneAfterSecond), sceneName);
        }
    }

    private IEnumerator LoadSceneAfterSecond(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName) == false)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(sceneName);
        }
    }
}
