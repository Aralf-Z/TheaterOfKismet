
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
public sealed partial class UICard : Luban.BeanBase
{
    public UICard(JSONNode _buf) 
    {
        { if(!_buf["id"].IsNumber) { throw new SerializationException(); }  Id = _buf["id"]; }
        { if(!_buf["des_up_key"].IsString) { throw new SerializationException(); }  DesUpKey = _buf["des_up_key"]; }
        { if(!_buf["des_down_key"].IsString) { throw new SerializationException(); }  DesDownKey = _buf["des_down_key"]; }
        { if(!_buf["face_res"].IsString) { throw new SerializationException(); }  FaceRes = _buf["face_res"]; }
        { if(!_buf["frame_res"].IsString) { throw new SerializationException(); }  FrameRes = _buf["frame_res"]; }
    }

    public static UICard DeserializeUICard(JSONNode _buf)
    {
        return new UICard(_buf);
    }

    public readonly int Id;
    /// <summary>
    /// 上划
    /// </summary>
    public readonly string DesUpKey;
    /// <summary>
    /// 下划
    /// </summary>
    public readonly string DesDownKey;
    /// <summary>
    /// 卡面资源
    /// </summary>
    public readonly string FaceRes;
    /// <summary>
    /// 卡框资源
    /// </summary>
    public readonly string FrameRes;
   
    public const int __ID__ = -1791979580;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
        
        
        
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "desUpKey:" + DesUpKey + ","
        + "desDownKey:" + DesDownKey + ","
        + "faceRes:" + FaceRes + ","
        + "frameRes:" + FrameRes + ","
        + "}";
    }
}

}