using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataServicesAccess;
using DataAccess.Models;

namespace Permisos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly PermisosServices _dataServices = new PermisosServices();
        // GET: api/Permisos
        [HttpGet]
        public List<Permiso> Get()
        {
            return _dataServices.GetPermisoList();
        }

        // GET: api/Permisos/5
        [HttpGet("{id}", Name = "Get")]
        public Permiso Get(int id)
        {           
            return _dataServices.GetPermiso(id);
        }

        // POST: api/Permisos
        [HttpPost]
        public void Post([FromBody] Permiso permisos)
        {
            _dataServices.AddPermiso(permisos);
        }

        // PUT: api/Permisos/5
        [HttpPut]
        public void Put([FromBody] Permiso permisos)
        {
            _dataServices.UpdatePermiso(permisos);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataServices.DeletePermiso(id);
        }
    }
}
