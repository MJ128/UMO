// automatically generated by the FlatBuffers compiler, do not modify

using System;
using FlatBuffers;

public sealed class GIGLCNHCNEN : Table {
  public static GIGLCNHCNEN GetRootAsGIGLCNHCNEN(ByteBuffer _bb) { return GetRootAsGIGLCNHCNEN(_bb, new GIGLCNHCNEN()); }
  public static GIGLCNHCNEN GetRootAsGIGLCNHCNEN(ByteBuffer _bb, GIGLCNHCNEN obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public GIGLCNHCNEN __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public uint BBPHAPFBFHK { get { int o = __offset(4); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint CFLMCGOJJJD { get { int o = __offset(6); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint IDHMHHMGAHM { get { int o = __offset(8); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint NJLJEKDBPCH { get { int o = __offset(10); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }
  public uint MAOAGDBDBIB { get { int o = __offset(12); return o != 0 ? bb.GetUint(o + bb_pos) : (uint)0; } }

  public static Offset<GIGLCNHCNEN> CreateGIGLCNHCNEN(FlatBufferBuilder builder,
      uint BBPHAPFBFHK = 0,
      uint CFLMCGOJJJD = 0,
      uint IDHMHHMGAHM = 0,
      uint NJLJEKDBPCH = 0,
      uint MAOAGDBDBIB = 0) {
    builder.StartObject(5);
    GIGLCNHCNEN.AddMAOAGDBDBIB(builder, MAOAGDBDBIB);
    GIGLCNHCNEN.AddNJLJEKDBPCH(builder, NJLJEKDBPCH);
    GIGLCNHCNEN.AddIDHMHHMGAHM(builder, IDHMHHMGAHM);
    GIGLCNHCNEN.AddCFLMCGOJJJD(builder, CFLMCGOJJJD);
    GIGLCNHCNEN.AddBBPHAPFBFHK(builder, BBPHAPFBFHK);
    return GIGLCNHCNEN.EndGIGLCNHCNEN(builder);
  }

  public static void StartGIGLCNHCNEN(FlatBufferBuilder builder) { builder.StartObject(5); }
  public static void AddBBPHAPFBFHK(FlatBufferBuilder builder, uint BBPHAPFBFHK) { builder.AddUint(0, BBPHAPFBFHK, 0); }
  public static void AddCFLMCGOJJJD(FlatBufferBuilder builder, uint CFLMCGOJJJD) { builder.AddUint(1, CFLMCGOJJJD, 0); }
  public static void AddIDHMHHMGAHM(FlatBufferBuilder builder, uint IDHMHHMGAHM) { builder.AddUint(2, IDHMHHMGAHM, 0); }
  public static void AddNJLJEKDBPCH(FlatBufferBuilder builder, uint NJLJEKDBPCH) { builder.AddUint(3, NJLJEKDBPCH, 0); }
  public static void AddMAOAGDBDBIB(FlatBufferBuilder builder, uint MAOAGDBDBIB) { builder.AddUint(4, MAOAGDBDBIB, 0); }
  public static Offset<GIGLCNHCNEN> EndGIGLCNHCNEN(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<GIGLCNHCNEN>(o);
  }
};

