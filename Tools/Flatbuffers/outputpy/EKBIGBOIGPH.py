# automatically generated by the FlatBuffers compiler, do not modify

# namespace: 

import flatbuffers

class EKBIGBOIGPH(object):
    __slots__ = ['_tab']

    @classmethod
    def GetRootAsEKBIGBOIGPH(cls, buf, offset):
        n = flatbuffers.encode.Get(flatbuffers.packer.uoffset, buf, offset)
        x = EKBIGBOIGPH()
        x.Init(buf, n + offset)
        return x

    # EKBIGBOIGPH
    def Init(self, buf, pos):
        self._tab = flatbuffers.table.Table(buf, pos)

    # EKBIGBOIGPH
    def AGOIMGHMGOH(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(4))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return ""

    # EKBIGBOIGPH
    def KJFEBMBHKOC(self):
        o = flatbuffers.number_types.UOffsetTFlags.py_type(self._tab.Offset(6))
        if o != 0:
            return self._tab.String(o + self._tab.Pos)
        return ""

def EKBIGBOIGPHStart(builder): builder.StartObject(2)
def EKBIGBOIGPHAddAGOIMGHMGOH(builder, AGOIMGHMGOH): builder.PrependUOffsetTRelativeSlot(0, flatbuffers.number_types.UOffsetTFlags.py_type(AGOIMGHMGOH), 0)
def EKBIGBOIGPHAddKJFEBMBHKOC(builder, KJFEBMBHKOC): builder.PrependUOffsetTRelativeSlot(1, flatbuffers.number_types.UOffsetTFlags.py_type(KJFEBMBHKOC), 0)
def EKBIGBOIGPHEnd(builder): return builder.EndObject()
