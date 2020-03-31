using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPunCallbacks, IPunObservable

{
    private Vector2 mouseLook;
    public bool isGrounded;
    public float MouseSensitivity;
    public float MoveSpeed;
    private float JumpForce = 7f;
    private Light playerFlashLight;
    private Rigidbody Rigid;
    private Camera myCamera;
    private PhotonView PV;
    private bool flashLight = true;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Rigid = GetComponent<Rigidbody>();
        myCamera = GetComponentInChildren<Camera>();
        playerFlashLight = GetComponentInChildren<Light>();
        PV = GetComponent<PhotonView>();

        if (PV.IsMine)
        {
            myCamera.enabled = true;
        }
        else
        {
            myCamera.enabled = false;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            //stream.SendNext(playerFlashLight.enabled);
            stream.SendNext(GameSetup.spawnCounter);
        }
        else if (stream.IsReading)
        {
            //Network read this, others see
            //playerFlashLight.enabled = (bool) stream.ReceiveNext();
            GameSetup.spawnCounter = (int) stream.ReceiveNext();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // var ray = myCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myCamera.transform.position, myCamera.transform.TransformDirection(Vector3.forward),
                out var whatItHit, 1000))
            {
                var hitGameObject = whatItHit.transform.gameObject;
                var tagName = hitGameObject.tag;
                var objectName = hitGameObject.name;

                switch (tagName)
                {
                    case "Button":
                        hitGameObject.GetComponentInParent<ButtonScript>().Button_PressedR1(objectName);
                        break;
                    case "Button2":
                        hitGameObject.GetComponentInParent<ButtonScriptR2>().Button_pressedR2(objectName);
                        break;
                }
            }
        }

        BasicMovement();
        ToggleFlashLight();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void BasicMovement()
    {
        Rigid.MoveRotation(Rigid.rotation *
                           Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X"), 0) *
                                            MouseSensitivity)); //Kroppen snurrar därför gör kameran det också.
        Rigid.MovePosition(transform.position + Input.GetAxis("Vertical") * MoveSpeed * transform.forward +
                           Input.GetAxis("Horizontal") * MoveSpeed * transform.right); //Actual movement
        myCamera.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0f, 0f)); //Kamera upp och ner
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rigid.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void ToggleFlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashLight)
            {
                playerFlashLight.enabled = false;
                flashLight = false;
            }
            else
            {
                playerFlashLight.enabled = true;
                flashLight = true;
            }
        }
    }
}