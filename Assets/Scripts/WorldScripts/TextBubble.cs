 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBubble : MonoBehaviour
{
    private SpriteRenderer m_BackgroundSpriteRenderer;
    private TextMeshPro m_TextMesh;

    public static void Create(Transform prefab, Transform parent, Vector3 localPosition, string text)
    {
        Transform textBubble = Instantiate(prefab, parent);
        textBubble.localPosition = localPosition;
        textBubble.GetComponent<TextBubble>().Setup(text);
        Destroy(textBubble.gameObject, 5f);
    }

    private void Awake()
    {
        m_BackgroundSpriteRenderer = transform.Find("TextBubble").GetComponent<SpriteRenderer>();
        m_TextMesh = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void Setup(string text)
    {
        m_TextMesh.SetText(text);
        m_TextMesh.ForceMeshUpdate();
        Vector2 textSize = m_TextMesh.GetRenderedValues(false);
        Vector2 padding = new Vector2(2f, 1f);
        Vector3 offset = new Vector3(-1f, -0.25f, 0);

        m_BackgroundSpriteRenderer.size = textSize + padding;
        m_BackgroundSpriteRenderer.transform.localPosition = new Vector3(m_BackgroundSpriteRenderer.size.x / 2, 0, 
                                                                m_BackgroundSpriteRenderer.transform.localPosition.z) + offset;
    }
}
