using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationTransition : MonoBehaviour
{
    private bool testing;

    public Color colorChanging;

    public Color oldColor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!testing)
        {
            StarCreator.Constellations.TryGetValue(this.gameObject.name, out List<LineRenderer> lr);
            oldColor = (lr[0].material.color);
            testing = true;
            KillStarts();
        }
    }

    private void KillStarts()
    {

        StarCreator.Constellations.TryGetValue(this.gameObject.name, out List<LineRenderer> lr);
        bool isZero = false;
        do
        {
            for (int a = 0; a < lr.Count; a++)
            {
                if (lr[a].material.color.a > 0)
                {
                    colorChanging = lr[a].material.color;
                    colorChanging.a = colorChanging.a - .00005f;
                    lr[a].material.color = colorChanging;
                }
                else if (lr[a].material.color.a <= 0)
                {
                    colorChanging = lr[a].material.color;
                    colorChanging.a = 0;
                    lr[a].material.color = colorChanging;
                }
            }
            for (int a = 0; a < lr.Count; a++)
            {
                if (lr[a].material.color.a <= 0)
                {
                    isZero = true;
                }
                else
                {
                    isZero = false;
                    break;
                }
            }
        } while (!isZero);
    }
}
