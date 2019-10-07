using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCoroutine : DebugClass
{
    public  Text info;
    private IEnumerator coroutine;
    private int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        coroutine = DropBombes();
        StartCoroutine(coroutine);
    }

	private IEnumerator DropBombes () 
	{
        while (true)
        {
            cnt++;
            info.text = cnt.ToString();
            yield return new WaitForSeconds(1.0f);
        }
    }
}
