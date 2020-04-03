using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    // Start is called before the first frame update
    public float scroll_speed = 0.3f;
    private MeshRenderer mesh_Renderer;

    void Awake(){

        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll(){
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scroll_speed;

        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
