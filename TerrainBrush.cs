using UnityEdtior;

public class TerrainBrush : MonoBehaviour {
  
  public float size = 1f;
  
  private Projector proj;
  private Material burshMat;
  private Texture2D brushTex;
  private RaycastHit hit;
  private int texWidth = 0;
  private int texHeight = 0;
  
  public void Init ()
  {
    proj.orthographic = true;
    proj.orthographicSize = 1f;
    proj.aspectRatio = 1f;
  }
  
  private void Update ()
  {
    Ray r = HandleUtility.GUIPointToWorldRay(Input.mousePosition);
    if (Physics.Raycast (r, out hit))
    {
      transform.position = hit.point;
    }
  }
  
  public void LoadBrush (Texture2D newBrush)
  {
    if (newBrush == brushTex)
      return;
    
    texWidth = newBrush.width;
    texHeight = newBrush.height;
    brushTex = newBrush;
    brushMat.mainTexture = brushTex;
  }
  
  public Vector3 GetRandTreePos ()
  {
    Vector3 pos = null;
    float x, y;
    float rVal = Random.value;
    
    do {
      // Get random vals [0.0 - 1.0]
      x = Random.value;
      y = Random.value;
      // Get pos for texture greyscale sampleing
      int texSampleX = (int)(x * texWidth);
      int texSampleY = (int)(y * texHeight);
      
    } while (GreyScaleAtPos(texSampleX, texSampleY) < rVal);
    
    float posX = x * proj.orthographicSize + hit.point.x;
    float posZ = y * proj.orthographicSize + hit.point.y;
    Vector3 samplePos = new Vector3 (posX, 0, posZ);
    float posY = Terrain.activeTerrain.SamplePosition (samplePos);
    pos = new Vector3 (posX, posY, posZ);
    
    return pos;
  }
  
  private float GreyScaleAtPos (int x, int y)
  {
    return brushTex.GetPixel(x, y).grayscale;
  }
}
