using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingLog.Controllers.Resources;
using ProgrammingLog.Models;

namespace ProgrammingLog.Controllers
{
    [Route("api/tasks/{taskId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly ITaskRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PhotosController(
            IHostingEnvironment host,
            ITaskRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
            this.host = host;
        }
        public async Task<IActionResult> UploadAsync(int taskId, IFormFile file)
        {
            var task = await repository.GetTaskAsync(taskId, includeTaskLanguages : false);

            if (task == null)
            {
                return NotFound();
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
}