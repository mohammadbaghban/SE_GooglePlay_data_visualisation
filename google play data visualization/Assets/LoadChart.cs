using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Application = DefaultNamespace.Application;
using Random = UnityEngine.Random;

public class LoadChart : MonoBehaviour
{
    public GameObject spherePrefab;
    public int countOfApps = 100;
    public GameObject appPanel; 
    public Text appText;
    public Text appDownloadNumber;
    
    public Dictionary<CategoriesEnum, Color> categoryToColor;
    // Start is called before the first frame update
    void Start()
    {
        MakeCategoriesDictionary();

        for (int i = 0; i < 1000; i++)
        {
            Application application = new Application()
            {
                Name = "App" + i,
                Category = RandomEnumValue<CategoriesEnum>(),
                Installs = Random.Range(100, 10000000),
                Price = Random.Range(0, 5),
                Rating = Random.Range(1, 5),
                Reviews = Random.Range(100, 100000),
                Size = Random.Range(2, 20)
            };
            float x = application.Price * 4;
            float z = application.Reviews * application.Rating / 8000;
            float y = application.Installs / 100000;
            GameObject s1 = Instantiate(spherePrefab);
            s1.GetComponent<AppClick>().application = application;
            s1.GetComponent<AppClick>().appPanel = appPanel;
            s1.GetComponent<AppClick>().appText = appText;
            s1.GetComponent<AppClick>().appDownloadNumber = appDownloadNumber;
            
            s1.transform.position = new Vector3(x, y, z);
            s1.GetComponent<MeshRenderer>().material.color = categoryToColor[application.Category];
            s1.transform.localScale = new Vector3(application.Size / 10, application.Size / 10, application.Size / 10);
        }

    }
   
    static System.Random _R = new System.Random ();
    static T RandomEnumValue<T> ()
    {
        var v = Enum.GetValues (typeof (T));
        return (T) v.GetValue (_R.Next(v.Length));
    }
    
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    void MakeCategoriesDictionary()
    {
        categoryToColor = new Dictionary<CategoriesEnum, Color>();
        categoryToColor.Add(CategoriesEnum.GAME, Color.yellow);
        categoryToColor.Add(CategoriesEnum.BEAUTY, Color.magenta);
        categoryToColor.Add(CategoriesEnum.COMICS, Color.red);
        categoryToColor.Add(CategoriesEnum.ART_AND_DESIGN, Color.green);
        categoryToColor.Add(CategoriesEnum.BUSINESS, Color.blue);
        categoryToColor.Add(CategoriesEnum.EDUCATION, Color.black);
        categoryToColor.Add(CategoriesEnum.COMMUNICATION, Color.white);
        categoryToColor.Add(CategoriesEnum.AUTO_AND_VEHICLES, new Color(0.6f, 0.7f, 1));
        categoryToColor.Add(CategoriesEnum.BOOKS_AND_REFERENCE, Color.cyan);
        categoryToColor.Add(CategoriesEnum.FAMILY, new Color(1, 0.40f, 0));
        categoryToColor.Add(CategoriesEnum.OTHER, Color.gray);
    }
}
