using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBlocks : MonoBehaviour
{
    [SerializeField]
    GameObject main;

    [SerializeField]
    GameObject repeat;

    private int extend;

    public int Extend
    {
        get => extend;
    }

    public void Build(int extend)
    {
        this.extend = extend;
        
        //Block Batas Kiri Kanan
        for (int i = -1; i <= 1; i++)
        {
            if(i==0) continue;

            var m = Instantiate(main);
            m.transform.SetParent(this.transform);
            m.transform.localPosition = new Vector3((extend+1)*i,0,0);
            m.transform.GetComponentInChildren<Renderer>().material.color *= Color.grey;

        }

        //Block Utama
        main.transform.localScale = new Vector3(
            extend * 2 + 1,
            main.transform.localScale.y,
            main.transform.localScale.z
        );

        //Repeat
        if (repeat == null)
            return;

        for (int x = -(extend+1); x <= extend+1; x++)
        {
            if (x == 0)
                continue;

            var r = Instantiate(repeat);
            r.transform.SetParent(this.transform);
            r.transform.localPosition = new Vector3(x, 0, 0);
        }
    }
}
