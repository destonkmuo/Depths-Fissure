using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CameraFading;

public class PlayerController: MonoBehaviour {

    [SerializeField] private float movementSpeed;
    public float cooldownTime = 2;
    private float nextFireTime = 0;
    private float jumpHeight = 7;
    public bool rotationEnable = true;
    public bool movementEnable = true;
    public bool rotationEnable1 = true;
    public bool movementEnable1 = true;
    public GameObject Mastery;
    public bool MasteryActive = false;
    public Vector3 spawnLocation = new Vector3(-8, 1, 1);
    public float sprintSpeed = 1f;
    public Text text;
    public GameObject StaminaBar;
    public SkillsAndLevels SL;
    void Start() {
        CameraFade.Out(0f);
        CameraFade.In(6f);
        SL = SL.GetComponent<SkillsAndLevels>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            text.transform.LeanMoveLocal(new Vector2(-50, -700), 1.5f).setEaseOutQuart();
        }
        movementSpeed = 3;
        if (movementEnable && movementEnable1) {
            HandleMovementInput();
        }
        if (rotationEnable && rotationEnable1) {
            HandleRotationInput();
        }
        if(Input.GetKeyDown("o") && !MasteryActive) {
            Mastery.SetActive(true);
            MasteryActive = true;
        } else if(Input.GetKeyDown("o") && MasteryActive) {
            MasteryActive = false;
            Mastery.SetActive(false);
        }
    }

    void HandleMovementInput() {

        if (Time.time > nextFireTime) { // Jump
            if (Input.GetKeyDown(KeyCode.Space)) {
                GetComponent < Rigidbody > ().AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
                nextFireTime = Time.time + cooldownTime;
            }
        }

        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        Vector3 _movement = new Vector3(_horizontal, 0, _vertical);

        if (Input.GetKey(KeyCode.LeftShift) && StaminaBar.transform.localScale.x > 0) {
            sprintSpeed = 2f * 1 + SL.agiVal * .025f;
            if(sprintSpeed > 10) {
                sprintSpeed = 10;
            }
            StaminaBar.transform.localScale = new Vector3(StaminaBar.transform.localScale.x - .001f, 1, 1); // Add agility buffs/debuffs here

        }
        if (!Input.GetKey(KeyCode.LeftShift) && StaminaBar.transform.localScale.x < 1) {
            sprintSpeed = 1f;
            StaminaBar.transform.localScale = new Vector3(StaminaBar.transform.localScale.x + .0008f, 1, 1); // Add agility buffs/debuffs here
        }
        if (StaminaBar.transform.localScale.x > 1) {
            StaminaBar.transform.localScale = new Vector3(1, 1, 1);
        }
        if (StaminaBar.transform.localScale.x < 0) {
            StaminaBar.transform.localScale = new Vector3(0, 1, 1);
        }
        transform.Translate(_movement * movementSpeed * Time.deltaTime * sprintSpeed, Space.World);

        if (Input.GetKey("w")) {
            Vector3 v3 = new Vector3(0,0,0);
            LeanTween.rotate(gameObject, v3, .15f);
        }
        if (Input.GetKey("a")) {
            Vector3 v3 = new Vector3(0, 270, 0);
            LeanTween.rotate(gameObject, v3, .15f);
        }
        if (Input.GetKey("s")) {
            Vector3 v3 = new Vector3(0,-180,0);
            LeanTween.rotate(gameObject, v3, .15f);
        }
        if (Input.GetKey("d")) {
            Vector3 v3 = new Vector3(0,90,0);
            LeanTween.rotate(gameObject, v3, .15f);
        }
        if (Input.GetKey("w") && Input.GetKey("a")) {
            Vector3 v3 = new Vector3(0,315,0);
            LeanTween.rotate(gameObject, v3, .15f);
        }
        if (Input.GetKey("w") && Input.GetKey("d")) {
            Vector3 v3 = new Vector3(0,45,0);
            LeanTween.rotate(gameObject, v3, .15f);
        }
        if (Input.GetKey("s") && Input.GetKey("a")) {
            Vector3 v3 = new Vector3(0,225,0);
            LeanTween.rotate(gameObject, v3, .15f);
        }
        if (Input.GetKey("s") && Input.GetKey("d")) {
            Vector3 v3 = new Vector3(0,130,0);
            LeanTween.rotate(gameObject, v3, .15f);
        }
    }

    void HandleRotationInput() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(ray, out rayLength)) {
            Vector3 targetPosition = ray.GetPoint(rayLength);
            Vector3 targetDir = targetPosition - transform.position;
            targetDir.y = 0;
            float step = 25 * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);

            transform.rotation = Quaternion.LookRotation(newDir);

            //transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "item") {
            text.transform.LeanMoveLocal(new Vector2(0, -350), 1.5f).setEaseOutQuart();
            GameObject itemPickedUp = other.gameObject;
            ItemScript item = itemPickedUp.GetComponent<ItemScript>();
            text.text = "PRESS E TO PICK UP " + item.description.ToUpper() + "";
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "item") {
            text.transform.LeanMoveLocal(new Vector2(0, -700), 1.5f).setEaseOutQuart();
            text.text = "";
        }
    }
}

