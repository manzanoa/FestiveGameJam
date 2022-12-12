using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField]
    bool isNice;

    [SerializeField]
    MeshRenderer aura;

    [SerializeField]
    Material niceAura, badAura;

    int presentsRequired;

    [SerializeField]
    UIMenuManager uI;

    // Start is called before the first frame update
    void Start()
    {

        if (isNice)
        {
            presentsRequired = 1;
            aura.material = niceAura;
        }
        else
        {
            presentsRequired = 0;
            aura.material = badAura;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if(other.CompareTag("Present"))
        {
            if(isNice)
            {
                ScoreKeeper.Add();
                uI.UpdateText();
                AdjustPresentsRequired();
            }
            else
            {
                ScoreKeeper.Subtract();
                uI.UpdateText();
            }

            Debug.Log(ScoreKeeper.GetScore());


            Destroy(other.gameObject);
        }
    }

    private void AdjustPresentsRequired()
    {
        presentsRequired--;

        if(presentsRequired <= 0)
        {
            presentsRequired = 0;
            this.gameObject.SetActive(false);
        }
    }
}
