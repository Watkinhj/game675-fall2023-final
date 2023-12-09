using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    // script references
    [SerializeField] protected MonowireMovement hookScript;
    [SerializeField] protected MagneticBootMovement wallJumpScript;
    [SerializeField] protected IndustrialKnifeMovement meleeScript;
    [SerializeField] protected ThrusterPackMovement doubleJumpScript;

    // equipped bools
    protected bool monowireEquipped = false;
    protected bool magneticBootEquipped = false;
    protected bool industrialKnifeEquipped = false;
    protected bool thrusterPackEquipped = false;

    // list of implant gameobjects
    private List<string> implantObjects = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        hookScript.enabled = false;
        wallJumpScript.enabled = false;
        meleeScript.enabled = false;
        doubleJumpScript.enabled = false;
    }

    // if player collides with a tagged implant, its name is added to the list as a string
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Implant"))
        {
            AddToList(other.gameObject.name);
            Debug.Log(other.gameObject.name + " added to list");
            other.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // function to add implant name to list
    public void AddToList(string name)
    {
        if (!implantObjects.Contains(name))
        {
            implantObjects.Add(name);
        }
    }

    // detects if player has an implant equipped, and if so, toggles the corresponding script
    public void MonowireEquipped()
    {
        Debug.Log("MonowireEquipped() called");
        if (implantObjects.Contains("MonowireImplant"))
        {
            if (!monowireEquipped)
            {
                Debug.Log("Monowire Equipped");
                hookScript.enabled = true;
                monowireEquipped = true;
            }
            else
            {
                Debug.Log("Monowire Unequipped");
                hookScript.enabled = false;
                monowireEquipped = false;
            }
        }
    }

    public void MagneticBootEquipped()
    {
        Debug.Log("MagneticBootEquipped() called");
        if (implantObjects.Contains("MagneticBootImplant"))
        {
            if (!magneticBootEquipped)
            {
                Debug.Log("Magnetic Boot Equipped");
                wallJumpScript.enabled = true;
                magneticBootEquipped = true;
            }
            else
            {
                Debug.Log("Magnetic Boot Unequipped");
                wallJumpScript.enabled = false;
                magneticBootEquipped = false;
            }
        }
    }

    public void IndustrialKnifeEquipped()
    {
        Debug.Log("IndustrialKnifeEquipped() called");
        if (implantObjects.Contains("IndustrialKnifeImplant"))
        {
            if (!industrialKnifeEquipped)
            {
                Debug.Log("Industrial Knife Equipped");
                meleeScript.enabled = true;
                industrialKnifeEquipped = true;
            }
            else
            {
                Debug.Log("Industrial Knife Unequipped");
                meleeScript.enabled = false;
                industrialKnifeEquipped = false;
            }
        }
    }

    public void ThrusterPackEquipped()
    {
        Debug.Log("ThrusterPackEquipped() called");
        if (implantObjects.Contains("ThrusterPackImplant"))
        {
            if (!thrusterPackEquipped)
            {
                Debug.Log("Thruster Pack Equipped");
                doubleJumpScript.enabled = true;
                thrusterPackEquipped = true;
            }
            else
            {
                Debug.Log("Thruster Pack Unequipped");
                doubleJumpScript.enabled = false;
                thrusterPackEquipped = false;
            }
        }
    }
}
