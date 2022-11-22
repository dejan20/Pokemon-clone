using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonParty : MonoBehaviour
{

    //List<GameObject> spiritList;
    [SerializeField] public List<GameObject> spiritList;
    [SerializeField] private master master;
    [SerializeField] private PokemonPartyUI pokemonPartyUI;

    void Start()
    {
        spiritList = new List<GameObject>(5);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("You added a Spirit");
            spiritList.Add(master.allSpiritList[1]);
            pokemonPartyUI.SpiritPartyImages(0);
        }
        if (spiritList.Count > 5)
        {
            Debug.Log("Can't have more than 5 spirits!");
            spiritList.RemoveAt(5);
        }
    }
}
