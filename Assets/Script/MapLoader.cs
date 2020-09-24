using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class MapLoader
{
    
    public MapLoader(string path)
    {
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            string str = reader.ReadToEnd();
            reader.Close();
        }
        else
        {
            throw new FileNotFoundException("No map found.");
        }
        
    }


}
