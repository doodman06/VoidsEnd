using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveGameSystem
{
    public static bool SaveGame(SaveData saveGame, string name)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        using(FileStream stream = new FileStream(GetSavePath(name), FileMode.Create))
        {
            try
            {
                formatter.Serialize(stream, saveGame);
            }
            catch (Exception)
            {
                return false;
            }
        }

        return true;
    }

    public static bool DeleteSaveGame(string name)
    {
        try
        {
            File.Delete(GetSavePath(name));
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    public static SaveData LoadGame(string name)
    {
        if(!DoesSaveExist(name))
        {
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        using(FileStream stream = new FileStream(GetSavePath(name), FileMode.Open))
        {
            try
            {
                return formatter.Deserialize(stream) as SaveData;
                
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public static bool DoesSaveExist(string name)
    {
        return File.Exists(GetSavePath(name));
    }

    private static string GetSavePath(string name)
    {
        return Path.Combine(Application.persistentDataPath, name + ".sav");
    }

}
