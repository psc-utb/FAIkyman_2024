using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    [SerializeField]
    GameObject weapon;

    public void WeaponEnable()
    {
        if(weapon != null)
            weapon.SetActive(true);
    }

    public void WeaponDisable()
    {
        if (weapon != null)
            weapon.SetActive(false);
    }
}
