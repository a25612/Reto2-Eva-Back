using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Pisicna_Back.Repositories;
using Pisicna_Back.Service;

namespace Pisicna_Back.Service
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _tutorRepository;

        public TutorService(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }
        public async Task<List<Tutor>> GetAllAsync()
        {
            return await _tutorRepository.GetAllAsync();
        }

        public async Task<Tutor?> GetByIdAsync(int id)
        {
            return await _tutorRepository.GetByIdAsync(id);
        }


        public async Task AddAsync(Tutor tutor)
        {
            await _tutorRepository.AddAsync(tutor);
        }

        public async Task UpdateAsync(Tutor tutor)
        {
            await _tutorRepository.UpdateAsync(tutor);
        }

        public async Task DeleteAsync(int id)
        {
            var tutor = await _tutorRepository.GetByIdAsync(id);
            if (tutor == null)
            {
                //return NotFound();
            }
            await _tutorRepository.DeleteAsync(id);
            //return NoContent();
        }

        public async Task<Tutor?> LoginAsync(string username, string password)
        {
            var tutor = await _tutorRepository.GetByUsernameAndPasswordAsync(username, password);

            if (tutor == null)
            {
                return null; // Usuario no encontrado o credenciales incorrectas
            }

            if (!tutor.Activo)
            {
                throw new Exception("El usuario está inactivo. Contacte al administrador.");
            }

            return tutor;
        }

    }
}


