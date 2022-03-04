using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisableAfterShortTime : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeFadeOut = 3;

    [SerializeField]
    private float fadeOutSpeed = 5;

    [SerializeField]
    private float distFromPlayer = 8;

    [SerializeField]
    private float yPos = 8;

    [SerializeField]
    private bool positionLate = false;

    private SpriteRenderer sr;
    private TextMeshPro text;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();

        if (positionLate)
        {
            StartCoroutine(RemoveIfExperienceStart());
            Invoke("Position", 0.5f);
        }
        else
            Position();

        StartCoroutine(FadeOut());
    }

    private void Position()
    {
        transform.position = Camera.main.transform.forward.normalized * distFromPlayer;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(timeBeforeFadeOut);

        if(sr != null)
        {
            while (sr.color != Color.clear)
            {
                sr.color = Color.Lerp(sr.color, Color.clear, Time.fixedDeltaTime * fadeOutSpeed);
                text.color = Color.Lerp(text.color, Color.clear, Time.fixedDeltaTime * fadeOutSpeed);
                yield return new WaitForFixedUpdate();
            }
        }
        else
        {
            while (text.color != Color.clear)
            {
                text.color = Color.Lerp(text.color, Color.clear, Time.fixedDeltaTime * fadeOutSpeed);
                yield return new WaitForFixedUpdate();
            }
        }

        Destroy(gameObject);
    }

    private IEnumerator RemoveIfExperienceStart()
    {
        while (ConstellationInteraction.activeExperience == null)
        {
            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
    }
}
