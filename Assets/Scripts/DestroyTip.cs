using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyObj());
    }

    public IEnumerator destroyObj()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
