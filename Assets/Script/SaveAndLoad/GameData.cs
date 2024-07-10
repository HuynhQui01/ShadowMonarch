using System;

[Serializable]
public class GameData
{
    public float[] position;
    public int coin;
    public Helmet helmet;
    public Chestplate chestplate;
    public Legging leggings;
    public Boots boots;
    

    public GameData(Player player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        this.coin = player.coin;
        this.helmet = player.Helmet;
        this.chestplate = player.Chestplate;
        this.leggings = player.Leggings;
        this.boots = player.Boots;
    }
}
