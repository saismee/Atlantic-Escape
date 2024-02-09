using UnityEngine;
using System.Collections;
using System;

public class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    // annoyingly, we can serialise this but not LeaderboardEntry[]
    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}