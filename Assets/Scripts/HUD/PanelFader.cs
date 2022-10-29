using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFader : MonoBehaviour
{
    public float duration = 0.4f;
    public void Fade()
    {
        
        var canvGroup = GameObject.Find("HUD/ControlHint").GetComponent<CanvasGroup>();
        print(canvGroup);
        StartCoroutine(DoFade(canvGroup));

    }

    public IEnumerator DoFade(CanvasGroup canvGroup)
    {
        float start = canvGroup.alpha;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp (start, 0, counter / duration);

            yield return null;
        }
    }

}
