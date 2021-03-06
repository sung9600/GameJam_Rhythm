using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<float> _perfectTimes;
    public static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    void Start()
    {
        if(instance==null){
            instance= this;
        }
        StreamReader sr=new StreamReader($"{Application.dataPath}/Resource/csv/Notes.csv");
        bool _isEOF=false;
        while(!_isEOF){
            string data=sr.ReadLine();
            if(data==null){
                _isEOF=true;
                break;
            }
            var data_values = data.Split(',');
            _perfectTimes.Add(float.Parse(data_values[0]));
        }
        sr.Close();
        foreach(float a in _perfectTimes){
            Debug.Log(a);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
