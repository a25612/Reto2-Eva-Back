using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Pisicna_Back.Repositories;
using Pisicna_Back.Service;

namespace Pisicna_Back.Service
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _usuariosRepository.GetAllAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _usuariosRepository.GetByIdAsync(id);
        }


        public async Task AddAsync(Usuario usuario)
        {
            await _usuariosRepository.AddAsync(usuario);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            await _usuariosRepository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(int id)
        {
           var usuario = await _usuariosRepository.GetByIdAsync(id);
           if (usuario == null)
           {
               //return NotFound();
           }
           await _usuariosRepository.DeleteAsync(id);
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


