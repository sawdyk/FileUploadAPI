using FileUploadAPI.Helpers;
using FileUploadAPI.Repository.Interface;
using FileUploadAPI.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileUploadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadRepo _uploadFilesRepo;

        public FileUploadController(IFileUploadRepo uploadFilesRepo)
        {
            _uploadFilesRepo = uploadFilesRepo;
        }

        [DisableRequestSizeLimit]
        [HttpPost("uploadFiles")]
        public async Task<IActionResult> uploadFilesAsync([FromForm] FileUploadRequestModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _uploadFilesRepo.uploadFilesAsync(obj);

            if (result.StatusCode == 200)
                Loggers.WriteToFile($"A file with name: {obj.File.FileName} was Uploaded Sucessfully. DateTime_Of_Action: {DateTime.Now}\n");
            else
                Loggers.WriteToFile($"A file with name: {obj.File.FileName} was Not Uploaded Successfully. DateTime_Of_Action: {DateTime.Now}\n");

            return Ok(result);
        }

        [HttpGet("appTypes")]
        public async Task<IActionResult> getAllAppTypesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _uploadFilesRepo.getAllAppTypesAsync();

            if (result.StatusCode == 200)
                Loggers.WriteToFile($"Get All App Types Endpoint Was Called Successfully. DateTime_Of_Action: {DateTime.Now}\n");
            else
                Loggers.WriteToFile($"There was an Error Calling the Get All App Types Endpoint. DateTime_Of_Action: {DateTime.Now}\n");

            return Ok(result);
        }

        [HttpGet("appTypesById")]
        public async Task<IActionResult> getAppTypesByIdAsync(long appId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _uploadFilesRepo.getAppTypesByIdAsync(appId);

            if (result.StatusCode == 200)
                Loggers.WriteToFile($"Get All App Types By ID Endpoint Was Called Successfully. DateTime_Of_Action: {DateTime.Now}\n");
            else
                Loggers.WriteToFile($"There was an Error Calling the Get All App Types By ID Endpoint. DateTime_Of_Action: {DateTime.Now}\n");

            return Ok(result);
        }

        [HttpGet("supportedFileExtensions")]
        public async Task<IActionResult> getAllSupportedFileExtensionsAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _uploadFilesRepo.getAllSupportedFileExtensionsAsync();

            if (result.StatusCode == 200)
                Loggers.WriteToFile($"Get All Supported File Extension Endpoint Was Called Successfully. DateTime_Of_Action: {DateTime.Now}\n");
            else
                Loggers.WriteToFile($"There was an Error Calling the Get All Supported File Extension Endpoint. DateTime_Of_Action: {DateTime.Now}\n");

            return Ok(result);
        }

        [HttpGet("folderTypesByAppId")]
        public async Task<IActionResult> getAllFolderTypesByAppIdAsync(long appId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _uploadFilesRepo.getAllFolderTypesByAppIdAsync(appId);

            if (result.StatusCode == 200)
                Loggers.WriteToFile($"Get All Folder Types By AppID {appId} Endpoint Was Called Successfully. DateTime_Of_Action: {DateTime.Now}\n");
            else
                Loggers.WriteToFile($"There was an Error Calling the Get All Folder Types By AppID {appId} Endpoint. DateTime_Of_Action: {DateTime.Now}\n");

            return Ok(result);
        }

        [HttpGet("folderTypeById")]
        public async Task<IActionResult> getFolderTypeByIdAsync(long folderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _uploadFilesRepo.getFolderTypeByIdAsync(folderId);

            if (result.StatusCode == 200)
                Loggers.WriteToFile($"Get All Folder Types By FolderTypeID {folderId} Endpoint Was Called Successfully. DateTime_Of_Action: {DateTime.Now}\n");
            else
                Loggers.WriteToFile($"There was an Error Calling the Get All Folder Types By FolderTypeID {folderId} Endpoint. DateTime_Of_Action: {DateTime.Now}\n");

            return Ok(result);
        }
    }
}
