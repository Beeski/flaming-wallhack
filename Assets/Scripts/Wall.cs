using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour 
{
	[SerializeField] private SpriteRenderer BrickPrefab;
	[SerializeField] private int NumPerRow;
	[SerializeField] private int NumRows;

	void Start() 
	{
		Build();
	}

	private void Build()
	{
		float w = BrickPrefab.sprite.bounds.size.x * BrickPrefab.transform.localScale.x;
		float h = BrickPrefab.sprite.bounds.size.y * BrickPrefab.transform.localScale.y;
		float start_x = ( ( NumPerRow ) * w ) * 0.5f;
		float start_y = ( ( NumRows - 1 ) * h ) * 0.5f;
		float x = 0.0f;
		float y = -start_y;

		for( int row = 0; row < NumRows; row++ )
		{
			x = -start_x + ( row % 2 == 0 ? 0 : w * 0.5f );
			for( int column = 0; column < NumPerRow; column++ )
			{
				SpriteRenderer s = Instantiate( BrickPrefab ) as SpriteRenderer;
				s.transform.position = new Vector3( x, y, 0.0f );
				x += w;
			}
			y += h;
		}
	}
}
