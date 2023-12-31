﻿using OfficeCraft.Models.Entities;

namespace OfficeCraft.Services.IService
{
    public interface IRolServices
    {
        public Task<List<Rol>> GetRol();
        public Task<Rol> GetByIdRol(int id);

        public Task<Rol> CrearRol(Rol i);
        public Task<Rol> EditarRol(Rol i);
        public bool EliminarRol(int id);
    }
}
