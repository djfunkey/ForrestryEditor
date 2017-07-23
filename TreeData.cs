public class TreeData : MonoBehaviour {
  
  public bool selected = false;
  public Gameobject prefab;
  public bool randomHeight = false;
  public bool randomWidth = false;
  
  private float heightMinLimit = 0f, heightMaxLimit = 1f;
  private float heightMinVal, heightMaxVal;
  private float widthMinLimit = 0f, widthMaxLimit = 1f;
  private float widthMinVal, widthMaxVal;
  
  public float GetHeight ()
  {
    float val = 0f;
    if (!randomHeight)
      val = 1f;
    else
      val = Random.Range(heightMinVal, heightMaxVal);
    return val;
  }
  
  public float GetWidth ()
  {
    float val = 0f;
    if (!randomWidth)
      val = 1f;
    else
      val = Random.Range(widthMinVal, widthMaxVal);
    return val;
  }
}
