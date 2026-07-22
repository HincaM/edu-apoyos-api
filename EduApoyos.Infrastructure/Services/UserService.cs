using EduApoyos.Application.Common.Helpers;
using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications.Users;
using Mapster;
using System.Transactions;

namespace EduApoyos.Infrastructure.Services
{
    public sealed class UserService(
        IUserRepository _userRepository,
        IStudentRepository _studentRepository) : IUserService
    {
        public async Task<GetUserResult?> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            return (await _userRepository.GetByEmail(email, cancellationToken)).Adapt<GetUserResult>(config =>
            {
                config.NewConfig<User, GetUserResult>()
                    .Map(dest => dest.UserId, src => src.Id)
                    .Map(dest => dest.Email, src => src.Email)
                    .Map(dest => dest.Role, src => src.Role)
                    .Map(dest => dest.PasswordHash, src => src.PasswordHash);
            });
        }

        public async Task<ErrorOr<bool>> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
            using (TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled))
            {
                PasswordHashHelper passwordHash = new();
                var passHash = passwordHash.Hash(request.Password);
                var user = User.Create(request.FullName, request.Email, passHash, request.Role);
                await _userRepository.Create(user, cancellationToken);

                if (user.Id > 0)
                {
                    var saved = await _studentRepository.Create(Student.Create(
                        user.Id,
                        request.DocumentNumber,
                        request.DocumentType,
                        request.AcademicProgramId,
                        request.Semester), cancellationToken);

                    if (saved > 0)
                        transaction.Complete();

                    return true;
                }

                return false;
            }
        }

        public async Task<ErrorOr<PaginatedList<GetAdvisorResult>>> GetAdvisors(GetAdvisorRequest request, CancellationToken cancellationToken)
            => await _userRepository.GetAdvisors(new GetAdvisorsSpecification(request.CurrentPage, request.PageSize), cancellationToken);
    }
}
