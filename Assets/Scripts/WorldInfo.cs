using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldInfo
{
    private static string seed = "hello";
    private static int difficulty = 0;


    public static void SetSeed(string s) { 
        seed = s;
    }
    public static string GetSeed() { return seed;}

    public static int GetDifficulty() {  return difficulty;}

    public static void SetDifficulty(int d)
    {
        difficulty = d;
    }
}
