using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataServicesAccess;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Permisos.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class TypePermisosController : ControllerBase
    {
        private readonly PermisosServices _dataServices = new PermisosServices();

        [HttpGet]
        public List<TipoPermiso> GetTypePermiso()
        {
            return _dataServices.GetTypePermisoList();
        }

    }
}
