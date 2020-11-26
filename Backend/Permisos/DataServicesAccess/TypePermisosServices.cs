using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataServicesAccess
{
    class TypePermisosServices
    {
        private PermisosContext db = new PermisosContext();

        public List<TipoPermiso> GetTypePermisoList()
        {
            return db.TipoPermisos.ToList();
        }
    }
}
