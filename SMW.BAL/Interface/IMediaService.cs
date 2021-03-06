﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMW.Models;

namespace SMW.BAL.Interface
{
  public  interface IMediaService
    {

        Media GetMedia(long mediaId);
        IEnumerable<MediaFolder> GetChildFolders(long parentId);
        MediaFolder GetFolderAndChildFolders(long parentFolderId);
        IEnumerable<Media> GetFilesInFolder(long folderId, string filterMediaTypes);
        long SaveFolder(MediaFolder model);
        long SaveFile(long parentId, string fileName, int contentLength, long extensionTypeId, long mediaTypeId);
        void Delete(long mediaId);
        void MarkAsDeleted(long mediaId);
        IEnumerable<ExtensionType> GetAllExtentionTypes();
        long AddExtention(string ext);
        bool HasFolderOrFiles(long folderId);
        IEnumerable<SMW.Models.Media> GetFilesInFolder(long folderId);

        string GetPathCsvMediaId(long mediaId);
        long[] GetPathMediaIds(long mediaId);
        IEnumerable<MediaFolder> DrillDownToMediaId(long mediaId);
        IEnumerable<MediaFolder> GetFolder(long mediaId);
    }
}
