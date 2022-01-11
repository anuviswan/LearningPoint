using ProtoBuf;
using System.Runtime.Serialization;

namespace CyclicReferenceSerialization.Dto;

[DataContract]
[ProtoContract]
public class FolderSerialized
{
    [DataMember]
    [ProtoMember(1)]
    public Folder Root { get; set; }

    [ProtoAfterDeserialization]
    public void AfterDeserialization()
    {
        var dictionary = new Dictionary<Guid,Folder>();

        FixParentRelation(Root, dictionary);
    }

    private void FixParentRelation(Folder root, Dictionary<Guid, Folder> dictionary)
    {
        (root switch
        {
            Folder folder => (Action)(() =>
            {

            })
        })();
    }
}
