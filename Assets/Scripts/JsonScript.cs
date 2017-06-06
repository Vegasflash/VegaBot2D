using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonScript : MonoBehaviour
{

    ArrayList array = new ArrayList();

    private void Start()
    {
        array.Add(0);
        array.Add(1);
        array.Add(2);
        array.Add(3);
        array.Add(4);
        array.Add(5);
        array.Add(6);

        string sEncode = MiniJSON.jsonEncode(array);
        Debug.Log(sEncode);

        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("1", "a");
        dict.Add("2", "b");
        dict.Add("3", "c");
        dict.Add("4", "d");
        dict.Add("5", "e");
        dict.Add("6", "f");

        sEncode = MiniJSON.jsonEncode(dict);
        Debug.Log(sEncode);

        Hashtable dictDecode = MiniJSON.jsonDecode(sEncode) as Hashtable;
        Debug.Log(dictDecode["2"].ToString());

        // Decode 
        string sDecode = "[1,2,3,4,5,6]";
        ArrayList l = MiniJSON.jsonDecode(sDecode) as ArrayList;
        foreach (object o in l)
        {
            Debug.Log(o.ToString());
        }


    }
        /*
         
         int bestScore = 100
         if(PlayerPrefs.HasKey("BestScore"))
         {
            bestScore = PlayerPrefs.GetInt("BestScore")
         }

        bestScore = 100;
        
        PlayerPrefs.SetInt("BestScore", bestScore);

        */

    
    
}





