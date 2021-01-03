using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Reflection;
using UnityEngine.Networking;
using List = System.Collections.Generic;

public class MyTest{

    private List.List<GameObject> GameObjects { get; set; }
    
    [Test]
    public void TestNewObjectInstantiate()
    {

        GameObject gameObject = null;
        var prefab = Resources.Load("Prefabs/Sphere");
        if (prefab == null)
        {
            Assert.Fail();
        }
        else
        {
            gameObject = GameObject.Instantiate(prefab) as GameObject;
        }
        Assert.IsNotNull(gameObject);
    }

    [UnityTest]
    public IEnumerator TestGetRequest()
    {
        var uri = "https://mehranehjafari.ir/api/get_by_download?number=100&format=json";
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
                var response = webRequest.downloadHandler.text;
                Assert.That(webRequest.downloadHandler.text.Length > 0);

            }

            yield return null;
        }
    }
    
    
    public T InstantiateScript<T>() where T : MonoBehaviour

    {

        GameObject gameObject;

        object prefab = Resources.Load("Prefabs/" + typeof(T).Name);



        // If there is no prefab with the same name, just use an empty object

        //

        if (prefab == null)

        {

            gameObject = new GameObject();

        }

        else

        {

            gameObject = GameObject.Instantiate(Resources.Load("Prefabs/"

                                                               + typeof(T).Name)) as GameObject;

        }



        gameObject.name = typeof(T).Name + " (Test)";



        // Prefabs should already have the component

        T inst = gameObject.GetComponent<T>();

        if (inst == null)

        {

            inst = gameObject.AddComponent<T>();

        }



        // Call the start method to initialize the object

        //

        MethodInfo startMethod = typeof(T).GetMethod("Start");

        if (startMethod != null)

        {

            startMethod.Invoke(inst, null);

        }



        GameObjects.Add(gameObject);

        return inst;

    }



    public void CleanUp()

    {

        foreach (GameObject gameObject in GameObjects)

        {

            // Destroy() does not work in edit mode

            GameObject.DestroyImmediate(gameObject);

        }



        GameObjects.Clear();

    }

}
