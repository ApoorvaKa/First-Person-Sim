using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public Material lightMat;
    Material defaultMat;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        defaultMat = rend.material;
    }
     private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("bullet")){
            rend.material = lightMat;
            StartCoroutine(Revert());
        }
     }

    // Update is called once per frame
    IEnumerator Revert(){
        yield return new WaitForSeconds(.1f);
        rend.material = defaultMat;
    }
}
