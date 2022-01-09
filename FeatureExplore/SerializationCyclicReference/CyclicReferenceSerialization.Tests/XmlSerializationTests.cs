using CyclicReferenceSerialization.Dto;
using System;
using System.Linq;
using Xunit;

namespace CyclicReferenceSerialization.Tests;
public class XmlSerializationTests
{
    [Theory]
    [ClassData(typeof(TestData))]
    public void SerializeAndReadbackTests(FolderSerialized folder)
    {
        var serializedData = Xml.Serialize(folder);
        var deserializedData = Xml.Deserialize<FolderSerialized>(serializedData);

        _(folder.Root, deserializedData.Root);

        void _(IFileFolderBase expected, IFileFolderBase actual)
        {
            (actual switch
            {
                Folder actualFolder => (Action)(() =>
                {
                    if (expected is Folder expectedFolder)
                    {
                        Assert.Equal(expectedFolder.Name, actualFolder.Name);
                        Assert.Equal(expectedFolder.Id, actualFolder.Id);
                        Assert.Equal(expectedFolder.Children.Count, actualFolder.Children.Count);

                        foreach (var childItem in actualFolder.Children)
                        {
                            _(expectedFolder.Children.Single(x => x.Id == childItem.Id), childItem);
                        }
                    }
                }),
                File actualFile => (Action)(() =>
                {
                    if (expected is File expectedFile)
                    {
                        Assert.Equal(expectedFile.Name, actualFile.Name);
                        Assert.Equal(expectedFile.Id, actualFile.Id);
                    }
                }),
                _ => () => throw new System.NotImplementedException()
            })();
        };
    }
}