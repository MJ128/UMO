# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class EBMOMBAFGEB(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsEBMOMBAFGEB(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = EBMOMBAFGEB()
        x.Init(buf, n + offset)
        return x

    # EBMOMBAFGEB
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # EBMOMBAFGEB
    def AGOIMGHMGOH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return ""

    # EBMOMBAFGEB
    def KJFEBMBHKOC(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return ""

def EBMOMBAFGEBStart(builder): builder.StartObject(2)
def EBMOMBAFGEBAddAGOIMGHMGOH(builder, AGOIMGHMGOH): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(AGOIMGHMGOH), 0)
def EBMOMBAFGEBAddKJFEBMBHKOC(builder, KJFEBMBHKOC): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(KJFEBMBHKOC), 0)
def EBMOMBAFGEBEnd(builder): return builder.EndObject()
