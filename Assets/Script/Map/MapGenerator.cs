using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth = 50;
    public int mapHeight = 50;
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public float cellSize = 0.16f; // Set the cell size for both x and y coordinates
    public int seed;
    public int minRoomSize = 3;
    public int maxRoomSize = 7;
    public int roomCount = 5;

    private List<Rect> rooms;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        Random.InitState(seed);
        int[,] map = new int[mapWidth, mapHeight];
        rooms = new List<Rect>();

        // Generate rooms
        for (int i = 0; i < roomCount; i++)
        {
            Rect newRoom;
            bool overlaps;
            do
            {
                overlaps = false;
                int roomWidth = Random.Range(minRoomSize, maxRoomSize);
                int roomHeight = Random.Range(minRoomSize, maxRoomSize);
                int roomX = Random.Range(1, mapWidth - roomWidth - 1);
                int roomY = Random.Range(1, mapHeight - roomHeight - 1);

                newRoom = new Rect(roomX, roomY, roomWidth, roomHeight);

                foreach (Rect room in rooms)
                {
                    if (newRoom.Overlaps(room))
                    {
                        overlaps = true;
                        break;
                    }
                }
            } while (overlaps);

            rooms.Add(newRoom);
            CreateRoom(map, newRoom);
        }

        // Connect rooms with corridors
        for (int i = 0; i < rooms.Count - 1; i++)
        {
            Rect currentRoom = rooms[i];
            Rect nextRoom = rooms[i + 1];
            ConnectRooms(map, currentRoom, nextRoom);
        }

        // Add walls around the rooms
        AddWalls(map);

        // Instantiate the map
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                GameObject prefab;
                if (map[x, y] == 1)
                {
                    prefab = floorPrefab;
                }
                else if (map[x, y] == 2)
                {
                    prefab = wallPrefab;
                }
                else
                {
                    continue;
                }
                Vector3 position = new Vector3(x * cellSize, y * cellSize, 0);
                Instantiate(prefab, position, Quaternion.identity);
            }
        }
    }

    void CreateRoom(int[,] map, Rect room)
    {
        for (int x = (int)room.x; x < room.xMax; x++)
        {
            for (int y = (int)room.y; y < room.yMax; y++)
            {
                map[x, y] = 1; // 1 represents the floor
            }
        }
    }

    void ConnectRooms(int[,] map, Rect roomA, Rect roomB)
    {
        Vector2 pointA = new Vector2(Random.Range((int)roomA.x, (int)roomA.xMax), Random.Range((int)roomA.y, (int)roomA.yMax));
        Vector2 pointB = new Vector2(Random.Range((int)roomB.x, (int)roomB.xMax), Random.Range((int)roomB.y, (int)roomB.yMax));

        int xStart = (int)pointA.x;
        int xEnd = (int)pointB.x;
        int yStart = (int)pointA.y;
        int yEnd = (int)pointB.y;

        // Create corridor from pointA to pointB
        while (xStart != xEnd)
        {
            map[xStart, yStart] = 1;
            xStart += xEnd > xStart ? 1 : -1;
        }

        while (yStart != yEnd)
        {
            map[xStart, yStart] = 1;
            yStart += yEnd > yStart ? 1 : -1;
        }
    }

    void AddWalls(int[,] map)
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (map[x, y] == 1)
                {
                    // Add walls around floors
                    if (x > 0 && map[x - 1, y] == 0) map[x - 1, y] = 2;
                    if (x < mapWidth - 1 && map[x + 1, y] == 0) map[x + 1, y] = 2;
                    if (y > 0 && map[x, y - 1] == 0) map[x, y - 1] = 2;
                    if (y < mapHeight - 1 && map[x, y + 1] == 0) map[x, y + 1] = 2;
                }
            }
        }
    }
}
