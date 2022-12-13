using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiritPartyUI : MonoBehaviour
{
    [SerializeField] GameObject[] spiritImages;
    [SerializeField] SpiritParty spiritParty;
    Image newSpiritImage;
    Image spiritImage;
    [SerializeField] private Sprite TestImage;

    public void SpiritPartyImages(int i)
    {
        print(i);
        newSpiritImage = spiritImages[i].GetComponent<Image>();
        spiritImage = spiritParty.spiritList[i].GetComponent<Image>();
        
        newSpiritImage.sprite = spiritImage.sprite;
        i++;

        Debug.Log("Adding spirit");
    }
}
