
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
public partial class TbL10nGame
{
    private readonly System.Collections.Generic.Dictionary<string, L10nGame> _dataMap;
    private readonly System.Collections.Generic.List<L10nGame> _dataList;
    
    public TbL10nGame(JSONNode _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<string, L10nGame>();
        _dataList = new System.Collections.Generic.List<L10nGame>();
        
        foreach(JSONNode _ele in _buf.Children)
        {
            L10nGame _v;
            { if(!_ele.IsObject) { throw new SerializationException(); }  _v = L10nGame.DeserializeL10nGame(_ele);  }
            _dataList.Add(_v);
            _dataMap.Add(_v.L10nKey, _v);
        }
    }

    public System.Collections.Generic.Dictionary<string, L10nGame> DataMap => _dataMap;
    public System.Collections.Generic.List<L10nGame> DataList => _dataList;

    public L10nGame GetOrDefault(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public L10nGame Get(string key) => _dataMap[key];
    public L10nGame this[string key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}
