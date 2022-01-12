using CyclicReferenceSerialization.Dto;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CyclicReferenceSerialization.Tests;
public class TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new JsonSerializer(),
            GetTwoLevelData()
        };

        yield return new object[]
        {
            new JsonSerializer(),
            GetSingleLevelData()
        };

        yield return new object[]
        {
            new XmlDataSerializer(),
            GetTwoLevelData()
        };

        yield return new object[]
        {
            new XmlDataSerializer(),
            GetSingleLevelData()
        };

        yield return new object[]
        {
            new ProtobufSerializer(),
            GetTwoLevelData()
        };

        yield return new object[]
        {
            new ProtobufSerializer(),
            GetSingleLevelData()
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private object GetSingleLevelData()
    {
        FileFolderBase root = new Folder
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            Name = "root",
            Parent = null,
        };
        FileFolderBase leafAtRoot = new File
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "ChildAtRoot",
            Parent = (Folder)root,
        };

        ((Folder)root).Children = new List<FileFolderBase> { leafAtRoot };
        return new FolderSerialized
        {
            Root = (Folder)root,
        };
    }
    private object GetTwoLevelData()
    {
        FileFolderBase root = new Folder
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            Name = "root",
            Parent = null,
        };

        FileFolderBase leafAtRoot = new File
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "ChildAtRoot",
            Parent = (Folder)root
        };

        FileFolderBase folderAtRoot = new Folder
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
            Name = "folderAtRoot",
            Parent = (Folder)root,
        };

        FileFolderBase leafAtSubFolder = new File
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Name = "ChildAtSubFolder",
            Parent = (Folder)folderAtRoot
        };

        ((Folder)folderAtRoot).Children = new List<FileFolderBase> { leafAtSubFolder };

        ((Folder)root).Children = new List<FileFolderBase> {leafAtRoot, folderAtRoot};

        return new FolderSerialized
        {
            Root = (Folder)root,
        };
    }
}
