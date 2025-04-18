// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class JGABIAKLIJE : Table {
  public static JGABIAKLIJE GetRootAsJGABIAKLIJE(ByteBuffer _bb) { return GetRootAsJGABIAKLIJE(_bb, new JGABIAKLIJE()); }
  public static JGABIAKLIJE GetRootAsJGABIAKLIJE(ByteBuffer _bb, JGABIAKLIJE obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public JGABIAKLIJE __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public POKOMFMBPID GetGMMJCFGMCJH(int j) { return GetGMMJCFGMCJH(new POKOMFMBPID(), j); }
  public POKOMFMBPID GetGMMJCFGMCJH(POKOMFMBPID obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int GMMJCFGMCJHLength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }
  public KAAOOFNDCML GetNJJINHMIOHN(int j) { return GetNJJINHMIOHN(new KAAOOFNDCML(), j); }
  public KAAOOFNDCML GetNJJINHMIOHN(KAAOOFNDCML obj, int j) { int o = __offset(6); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int NJJINHMIOHNLength { get { int o = __offset(6); return o != 0 ? __vector_len(o) : 0; } }
  public LKAHFKFPLAH GetNPFBHGKLIOM(int j) { return GetNPFBHGKLIOM(new LKAHFKFPLAH(), j); }
  public LKAHFKFPLAH GetNPFBHGKLIOM(LKAHFKFPLAH obj, int j) { int o = __offset(8); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int NPFBHGKLIOMLength { get { int o = __offset(8); return o != 0 ? __vector_len(o) : 0; } }
  public EDPJPHELMBH GetKDCENEMGIFL(int j) { return GetKDCENEMGIFL(new EDPJPHELMBH(), j); }
  public EDPJPHELMBH GetKDCENEMGIFL(EDPJPHELMBH obj, int j) { int o = __offset(10); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int KDCENEMGIFLLength { get { int o = __offset(10); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<JGABIAKLIJE> CreateJGABIAKLIJE(FlatBufferBuilder builder,
      VectorOffset GMMJCFGMCJHOffset = default(VectorOffset),
      VectorOffset NJJINHMIOHNOffset = default(VectorOffset),
      VectorOffset NPFBHGKLIOMOffset = default(VectorOffset),
      VectorOffset KDCENEMGIFLOffset = default(VectorOffset)) {
    builder.StartObject(4);
    JGABIAKLIJE.AddKDCENEMGIFL(builder, KDCENEMGIFLOffset);
    JGABIAKLIJE.AddNPFBHGKLIOM(builder, NPFBHGKLIOMOffset);
    JGABIAKLIJE.AddNJJINHMIOHN(builder, NJJINHMIOHNOffset);
    JGABIAKLIJE.AddGMMJCFGMCJH(builder, GMMJCFGMCJHOffset);
    return JGABIAKLIJE.EndJGABIAKLIJE(builder);
  }

  public static void StartJGABIAKLIJE(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddGMMJCFGMCJH(FlatBufferBuilder builder, VectorOffset GMMJCFGMCJHOffset) { builder.AddOffset(0, GMMJCFGMCJHOffset.Value, 0); }
  public static VectorOffset CreateGMMJCFGMCJHVector(FlatBufferBuilder builder, Offset<POKOMFMBPID>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartGMMJCFGMCJHVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNJJINHMIOHN(FlatBufferBuilder builder, VectorOffset NJJINHMIOHNOffset) { builder.AddOffset(1, NJJINHMIOHNOffset.Value, 0); }
  public static VectorOffset CreateNJJINHMIOHNVector(FlatBufferBuilder builder, Offset<KAAOOFNDCML>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartNJJINHMIOHNVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNPFBHGKLIOM(FlatBufferBuilder builder, VectorOffset NPFBHGKLIOMOffset) { builder.AddOffset(2, NPFBHGKLIOMOffset.Value, 0); }
  public static VectorOffset CreateNPFBHGKLIOMVector(FlatBufferBuilder builder, Offset<LKAHFKFPLAH>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartNPFBHGKLIOMVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddKDCENEMGIFL(FlatBufferBuilder builder, VectorOffset KDCENEMGIFLOffset) { builder.AddOffset(3, KDCENEMGIFLOffset.Value, 0); }
  public static VectorOffset CreateKDCENEMGIFLVector(FlatBufferBuilder builder, Offset<EDPJPHELMBH>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartKDCENEMGIFLVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<JGABIAKLIJE> EndJGABIAKLIJE(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<JGABIAKLIJE>(o);
  }
};

