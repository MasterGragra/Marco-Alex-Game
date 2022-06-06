using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private List<Heart> heartList;
  public HealthSystem(int HeartAmount)
    {
        heartList = new List<Heart>();

        for(int i = 0; i < HeartAmount; i++)
        {
            Heart heart = new Heart(0);
            heartList.Add(heart);
        }
    }

    public List<Heart> GetHeartList()
    {
        return heartList;
    }

    public class Heart
    {
        private int portion;
        public Heart(int portion)
        {
            this.portion = portion;
        }

        public int GetPortionAmount()
        {
            return portion;
        }
    }
}
