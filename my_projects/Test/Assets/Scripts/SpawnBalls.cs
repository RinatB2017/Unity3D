using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBalls : DebugClass
{
    public Rigidbody2D  prefab;
    public Text info;
    public float delay_sec = 1.5f;

    private int cnt = 0;
    private Vector3 m_NewForce;
    private IEnumerator coroutine;

    void Awake()
    {
        // https://docs.unity3d.com/ru/current/Manual/PlatformDependentCompilation.html
        #if UNITY_EDITOR
            debug_print("Unity Editor");
        #endif

        #if UNITY_EDITOR_WIN
            debug_print("Unity Editor Win");
        #endif

        #if UNITY_EDITOR_OSX
            debug_print("Unity Editor OSX");
        #endif
        
        #if UNITY_IOS
            debug_print("Unity iPhone");
        #endif
    
        #if UNITY_IPHONE
            debug_print("Iphone");
        #endif

        #if UNITY_ANDROID
            debug_print("Android");
        #endif

        #if UNITY_STANDALONE_OSX
            debug_print("Stand Alone OSX");
        #endif

        #if UNITY_STANDALONE_WIN
            debug_print("Stand Alone Windows");
        #endif 

        #if UNITY_STANDALONE_LINUX
            debug_print("Stand Alone Linux");
        #endif
    }

    void Start()
    {
        coroutine = DropBombes();
        StartCoroutine(coroutine);
    }

	private IEnumerator DropBombes () 
	{
        while (true)
        {
            Vector3 temp_vector = new Vector3(0, 0, 0);

            m_NewForce.x = Random.Range(-20.0f, 20.0f);
            m_NewForce.y = Random.Range(-20.0f, 20.0f);
            m_NewForce.z = 0;

            Rigidbody2D clone;
            clone = Instantiate(prefab, temp_vector, Quaternion.identity);
            clone.AddForce(m_NewForce, ForceMode2D.Impulse);

            cnt++;
            info.text = cnt.ToString();

            yield return new WaitForSeconds(delay_sec);
        }
    }

    void Update()
    {
        
    }
}
