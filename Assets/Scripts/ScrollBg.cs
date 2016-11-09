using UnityEngine;
using System.Collections;

public class ScrollBg : MonoBehaviour {

    public Transform[] arrayBackgrounds;
    private float[] parralaxScales;
    private float smoothing = 1f;
    private Transform cam;
    private Vector3 previousCamPos;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start() {
        previousCamPos = cam.position;
        parralaxScales = new float[arrayBackgrounds.Length];
        for (int i = 0; i < arrayBackgrounds.Length; i++)
        {
            parralaxScales[i] = arrayBackgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < arrayBackgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x  - cam.position.x) * parralaxScales[i];
            float backgroundTargetPosX = arrayBackgrounds[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, arrayBackgrounds[i].position.y, arrayBackgrounds[i].position.z);
            arrayBackgrounds[i].position = Vector3.Lerp(arrayBackgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
	}
}
