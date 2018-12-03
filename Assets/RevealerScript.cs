using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealerScript : MonoBehaviour
{

    public Material revealMat;

    private string dissolvePropertyString = "Vector1_ADE1DB20";

    private Coroutine revealRoutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (revealRoutine == null && revealMat != null)
        {
            float currentDissolveValue = revealMat.GetFloat(dissolvePropertyString);
            if (currentDissolveValue == 1 && GUILayout.Button("Reveal shader"))
            {
                revealRoutine = StartCoroutine(Reveal());
            }
            if (currentDissolveValue == 0 && GUILayout.Button("Unveil shader"))
            {
                revealRoutine = StartCoroutine(Unveil());
            }
        }
    }

    private IEnumerator Reveal() {

        while (revealMat.GetFloat(dissolvePropertyString) > 0)
        {
            float newValue = revealMat.GetFloat(dissolvePropertyString) - 0.006f;
            revealMat.SetFloat(dissolvePropertyString, newValue);
            yield return 0;
        }
        revealMat.SetFloat(dissolvePropertyString, 0);
        revealRoutine = null;
    }
    private IEnumerator Unveil()
    {
        while (revealMat.GetFloat(dissolvePropertyString) < 1)
        {
            float newValue = revealMat.GetFloat(dissolvePropertyString) + 0.006f;
            revealMat.SetFloat(dissolvePropertyString, newValue);
            yield return 0;
        }
        revealMat.SetFloat(dissolvePropertyString, 1);
        revealRoutine = null;
    }
}
