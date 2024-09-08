
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using SimpleJSON;


namespace cfg
{
public partial class TbUICard
{
    private readonly System.Collections.Generic.Dictionary<int, UICard> _dataMap;
    private readonly System.Collections.Generic.List<UICard> _dataList;
    
    public TbUICard(JSONNode _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, UICard>();
        _dataList = new System.Collections.Generic.List<UICard>();
        
        foreach(JSONNode _ele in _buf.Children)
        {
            UICard _v;
            { if(!_ele.IsObject) { throw new SerializationException(); }  _v = UICard.DeserializeUICard(_ele);  }
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, UICard> DataMap => _dataMap;
    public System.Collections.Generic.List<UICard> DataList => _dataList;

    public UICard GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public UICard Get(int key) => _dataMap[key];
    public UICard this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

