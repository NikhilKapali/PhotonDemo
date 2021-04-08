using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPun
{
    public float Movespeed = 3.5f;
    public float Turnspeed = 120f;
    private TextMesh PlayerText = null;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < this.transform.childCount; i++){
            if(this.transform.GetChild(i).name=="PlayerText")
            {
                PlayerText = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                PlayerText.text = string.Format("Player{0}", photonView.ViewID);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine == true) {
            {
                Controls();
            }
        }
    }
    private void Controls(){
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.forward * vert * Movespeed * Time.deltaTime);
        this.transform.localRotation *= Quaternion.AngleAxis(horz * Turnspeed * Time.deltaTime, Vector3.up);
    }
}
