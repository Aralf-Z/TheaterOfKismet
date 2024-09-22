
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
public partial class TbUICfg
{
    private readonly System.Collections.Generic.Dictionary<string, UICfg> _dataMap;
    private readonly System.Collections.Generic.List<UICfg> _dataList;
    
    public TbUICfg(JSONNode _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<string, UICfg>();
        _dataList = new System.Collections.Generic.List<UICfg>();
        
        foreach(JSONNode _ele in _buf.Children)
        {
            UICfg _v;
            { if(!_ele.IsObject) { throw new SerializationException(); }  _v = UICfg.DeserializeUICfg(_ele);  }
            _dataList.Add(_v);
            _dataMap.Add(_v.Menus, _v);
        }
    }

    public System.Collections.Generic.Dictionary<string, UICfg> DataMap => _dataMap;
    public System.Collections.Generic.List<UICfg> DataList => _dataList;

    public UICfg GetOrDefault(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public UICfg Get(string key) => _dataMap[key];
    public UICfg this[string key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}
