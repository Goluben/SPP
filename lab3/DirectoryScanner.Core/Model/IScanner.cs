using DirectoryScanner.Core.Model;

namespace DirectoryScanner.Core;

public interface IScanner
{
    IFileSystemComponent StartScan();
}