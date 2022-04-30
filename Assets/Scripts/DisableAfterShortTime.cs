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

    [SerializeField]
    private GameObject normal;
    [SerializeField]
    private GameObject hoverObj;

    public bool shouldFade = true;

    private SpriteRenderer[] sr;
    private TextMeshPro text;

    [SerializeField]
    public bool shouldMove = true;

    [SerializeField]
    private bool shouldRotateWithCamera = false;

    [SerializeField]
    private float followSpeed = 5;

    private Coroutine followRef;

    private Transform camTransform;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponentsInChildren<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        camTransform = Camera.main.transform;

        if (hoverObj != null)
        {
            hoverObj.SetActive(false);
        }

        if (positionLate)
        {
            StartCoroutine(RemoveIfExperienceStart());
            Invoke("Position", 0.5f);
        }
        else if(shouldMove)
            Position();

        if(shouldFade)
        StartCoroutine(FadeOut());
    }

    private void FixedUpdate()
    {
        if (shouldRotateWithCamera)
        {
            Vector3 camForward = camTransform.forward;
            camForward.y = 0;
            Vector3 camPos = camTransform.position;
            camPos.y = transform.position.y;

            if (followRef == null && Vector3.Angle(camForward, (transform.position - camPos).normalized) > 45)
            {
                StartCoroutine(MoveToCamCenter());
            }
        }
    }

    private IEnumerator MoveToCamCenter()
    {
        Vector3 temp = Vector3.zero;
        MoveToCamCenterHelper(ref temp);

        while ((temp - transform.position).sqrMagnitude > 16)
        {
            yield return new WaitForFixedUpdate();
            MoveToCamCenterHelper(ref temp);
        }

        followRef = null;
    }

    private void MoveToCamCenterHelper(ref Vector3 temp)
    {
        temp = camTransform.forward;
        temp.y = 0;
        temp = temp.normalized * distFromPlayer;
        temp.y = yPos;
        //temp = Vector3.MoveTowards(transform.position, temp, Time.fixedDeltaTime * followSpeed);
        transform.position = Vector3.MoveTowards(transform.position, temp, Time.fixedDeltaTime * followSpeed);
        transform.LookAt(camTransform.position);

        Vector3 pos;
        pos = -transform.forward * distFromPlayer;
        pos.y = yPos;

        transform.position = pos;
        transform.LookAt(camTransform.position);
    }

    private void Position()
    {
        Vector3 temp = camTransform.forward;
        temp.y = 0;

        transform.position = temp.normalized * distFromPlayer;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }

    public void Hover(bool hover)
    {
        if (hover)
        {
            normal.SetActive(false);
            hoverObj.SetActive(true);
        }
        else
        {
            hoverObj.SetActive(false);
            normal.SetActive(true);
        }
    }

    public void Fade()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(timeBeforeFadeOut);

        if(sr.Length!=0)
        {
            while (sr[0].color != Color.clear)
            {
                foreach(SpriteRenderer sprite in sr)
                {
                    sprite.color = Color.Lerp(sprite.color, Color.clear, Time.fixedDeltaTime * fadeOutSpeed);
                    //text.color =SetButtonStatics(false); Color.Lerp(text.color, Color.clear, Time.fixedDeltaTime * fadeOutSpeed);
                }

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
