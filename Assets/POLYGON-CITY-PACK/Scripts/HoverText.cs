using UnityEngine;
using UnityEngine.EventSystems;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup hoverTextCanvasGroup; // Instead of GameObject

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut());
    }

    private System.Collections.IEnumerator FadeIn()
    {
        hoverTextCanvasGroup.gameObject.SetActive(true);

        while (hoverTextCanvasGroup.alpha < 1)
        {
            hoverTextCanvasGroup.alpha += Time.deltaTime * 5; // Faster fade
            yield return null;
        }
    }

    private System.Collections.IEnumerator FadeOut()
    {
        while (hoverTextCanvasGroup.alpha > 0)
        {
            hoverTextCanvasGroup.alpha -= Time.deltaTime * 5;
            yield return null;
        }

        hoverTextCanvasGroup.gameObject.SetActive(false);
    }
}
