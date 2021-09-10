using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class O2_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 0.5f;
    [SerializeField] Color32 LightRed = new Color32(0xe2, 0x69, 0x69, 255);
    public AudioSource OxygenSound;
    public float offset = 0.06f;

    // Update is called once per frame
    void Start()
    {
        OxygenSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (this.tag == "BindedO2")
        {
            this.transform.position += this.transform.forward * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Blood")
        {
            OxygenSound.Play();
            collider.gameObject.GetComponent<Renderer>().material.color = LightRed;
            collider.gameObject.tag = "OxygenatedBlood";
            this.tag = "BindedO2";
            this.gameObject.tag = "BindedO2";
            Debug.Log("BindedO2\n");
            Vector3 o2_pos = collider.gameObject.transform.position;
            Vector3 o2_LookAt = collider.gameObject.transform.forward;
            o2_pos.y += (float)offset;
            o2_LookAt.y += (float)offset;
            this.transform.position = o2_pos;
            this.transform.LookAt(o2_LookAt);
            this.transform.forward = o2_LookAt;
        }

    }
}
