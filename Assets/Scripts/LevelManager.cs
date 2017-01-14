using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public GameObject tilePrefab;
	public string filename;
	public int levelWidth { get; private set; }
	public int levelHeight { get; private set; }

    private char[,] levelData;

    void Awake()
    {
        Load();
        createLevel();
    }

	private bool Load()
	{
		StreamReader theReader = new StreamReader(filename, Encoding.Default);

		using (theReader)
		{
			string line;

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
				GameObject tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
				tile.transform.parent = this.transform;

				switch (levelData[x,y])
				{
				case 'P':
					tile.GetComponent<Tile>().setTile(Tile.tileType.PATH);
					break;
				default:
					tile.GetComponent<Tile>().setTile(Tile.tileType.GROUND);
					break;
				}
			}
		}
	}
}
