using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour {
    public bool inventoryEnabled = false;
    public GameObject inventory;

    [HideInInspector]
    public int allSlots;
    private int enabledSlots;

    [HideInInspector]
    public GameObject[] slot;
    public GameObject slotHolder;
    public CameraController cameraScript;
    public PlayerController playerScript;

    public GameObject Player;
    public Camera mainCamera;

    public GameObject HealthBar;

    public bool weaponSlotUsed = false;
    public bool utility1SlotUsed = false;
    public bool utility2SlotUsed = false;

    void Start()
    {
        LeanTween.init(1000000);
        allSlots = 36;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++) {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item == null) {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
        playerScript = playerScript.GetComponent<PlayerController>();
        cameraScript = cameraScript.GetComponent<CameraController>();
    }
    private float limit = 3f;
    public float coolDown = .5f;
    public float cooldownTimer = .5f;
    void Update()
    {
        ActivateInventory();
        if(playerScript.rotationEnable == false) {
            Player.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }

    void ActivateInventory()
    {
        //If user presses I, Open inventory
        if (Input.GetKeyDown(KeyCode.I) && limit == 0)
            inventoryEnabled = !inventoryEnabled;
        //Locks Specific User input when in inventory
        if (Input.GetKeyDown(KeyCode.I) && inventoryEnabled) {
            playerScript.rotationEnable = false;
            playerScript.movementEnable = false;
            Player.transform.rotation = Quaternion.Euler(0, -180, 0);
            mainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
            cameraScript.targetOffSet = new Vector3(-1.8f, 1.0f, -10);
        }
        //unlocking of previously stated  input when e is press again
        if (Input.GetKeyDown(KeyCode.I) && !inventoryEnabled) {
            playerScript.rotationEnable = true;
            playerScript.movementEnable = true;
            mainCamera.transform.rotation = Quaternion.Euler(20, 0, 0);
            cameraScript.targetOffSet = new Vector3(0, 10, -22);
        }
        // Vanity of Other UI
        if (inventoryEnabled == true) {
            HealthBar.SetActive(false);
            inventory.transform.LeanMoveLocal(new Vector2(-440, 0), 1.5f).setEaseOutQuart();
        } else {
            HealthBar.SetActive(true);
            inventory.transform.LeanMoveLocal(new Vector2(-440, -890), 1.5f).setEaseOutQuart();
            if (limit > 0) {
                limit -= Time.deltaTime;
            }
            if (limit < 0) {
                limit = 0f;
            }
            if (limit == 0 && Input.GetKeyDown(KeyCode.I)) {
                limit = 3f;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "item") {
            GameObject itemPickedUp = other.gameObject;
            ItemScript item = itemPickedUp.GetComponent<ItemScript>();
            if (Input.GetKeyDown(KeyCode.E)) {
                    AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
            }
        }
    }

    void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++) {
            if (slot[i].GetComponent<Slot>().empty) {
                itemObject.GetComponent<ItemScript>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject; // Check All of these to make sure it is the correct removal when making the for loop
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false; // Set equal to true if you want add another item in there
                return;
            }
        }
    }
}
