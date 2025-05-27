using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    [SerializeField] private GameObject floorPlane;
    private MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = floorPlane.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.mainTextureOffset = new Vector2(0f, -Time.time * 3f);
    }
}
