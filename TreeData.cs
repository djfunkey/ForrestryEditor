public class TreeData : MonoBehaviour {
  
  public bool selected = false;
  public Gameobject prefab;
  public bool randomHeight = false;
  public bool randomWidth = false;
  public bool randomRotation = false;
  
  private float heightMinLimit = 0f, heightMaxLimit = 1f;
  private float heightMinVal, heightMaxVal;
  private float widthMinLimit = 0f, widthMaxLimit = 1f;
  private float widthMinVal, widthMaxVal;
  private float depth = 0f;r
  
  public bool IsEqual (TreePrototype tree) { return tree.prefab == prefab; }
  public float GetHeight () { return (randomHeight) ? Random.Range (heightMinVal, heightMaxVal) : 1f; }  
  public float GetWidth () { return (randomWidth) ? Random.Range(widthMinVal, widthMaxVal) : 1f; }  
  public float GetRotation () { return (randomRotation) ? Random.value * 360 : 1f; }
}
