using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneManager : MonoBehaviour
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


    [SerializeField]
    bool TriggerOnce = true;
    bool wasTriggered = false;

    [SerializeField]
    Color textColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TriggerOnce == true && wasTriggered == true)
            return;

        if (collision.gameObject == triggerGO)
        {
            wasTriggered = true;

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
            text.color = textColor;

            text.renderer.sortingLayerName = "UI";
            text.renderer.sortingOrder = 7;
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
