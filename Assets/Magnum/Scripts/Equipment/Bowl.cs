using FoodSystem;
using UnityEngine;

public class Bowl : Equipment
{
    public override void Interact(Player player)
    {
        base.Interact(player);

        Tongs tongs;

        if (player.GetEquipment().TryGetComponent<Tongs>(out tongs) && tongs.TaiyakiObject != null)
        {
            tongs.TaiyakiObject.transform.SetParent(transform);

            if (transform.childCount > 0)
            {
                float x = 0.5f * transform.childCount - 1;

                tongs.TaiyakiObject.transform.localPosition = new Vector3(x, 0.21f, -0.05f);
                tongs.TaiyakiObject.transform.localRotation = Quaternion.Euler(-30, -90, 0);
            }

            else
            {
                tongs.TaiyakiObject.transform.localPosition = new Vector3(-0.5f, 0.21f, -0.05f);
                tongs.TaiyakiObject.transform.localRotation = Quaternion.Euler(-30, -90, 0);
            }


            tongs.Open();
            tongs.TaiyakiObject = null;
        }
    }

    public void SwitchToCounter()
    {
        
    }

    public FoodData GetFood()
    {
        return new FoodData();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    
}
