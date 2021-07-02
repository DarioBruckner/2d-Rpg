using UnityEngine;

public class ScaleController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.parent.localScale;
    }
}
