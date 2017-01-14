using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

public class LvlManager : MonoBehaviour {
    private char[,] levelData;
    private int levelWidth;
    private int levelHeight;

    public GameObject tilePreFab;

    private bool Load(string fileName)
    {
        string line;
        // Create a new StreamReader, tell it which file to read and what encoding the file
        // was saved as
        StreamReader theReader = new StreamReader(fileName, Encoding.Default);
        // Immediately clean up the reader after this block of code is done.
        // You generally use the "using" statement for potentially memory-intensive objects
        // instead of relying on garbage collection.
        // (Do not confuse this with the using directive for namespace at the 
        // beginning of a class!)
        using (theReader)
        {
            line = theReader.ReadLine();
            levelWidth = int.Parse(line);
            line = theReader.ReadLine();
            levelHeight = int.Parse(line);

            levelData = new char[levelWidth, levelHeight];

            for (int rowNo = 0; rowNo < levelHeight; rowNo++)
            {
                char[] chars = theReader.ReadLine().ToCharArray();
                for (int i = 0; i < levelWidth; i++)
                {
                    levelData[i, rowNo] = chars[i];
                }
            }

            theReader.Close();
            return true;
        }
    }
    private void createLevel()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for(int y = 0; y < levelHeight; y++)
            {
                GameObject tile = Instantiate(tilePreFab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                switch (levelData[x,y])
                {
                    case 'P':
                        tile.GetComponent<Tile>().setTile(Tile.tileType.PATH);
                        break;
                    default:
                        // create ground tile
                        tile.GetComponent<Tile>().setTile(Tile.tileType.GROUND);
                        break;
                }
            }
        }
    }

    private void Awake()
    {
        Load("Assets/Levels/Level1.txt");
        createLevel();
    }

    // Use this for initialization
    void Start () {
		
	}
	
}
