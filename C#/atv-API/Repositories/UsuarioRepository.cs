﻿using Charpter.WebApi.Contexts;
using Charpter.WebApi.Interfaces;
using Charpter.WebApi.Models;

namespace Charpter.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly CharpterContext _context;

        public  UsuarioRepository(CharpterContext context)
        {
            _context = context;
        }
        
        
        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.Senha = usuario.Senha;
                //usuarioEncontrado.Tipo = usuario.Tipo;
            }

            _context.Usuarios.Update(usuarioEncontrado);

            _context.SaveChanges();

        }

        public Usuario BuscarPorId(int id)
        {
           return _context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

            _context.SaveChanges();
        }   

        public void Deletar(int id)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(usuarioEncontrado);

            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(usuario => usuario.Email == email && usuario.Senha == senha);
        }
    }
}
