using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class logData : MonoBehaviour
{
    public StreamWriter eventWriter;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("dataPath: " + Application.persistentDataPath);
        eventWriter = new StreamWriter(Application.persistentDataPath + "/pediLogFile.txt", true); // append to existing file
        DateTime dateCurrent = DateTime.Now;
        eventWriter.WriteLine("[" + dateCurrent.ToString() + "] " + "NEW SESSION STARTED"); // output the msg with a timestamp
        eventWriter.Close();
    }


    void OnApplicationQuit()
    {
        //eventWriter = new StreamWriter(Application.persistentDataPath + "/pediLogFile.txt", true); // append to existing file
        //DateTime dateCurrent = DateTime.Now;
        //eventWriter.WriteLine("[" + dateCurrent.ToString() + "] " + "SESSION ENDED"); // output the msg with a timestamp
        //eventWriter.Close();
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            eventWriter = new StreamWriter(Application.persistentDataPath + "/pediLogFile.txt", true); // append to existing file
            DateTime dateCurrent = DateTime.Now;
            eventWriter.WriteLine("[" + dateCurrent.ToString() + "] " + "SESSION ENDED"); // output the msg with a timestamp
            eventWriter.Close();
        } else
        {
            eventWriter = new StreamWriter(Application.persistentDataPath + "/pediLogFile.txt", true); // append to existing file
            DateTime dateCurrent = DateTime.Now;
            eventWriter.WriteLine("[" + dateCurrent.ToString() + "] " + "SESSION UNPAUSED"); // output the msg with a timestamp
            eventWriter.Close();
        }
    }

    public void writeLine(string input)
    {
        eventWriter = new StreamWriter(Application.persistentDataPath + "/pediLogFile.txt", true); // append to existing file
        DateTime dateCurrent = DateTime.Now;
        eventWriter.WriteLine("["+dateCurrent.ToString() + "] " + input); // output the msg with a timestamp
        eventWriter.Close();
    }
}
