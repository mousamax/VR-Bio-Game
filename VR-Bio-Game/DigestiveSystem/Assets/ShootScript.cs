using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject Bullet;
    private List<GameObject> _gObjList = new List<GameObject>();

    private const float _mouseSpeed = 3f;
    private float _y = 0f;
    private float _x = 0f;

    private Vector3 _fireOffset = new Vector3(-1f, 0f, 0f);
    private const int _bulletSpeed = 150;

    public Canvas can;

    public GameObject gun;
    private Vector3 _gunOffset = new Vector3(0f,-0.75f,0f);

    private short _bulletType = 1;
    //1 --> Pepsin



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    //Left mouse button
        {
            //Primary key
            try
            {
                _fireOffset = this.transform.position + 1.5f * this.transform.forward;
                //_gObjList.Add(Instantiate(Bullet, _fireOffset, Quaternion.LookRotation(this.transform.forward, Vector3.up)));
                //_gObjList[_gObjList.Count - 1].gameObject.GetComponent<Rigidbody>().AddForce(_bulletSpeed * this.transform.forward);
            }
            catch
            {
                Debug.Log("Error firing");
            }
        }

        _x -= _mouseSpeed * Input.GetAxis("Mouse Y");
        _y += _mouseSpeed * Input.GetAxis("Mouse X");

        this.transform.eulerAngles = new Vector3(_x, _y, 0f);

        gun.gameObject.transform.position = this.gameObject.transform.position + _gunOffset;//+ this.gameObject.transform.forward.normalized;
        gun.gameObject.transform.forward = this.gameObject.transform.forward;
    }
}
