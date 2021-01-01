using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Application = DefaultNamespace.Application;
using Random = UnityEngine.Random;

public class LoadTopApps : MonoBehaviour
{
    private const int APPS_COUNT = 5;
    private Dictionary<CategoriesEnum, Color> categoryToColor;

    public GameObject cube;
    public GameObject appPanel; 
    public Text appText;
    public Text appDownloadNumber;
    // Start is called before the first frame update
    void Start()
    {
        MakeCategoriesDictionary();
        for (int i = 0; i < APPS_COUNT; i++)
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
            float yScale = application.Installs * 20 / 10000000;
            float x = -28 + (14 * i);
            float z = 20;
            float y = -14 + (yScale / 2);
            GameObject s1 = Instantiate(cube);
            s1.GetComponent<AppClick>().application = application;
            s1.GetComponent<AppClick>().appPanel = appPanel;
            s1.GetComponent<AppClick>().appText = appText;
            s1.GetComponent<AppClick>().appDownloadNumber = appDownloadNumber;

            s1.transform.position = new Vector3(x, y, z);
            s1.transform.localScale = new Vector3(7, yScale, 1);
            s1.GetComponent<MeshRenderer>().material.color = categoryToColor[application.Category];
        }
    }
    
    static System.Random _R = new System.Random ();
    static T RandomEnumValue<T> ()
    {
        var v = Enum.GetValues (typeof (T));
        return (T) v.GetValue (_R.Next(v.Length));
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
