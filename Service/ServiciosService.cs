using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Pisicna_Back.Repositories;
using Pisicna_Back.Service;

namespace Pisicna_Back.Service
{
    public class ServiciosService : IServiciosService
    {
        private readonly IServiciosRepository _serviciosRepository;

        public ServiciosService(IServiciosRepository serviciosRepository)
        {
            _serviciosRepository = serviciosRepository;
        }

        public async Task<List<Servicio>> GetAllAsync()
        {
            return await _serviciosRepository.GetAllAsync();
        }

        public async Task<Servicio?> GetByIdAsync(int id)
        {
            return await _serviciosRepository.GetByIdAsync(id);
        }


        public async Task AddAsync(Servicio servicio)
        {
            await _serviciosRepository.AddAsync(servicio);
        }

        public async Task UpdateAsync(Servicio servicio)
        {
            await _serviciosRepository.UpdateAsync(servicio);
        }

        public async Task DeleteAsync(int id)
        {
           var servicio = await _serviciosRepository.GetByIdAsync(id);
           if (servicio == null)
           {
               //return NotFound();
           }
           await _serviciosRepository.DeleteAsync(id);
           //return NoContent();
        }
        
        // public async Task InicializarDatosAsync()
        // {
        //     await _usuariosRepository.InicializarDatosAsync();
        // }
        /*
        public async Task AddPlatoPrincipalAsync(PlatoPrincipal platoPrincipal)
        {
            if (platoPrincipal == null)
                throw new ArgumentNullException(nameof(platoPrincipal));

            await _platoPrincipalRepository.AddAsync(platoPrincipal);
        }*/
    }
}


