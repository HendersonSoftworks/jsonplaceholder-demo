using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChuckNorris : MonoBehaviour
{
    private void Start()
    {
        //NewJoke();
        //NewPhoto();
    }

    public void NewJoke()
    {
        Joke j = APIHelper.GetNewJoke();
        Debug.Log(j.value);
    }

    public void NewPhoto()
    {
        Photo p = APIHelper.GetNewPhoto(1);
        Debug.Log(p.title);
    }
}
