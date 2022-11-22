using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonPartyUI : MonoBehaviour
{
    [SerializeField] List<GameObject> spiritImages;
    [SerializeField] PokemonParty pokemonParty;

    public void SpiritPartyImages(int i)
    {
        Debug.Log("Adding spirit");
        Image spiritImage = pokemonParty.spiritList[i].GetComponent<Image>();
        Image newSpiritImage = spiritImages[i].GetComponent<Image>();
        newSpiritImage = spiritImage;
        i++;
    }
}
