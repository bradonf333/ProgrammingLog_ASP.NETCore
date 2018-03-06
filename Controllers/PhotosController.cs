using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProgrammingLog.Controllers.Resources;
using ProgrammingLog.Models;

namespace ProgrammingLog.Controllers
{
    [Route("/api/tasks/{taskId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly ITaskRepository repository;
        private readonly IPhotoRepository photoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly PhotoSettings photoSettings;

        public PhotosController(
            IHostingEnvironment host,
            ITaskRepository repository,
            IPhotoRepository photoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptionsSnapshot<PhotoSettings> options)
        {
            this.photoSettings = options.Value;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
            this.photoRepository = photoRepository;
            this.host = host;
        }

        [HttpGet]
        public async Task<IEnumerable<PhotosResource>> GetPhotosAsync(int taskId)
        {
            var photos = await photoRepository.GetPhotosAsync(taskId);

            return mapper.Map<IEnumerable<Photo>, IEnumerable<PhotosResource>>(photos);
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(int taskId, IFormFile file)
        {
            var task = await repository.GetTaskAsync(taskId, includeTaskLanguages : false);

            if (task == null)
            {
                return NotFound();
            }
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is null or empty.");
            }
            if (file.Length > photoSettings.MaxBytes)
            {
                return BadRequest("Maximum file size exceeded " + photoSettings.MaxBytes + " File size: " + file.Length);
            }
            if (!photoSettings.IsSupportedFileType(file.FileName))
            {
                return BadRequest("Invalid file type.");
            }

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo
            {
                FileName = fileName
            };

            task.Photos.Add(photo);
            await unitOfWork.CompleteAsync();
            var photoResult = mapper.Map<Photo, PhotosResource>(photo);
            return Ok(photoResult);

        }
    }
};