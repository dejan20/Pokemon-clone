using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiritMoves : MonoBehaviour
{
    
    [SerializeField] ScriptableObject[] moves = new ScriptableObject[4];
    [SerializeField] Unit unit;

    void Start()
    {
        moves[0] = unit.spiritMoves[0];
        moves[1] = unit.spiritMoves[0];
        moves[2] = unit.spiritMoves[0];
        moves[3] = unit.spiritMoves[0];
    }
}
