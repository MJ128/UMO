// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class JHNNMJEDOLG : Table {
  public static JHNNMJEDOLG GetRootAsJHNNMJEDOLG(ByteBuffer _bb) { return GetRootAsJHNNMJEDOLG(_bb, new JHNNMJEDOLG()); }
  public static JHNNMJEDOLG GetRootAsJHNNMJEDOLG(ByteBuffer _bb, JHNNMJEDOLG obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public JHNNMJEDOLG __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public DEGPNJFEGOC GetAHKGHCGBMDA(int j) { return GetAHKGHCGBMDA(new DEGPNJFEGOC(), j); }
  public DEGPNJFEGOC GetAHKGHCGBMDA(DEGPNJFEGOC obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int AHKGHCGBMDALength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<JHNNMJEDOLG> CreateJHNNMJEDOLG(FlatBufferBuilder builder,
      VectorOffset AHKGHCGBMDAOffset = default(VectorOffset)) {
    builder.StartObject(1);
    JHNNMJEDOLG.AddAHKGHCGBMDA(builder, AHKGHCGBMDAOffset);
    return JHNNMJEDOLG.EndJHNNMJEDOLG(builder);
  }

  public static void StartJHNNMJEDOLG(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddAHKGHCGBMDA(FlatBufferBuilder builder, VectorOffset AHKGHCGBMDAOffset) { builder.AddOffset(0, AHKGHCGBMDAOffset.Value, 0); }
  public static VectorOffset CreateAHKGHCGBMDAVector(FlatBufferBuilder builder, Offset<DEGPNJFEGOC>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartAHKGHCGBMDAVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<JHNNMJEDOLG> EndJHNNMJEDOLG(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<JHNNMJEDOLG>(o);
  }
};

