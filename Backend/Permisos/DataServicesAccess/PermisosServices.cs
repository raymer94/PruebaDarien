using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataServicesAccess
{
    public class PermisosServices
    {
       private PermisosContext db = new PermisosContext();

        public List<Permiso> GetPermisoList() {
            return db.Permisos.ToList();
        }

        public List<TipoPermiso> GetTypePermisoList()
        {
            return db.TipoPermisos.ToList();
        }

        public Permiso GetPermiso(int id) {
            return db.Permisos.Find(id);
        }

        public void AddPermiso(Permiso permiso) {
            db.Add(permiso);
            db.SaveChanges();
        }

        public void UpdatePermiso(Permiso permiso) { 
            
            db.Entry(permiso).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeletePermiso(int id) {
            var permiso = db.Permisos.Find(id);
            db.Remove(permiso);
            db.SaveChanges();
        }
    }
}
