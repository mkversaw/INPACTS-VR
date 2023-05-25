using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


    public class logData : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("dataPath: " + Application.persistentDataPath);
            StreamWriter eventWriter = new StreamWriter(Application.persistentDataPath + "/pediLogFile.txt", true); // append to existing file
            eventWriter.WriteLine("[" + DateTime.Now.ToString() + "] " + "NEW SESSION STARTED"); // output the msg with a timestamp
            eventWriter.Close();
        }

        void OnApplicationPause(bool pause)
        {
            if (pause) // game is paused, but on the Quest this is actually the game being quit (kinda?)
            {
                StreamWriter eventWriter = new StreamWriter(Application.persistentDataPath + "/pediLogFile.txt", true); // append to existing file
                eventWriter.WriteLine("[" + DateTime.Now.ToString() + "] " + "SESSION ENDED"); // output the msg with a timestamp
                eventWriter.Close();
            }
            else // game is actually paused
            {
                StreamWriter eventWriter = new StreamWriter(Application.persistentDataPath + "/pediLogFile.txt", true); // append to existing file
                eventWriter.WriteLine("[" + DateTime.Now.ToString() + "] " + "SESSION UNPAUSED"); // output the msg with a timestamp
                eventWriter.Close();
            }
        }

        public static void writeLine(string input)
        {
            StreamWriter eventWriter = new StreamWriter(Application.persistentDataPath + "/pediLogFile.txt", true); // append to existing file
            eventWriter.WriteLine("[" + DateTime.Now.ToString() + "] " + input); // output the msg with a timestamp
            eventWriter.Close();
        }
    }
