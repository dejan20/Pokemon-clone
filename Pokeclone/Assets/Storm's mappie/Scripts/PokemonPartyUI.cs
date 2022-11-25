using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonPartyUI : MonoBehaviour
{
    //[SerializeField] List<GameObject> spiritImages;
    [SerializeField] GameObject[] spiritImages;
    [SerializeField] PokemonParty pokemonParty;
    Image newSpiritImage;
    Image spiritImage;
    [SerializeField] private Sprite TestImage;
    //[SerializeField] private Image FirstImageTest;
    //public Sprite sprite;





    void Start()
    {
        //FirstImageTest =  spiritImages[0].GetComponent<Image>();
        //newSpiritImage =  spiritImages[0].GetComponent<Image>();
        
        
    }

    public void SpiritPartyImages(int i)
    {
        print(i);
        newSpiritImage = spiritImages[i].GetComponent<Image>();
        spiritImage = pokemonParty.spiritList[i].GetComponent<Image>();
        
        newSpiritImage.sprite = spiritImage.sprite;

        Debug.Log("Adding spirit");
    }
}
