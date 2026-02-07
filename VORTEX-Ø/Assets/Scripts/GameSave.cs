using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class GameSave
{
    public int maxLevel = 1;
    public int deaths = 0;
    public bool[] stars;
}