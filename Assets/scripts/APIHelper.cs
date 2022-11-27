using UnityEngine;
using System.Net;
using System.IO;

public static class APIHelper
{
    public static Photo GetNewPhoto(int id)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/photos/" + id.ToString());
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        return JsonUtility.FromJson<Photo>(json);
    }

    // Test func
    public static Joke GetNewJoke()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.chucknorris.io/jokes/random");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        return JsonUtility.FromJson<Joke>(json);
    }
}
