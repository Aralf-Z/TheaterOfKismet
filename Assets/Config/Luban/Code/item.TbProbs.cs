
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using SimpleJSON;


namespace cfg.item
{
public partial class TbProbs
{
    private readonly System.Collections.Generic.Dictionary<int, Probs> _dataMap;
    private readonly System.Collections.Generic.List<Probs> _dataList;
    
    public TbProbs(JSONNode _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, Probs>();
        _dataList = new System.Collections.Generic.List<Probs>();
        
        foreach(JSONNode _ele in _buf.Children)
        {
            Probs _v;
            { if(!_ele.IsObject) { throw new SerializationException(); }  _v = Probs.DeserializeProbs(_ele);  }
            _dataList.Add(_v);
            _dataMap.Add(_v.ProbLv, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, Probs> DataMap => _dataMap;
    public System.Collections.Generic.List<Probs> DataList => _dataList;

    public Probs GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Probs Get(int key) => _dataMap[key];
    public Probs this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

