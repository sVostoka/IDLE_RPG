using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Scriptable Objects/Items/Potion")]
public class Potion : Item, IUseble
{
    [Header("Characteristics")]
    public Property<int> healHP;

    public void Use()
    {
        GameController.s_Instance.CharacterController.HP += healHP.value;

        ResourceManager.s_Instance.Inventory.DeleteItem(this);
    }
}