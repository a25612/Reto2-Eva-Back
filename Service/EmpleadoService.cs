using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Pisicna_Back.Repositories;
using Pisicna_Back.Service;

namespace Pisicna_Back.Service
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<List<Empleado>> GetAllAsync()
        {
            return await _empleadoRepository.GetAllAsync();
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _empleadoRepository.GetByIdAsync(id);
        }


        public async Task AddAsync(Empleado empleado)
        {
            await _empleadoRepository.AddAsync(empleado);
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            await _empleadoRepository.UpdateAsync(empleado);
        }

        public async Task DeleteAsync(int id)
        {
           var empleado = await _empleadoRepository.GetByIdAsync(id);
           if (empleado == null)
           {
               //return NotFound();
           }
           await _empleadoRepository.DeleteAsync(id);
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


