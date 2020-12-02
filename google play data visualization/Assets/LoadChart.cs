using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Application = DefaultNamespace.Application;
using Random = UnityEngine.Random;

public class LoadChart : MonoBehaviour
{
    public GameObject SpherePrefab;

    public Dictionary<CategoriesEnum, Color> CategoryToColor;
    // Start is called before the first frame update
    void Start()
    {
        CategoryToColor = new Dictionary<CategoriesEnum, Color>();
        CategoryToColor.Add(CategoriesEnum.GAME, Color.yellow);
        CategoryToColor.Add(CategoriesEnum.BEAUTY, Color.magenta);
        CategoryToColor.Add(CategoriesEnum.COMICS, Color.red);
        CategoryToColor.Add(CategoriesEnum.ART_AND_DESIGN, Color.green);
        CategoryToColor.Add(CategoriesEnum.BUSINESS, Color.blue);
        CategoryToColor.Add(CategoriesEnum.EDUCATION, Color.black);
        CategoryToColor.Add(CategoriesEnum.COMMUNICATION, Color.white);
        CategoryToColor.Add(CategoriesEnum.AUTO_AND_VEHICLES, new Color(0.6f, 0.7f, 1));
        CategoryToColor.Add(CategoriesEnum.BOOKS_AND_REFERENCE, Color.cyan);
        CategoryToColor.Add(CategoriesEnum.FAMILY, new Color(1, 0.40f, 0));
        CategoryToColor.Add(CategoriesEnum.OTHER, Color.gray);
        
        for (int i = 0; i < 1000; i++)
        {
            Application application = new Application()
            {
                Name = "App1",
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
            GameObject s1 = Instantiate(SpherePrefab);
            s1.transform.position = new Vector3(x, y, z);
            s1.GetComponent<MeshRenderer>().material.color = CategoryToColor[application.Category];
            s1.transform.localScale = new Vector3(application.Size / 10, application.Size / 10, application.Size / 10);
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
}
