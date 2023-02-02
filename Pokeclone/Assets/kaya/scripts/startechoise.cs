using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startechoise : MonoBehaviour
{

    
    public int tptoscene = 0;
    public SpiritParty spiritParty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void choise1()
    {
        spiritParty.firstSpirit = 1;

        spiritParty.AddSpirit();

        SceneManager.LoadScene(tptoscene);
    }

    public void choise2()
    {
        spiritParty.firstSpirit = 0;

        spiritParty.AddSpirit();

        SceneManager.LoadScene(tptoscene);
    }

    public void choise3()
    {
        spiritParty.firstSpirit = 4;

        spiritParty.AddSpirit();

        SceneManager.LoadScene(tptoscene);
    }
}
