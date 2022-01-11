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
        var dictionary = new Dictionary<Guid, Folder>()
        {
            [Guid.Empty] = null
        };

        FixParentRelation(Root, dictionary);
    }

    private void FixParentRelation(FileFolderBase node, Dictionary<Guid, Folder> dictionary)
    {
        (node switch
        {
            Folder folder => (Action)(() =>
            {
                folder.Parent = dictionary[folder.ParentId];
                dictionary[folder.Id] = folder;

                foreach(var child in folder.Children)
                {
                    FixParentRelation(child, dictionary);
                }
            }),

            File file => (Action)(() =>
            {
                file.Parent = dictionary[file.ParentId];
            })
        })();
    }
}
