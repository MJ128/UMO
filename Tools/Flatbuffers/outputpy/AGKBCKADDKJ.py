# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class AGKBCKADDKJ(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsAGKBCKADDKJ(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = AGKBCKADDKJ()
        x.Init(buf, n + offset)
        return x

    # AGKBCKADDKJ
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # AGKBCKADDKJ
    def AGCMBBANHPN(self, j):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            x = self._tab.Vector(o)
            x += flatbuffers.number_types.UOffsetTFlags.py_type(j) * 4
            x = self._tab.Indirect(x)
            from .FKEPLHAEEBK import FKEPLHAEEBK
            obj = FKEPLHAEEBK()
            obj.Init(self._tab.Bytes, x)
            return obj
        return None

    # AGKBCKADDKJ
    def AGCMBBANHPNLength(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.VectorLen(o)
        return 0

def AGKBCKADDKJStart(builder): builder.StartObject(1)
def AGKBCKADDKJAddAGCMBBANHPN(builder, AGCMBBANHPN): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(AGCMBBANHPN), 0)
def AGKBCKADDKJStartAGCMBBANHPNVector(builder, numElems): return builder.StartVector(4, numElems, 4)
def AGKBCKADDKJEnd(builder): return builder.EndObject()
