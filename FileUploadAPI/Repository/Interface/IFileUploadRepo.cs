using FileUploadAPI.RequestModels;
using FileUploadAPI.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadAPI.Repository.Interface
{
    public interface IFileUploadRepo
    {
        Task<FileUploadResponseModel> uploadFilesAsync(FileUploadRequestModel obj);
        Task<GenericResponseModel> getAllSupportedFileExtensionsAsync();
        Task<GenericResponseModel> getAllAppTypesAsync();
        Task<GenericResponseModel> getAppTypesByIdAsync(long appId);
        Task<GenericResponseModel> getAllFolderTypesByAppIdAsync(long appId);
        Task<GenericResponseModel> getFolderTypeByIdAsync(long folderId);

        //Reusables
        string getFileTypeAsync(string fileExtension);
        IList<string> allFileExtensionsAsync();
    }
}
