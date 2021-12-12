using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class AssetItem :ScriptableObject, IItem
{
    public string Name => _name;
    public Sprite UIIcon => _uiIcon;

    public int Id => _id;

    [SerializeField]  string _name;
    [SerializeField]  Sprite _uiIcon;
    [SerializeField]  int _id;

}