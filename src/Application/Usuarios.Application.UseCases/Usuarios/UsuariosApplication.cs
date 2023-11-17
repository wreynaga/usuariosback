using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Application.DTO;
using Usuarios.Application.Interface.Persistence;
using Usuarios.Application.Interface.UseCases;
using Usuarios.Application.Validator;
using Usuarios.Domain.Entities;
using Usuarios.Transversal.Common;

namespace Usuarios.Application.UseCases.Usuarios
{
    public class UsuariosApplication : IUsuariosApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UsuariosDtoValidator _usuariosDtoValidator;

        public UsuariosApplication(IUnitOfWork unitOfWork, IMapper mapper, UsuariosDtoValidator usuariosDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _usuariosDtoValidator = usuariosDtoValidator;
        }

        public async Task<Response<bool>> Create(UsuarioDto discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                var validation = await _usuariosDtoValidator.ValidateAsync(discountDto, cancellationToken);
                if (!validation.IsValid)
                {
                    response.Message = "Errores de Validación";
                    response.Errors = validation.Errors;
                    return response;
                }
                var discount = _mapper.Map<Usuario>(discountDto);
                await _unitOfWork.Usuarios.InsertAsync(discount);

                response.Data = await _unitOfWork.Save(cancellationToken) > 0;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<bool>> Delete(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                await _unitOfWork.Usuarios.DeleteAsync(id.ToString());
                response.Data = await _unitOfWork.Save(cancellationToken) > 0;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<UsuarioDto>> Get(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<UsuarioDto>();
            try
            {
                var discount = await _unitOfWork.Usuarios.GetAsync(id, cancellationToken);
                if (discount is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Descuento no existe...";
                    return response;
                }

                response.Data = _mapper.Map<UsuarioDto>(discount);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<List<UsuarioDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var response = new Response<List<UsuarioDto>>();
            try
            {
                var discounts = await _unitOfWork.Usuarios.GetAllAsync(cancellationToken);
                response.Data = _mapper.Map<List<UsuarioDto>>(discounts);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Update(UsuarioDto discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                var validation = await _usuariosDtoValidator.ValidateAsync(discountDto, cancellationToken);
                if (!validation.IsValid)
                {
                    response.Message = "Errores de Validación";
                    response.Errors = validation.Errors;
                    return response;
                }
                var discount = _mapper.Map<Usuario>(discountDto);
                await _unitOfWork.Usuarios.UpdateAsync(discount);

                response.Data = await _unitOfWork.Save(cancellationToken) > 0;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
    }
}
