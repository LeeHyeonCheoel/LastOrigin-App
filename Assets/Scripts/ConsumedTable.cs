using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

[System.Serializable]
public class Consumed
{
    public int part;       // 부품
    public int nutrition;  // 영양
    public int energy;     // 전력

    public Consumed(int _part,int _nutrition, int _energy)
    {
        part = _part;
        nutrition = _nutrition;
        energy = _energy;
    }
}

public class ConsumedTable
{
    static Dictionary<int,Consumed> consumeds = new Dictionary<int,Consumed>();

    public static Consumed SearchTable(eBioType _type, eBioRank _rank, eBioKinds _kind, bool _bFullRink)
    {

        // Culculate : eBioKinds * 12 + eBioType * 4 + eBioRank * 1 + _bFullRink * 36
        int index = (int)_kind * 12 + (int)_type * 4 + (int)_rank;
        // don't init
        if (consumeds.Count == 0)
        {
            // Salute Supporter
            consumeds.Add(0, new Consumed(16, 27, 5));
            consumeds.Add(1, new Consumed(13, 22, 4));
            consumeds.Add(2, new Consumed(10, 16, 3));
            consumeds.Add(3, new Consumed(7, 12, 2));
            
            // Salute Saver
            consumeds.Add(4, new Consumed(27, 27, 5));
            consumeds.Add(5, new Consumed(22, 22, 4));
            consumeds.Add(6, new Consumed(16, 16, 3));
            consumeds.Add(7, new Consumed(12, 12, 2));

            // Salute Attacker
            consumeds.Add(8, new Consumed(16, 27, 16));
            consumeds.Add(9, new Consumed(13, 22, 13));
            consumeds.Add(10, new Consumed(10, 16, 10));
            consumeds.Add(11, new Consumed(7, 12, 7));

            // Activation Supporter
            consumeds.Add(12, new Consumed(11, 27, 21));
            consumeds.Add(13, new Consumed(9, 22, 18));
            consumeds.Add(14, new Consumed(7, 16, 13));
            consumeds.Add(15, new Consumed(5, 12, 10));

            // Activation Saver
            consumeds.Add(16, new Consumed(21, 27, 21));
            consumeds.Add(17, new Consumed(18, 22, 18));
            consumeds.Add(18, new Consumed(13, 16, 13));
            consumeds.Add(19, new Consumed(10, 12, 10));

            // Activation Attacker
            consumeds.Add(20, new Consumed(11, 27, 32));
            consumeds.Add(21, new Consumed(9, 22, 26));
            consumeds.Add(22, new Consumed(7, 16, 20));
            consumeds.Add(23, new Consumed(5, 12, 15));


            // Heavy Supporter
            consumeds.Add(24, new Consumed(27, 27, 16));
            consumeds.Add(25, new Consumed(22, 22, 13));
            consumeds.Add(26, new Consumed(16, 16, 10));
            consumeds.Add(27, new Consumed(0, 0, 0));

            // Heavy Saver
            consumeds.Add(28, new Consumed(38, 27, 16));
            consumeds.Add(29, new Consumed(31, 22, 13));
            consumeds.Add(30, new Consumed(23, 16, 10));
            consumeds.Add(31, new Consumed(0, 0, 0));

            // Heavy Attacker
            consumeds.Add(32, new Consumed(27, 27, 27));
            consumeds.Add(33, new Consumed(22, 22, 22));
            consumeds.Add(34, new Consumed(16, 16, 16));
            consumeds.Add(35, new Consumed(0, 0, 0));
        }

        return consumeds[index];
    }
}
