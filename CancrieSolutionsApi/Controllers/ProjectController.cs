using AlmassarGateApi.Domain.DTO.AddDTO;
using Domains.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace AlmassarGateApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public ProjectController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        //[HttpGet("{Id}")]
        //[Authorize]
        //public IActionResult GetById(int Id)
        //{
        //    try
        //    {
        //        ProjectDTO Project = _serviceUnitOfWork.Project.Value.GetById(Id);
        //        return Ok(Project);
        //    }
        //    catch (ValidationException e)
        //    {
        //        return BadRequest(e);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        [HttpPost]
        [Authorize]
        public IActionResult GetList([FromBody] ProjectSearchDTO baseSearch)
        {
            try
            {
                BaseListResponse<ProjectListDTO> projects = _serviceUnitOfWork.Project.Value.GetList(baseSearch);
                return Ok(projects);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("{Id}")]
        [Authorize]
        public IActionResult GetById(int Id)
        {
            try
            {
                ProjectDTO project = _serviceUnitOfWork.Project.Value.GetById(Id);
                return Ok(project);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPatch]
        [Authorize]
        public IActionResult Create([FromForm] ProjectAddDTO project)
        {
            try
            {
                _serviceUnitOfWork.Project.Value.AddEntity(project);
                return Ok(true);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdateProject([FromForm] ProjectUpdateDTO projectUpdate)
        {
            try
            {
                bool project = await _serviceUnitOfWork.Project.Value.UpdateProject(projectUpdate);
                if (project)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw e;
            }
        } 
        [HttpPost]
        [Authorize]
        public IActionResult SubmitQcForm([FromBody] SubmitQcFormDTO submitQcFormDTO)
        {
            try
            {
                 _serviceUnitOfWork.Project.Value.SubmitQcForm(submitQcFormDTO);
                return Ok(true);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpPatch]
        [Authorize]
        public IActionResult AddFile([FromForm] ProjectFilesAddDTO projectFile)
        {
            try
            {
                  _serviceUnitOfWork.Project.Value.AddFile(projectFile);
                return Ok(true);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateQRCode(string qRCode)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(qRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            byte[] fileImg = ImageToByte2(qrCodeImage);
            return File(fileImg,"image/png");
        }
        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }




        [HttpGet("{fileId}")]
        [Authorize]
        public IActionResult Delete(int fileId)
        {
            try
            {
                _serviceUnitOfWork.Project.Value.DeleteFile(fileId);
                return Ok(true);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
