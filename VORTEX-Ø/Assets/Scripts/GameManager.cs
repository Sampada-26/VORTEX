using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int maxLevel = 1;
    public static int deaths;
    public static int number_of_levels = 8;
    public static bool[] stars = new bool[number_of_levels];

    public static void SaveGame()
    {
        GameSave gameSave = new GameSave();
        gameSave.maxLevel = maxLevel;
        gameSave.stars = stars;
        gameSave.deaths = deaths;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save_game.dat");
        bf.Serialize(file, gameSave);
        file.Close();
    }

    public static GameSave LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/save_game.dat"))
        {
            try {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/save_game.dat", FileMode.Open);
                GameSave gs = (GameSave)bf.Deserialize(file);
                file.Close();
                maxLevel = gs.maxLevel;
                stars = gs.stars;
                deaths = gs.deaths;
            } catch (System.Exception ) {
                return defaultGameSave();
            }
        }
        return defaultGameSave();
    }

    public static GameSave defaultGameSave()
    {
        GameSave gs = new GameSave();
        gs.maxLevel = 1;
        gs.stars = stars;
        gs.deaths = 0;
        return gs;
    }
}
