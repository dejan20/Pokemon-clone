using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Inventory", menuName = "Inventory SYS/INV" )]
public class PlayerINV : ScriptableObject  
{
    public List<InvSlot> Container = new List<InvSlot>();
    public void AddItem(invITEMS _item, int _amount)
    {
        bool hasitem = false;
        for (int i =0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasitem = true;
                break;
            }

        }
        if (!hasitem)
        {
            Container.Add(new InvSlot(_item, _amount));
        }
    }

}

[System.Serializable]
public class InvSlot
{
    public invITEMS item;
    public int amount;
    public InvSlot(invITEMS _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
