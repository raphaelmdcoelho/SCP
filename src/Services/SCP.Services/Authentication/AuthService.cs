using AutoMapper;
using SCP.CrossCutting.MapModels.Usuario;
using SCP.Domain.Usuario;
using SCP.Repository.Repositories.Usuario;
using SCP.Repository.UoW;
using SCP.CrossCutting.Configuration;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SCP.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public AuthService(IUsuarioRepository usuarioRepository,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ResponseAddUsuarioModel> Register(UsuarioAddModel usuario, string password)
        {
            if (UserExists(usuario.Username).Result)
            {
                return new ResponseAddUsuarioModel { Usuario = null, Message = "Usuário já cadastrado.", Success = false };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            usuario.Senha = Convert.ToBase64String(passwordHash);
            usuario.Salt = Convert.ToBase64String(passwordSalt);

            var entity = await _usuarioRepository.Insert(_mapper.Map<UsuarioEntity>(usuario));
            _uow.SaveChanges();

            var usuarioEntityDb = (UsuarioEntity)entity.Entity;
            return new ResponseAddUsuarioModel { Usuario = _mapper.Map<UsuarioModel>(usuarioEntityDb), Message = "Usuario cadastrado com sucesso!", Success = true };
        }

        public async Task<bool> UserExists(string username)
        {
            var listUsuarios = await _usuarioRepository.GetAll();

            if (listUsuarios.Any(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            passwordSalt = Encoding.UTF8.GetBytes(AuthenticationConfiguration.Secret);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            passwordHash = KeyDerivation.Pbkdf2(
                password: password,
                salt: passwordSalt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);
        }

        public string GetPasswordHash(string password)
        {
            var passwordSalt = Encoding.UTF8.GetBytes(AuthenticationConfiguration.Secret);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            var passwordHash = KeyDerivation.Pbkdf2(
                password: password,
                salt: passwordSalt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(passwordHash);
        }
    }
}
