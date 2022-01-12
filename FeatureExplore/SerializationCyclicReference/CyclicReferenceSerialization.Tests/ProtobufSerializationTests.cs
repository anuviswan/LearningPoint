using CyclicReferenceSerialization.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CyclicReferenceSerialization.Tests;
public class ProtobufSerializationTests
{
    [Theory]
    [ClassData(typeof(TestData))]
    public void SerializeAndReadbackTests(ISerializer<dynamic> serializer, FolderSerialized folder)
    {
        var serializedData = serializer.Serialize(folder);
        var deserializedData = serializer.Deserialize<FolderSerialized>(serializedData);

        _(folder.Root, deserializedData.Root);

        void _(FileFolderBase expected, FileFolderBase actual)
        {
            //(actual switch
            //{
            //    Folder actualFolder => (Action)(() =>
            //    {
            //        if (expected is Folder expectedFolder)
            //        {
            //            Assert.Equal(expectedFolder.Name, actualFolder.Name);
            //            Assert.Equal(expectedFolder.Id, actualFolder.Id);
            //            Assert.Equal(expectedFolder.Parent?.Id, actualFolder.Parent?.Id);
            //            Assert.Equal(expectedFolder.Children.Count(), actualFolder.Children.Count());

            //            foreach (var childItem in actualFolder.Children)
            //            {
            //                _(expectedFolder.Children.Single(x => x.Id == childItem.Id), childItem);
            //            }
            //        }
            //    }),
            //    File actualFile => (Action)(() =>
            //    {
            //        if (expected is File expectedFile)
            //        {
            //            Assert.Equal(expectedFile.Parent?.Id, actualFile.Parent?.Id);
            //            Assert.Equal(expectedFile.Name, actualFile.Name);
            //            Assert.Equal(expectedFile.Id, actualFile.Id);
            //        }
            //    }),
            //    _ => () => throw new System.NotImplementedException()
            //})();


            if(actual is Folder actualFolder && expected is Folder expectedFolder)
            {
                Assert.Equal(expectedFolder.Name, actualFolder.Name);
                Assert.Equal(expectedFolder.Id, actualFolder.Id);
                Assert.Equal(expectedFolder.Parent?.Id, actualFolder.Parent?.Id);
                Assert.Equal(expectedFolder.Children.Count(), actualFolder.Children.Count());

                foreach (var childItem in actualFolder.Children)
                {
                    _(expectedFolder.Children.Single(x => x.Id == childItem.Id), childItem);
                }
            }

            if(actual is File actualFile && expected is File expectedFile)
            {
                Assert.Equal(expectedFile.Parent?.Id, actualFile.Parent?.Id);
                Assert.Equal(expectedFile.Name, actualFile.Name);
                Assert.Equal(expectedFile.Id, actualFile.Id);
            }
        };
    }
}
