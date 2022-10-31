using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    public int[] itemLista; 
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("inventario"))
        {
            itemLista = PlayerPrefsX.GetIntArray("inventario");
        }
        else
        {
            PlayerPrefsX.SetIntArray("inventario", itemLista);
            PlayerPrefs.Save();
        }
    }

  public void SetIten(int itemindex,int qtd)
    {
        itemLista[itemindex] += qtd;

        PlayerPrefsX.SetIntArray("inventario", itemLista);
        PlayerPrefs.Save();

    }
  public int GetItenQty(int itemindex)
    {
        itemLista=PlayerPrefsX.GetIntArray("inventario");

        return itemLista[itemindex];
    }

    public int GetIten(int itemindex)
    {
        if (PlayerPrefs.HasKey("inventario")) 
            itemLista = PlayerPrefsX.GetIntArray("inventario");


        itemLista[itemindex]--;

        PlayerPrefsX.SetIntArray("inventario", itemLista);
        PlayerPrefs.Save();
        return itemLista[itemindex];
    }
    public bool ChecktIten(int itemindex)
    {
        itemLista = PlayerPrefsX.GetIntArray("inventario");
        if (itemLista[itemindex] > 0)
            return true;

        return false;
    }
}
