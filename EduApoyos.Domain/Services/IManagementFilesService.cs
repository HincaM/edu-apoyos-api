using EduApoyos.Domain.Models;

namespace EduApoyos.Domain.Services
{
    public interface IManagementFilesService
    {
        byte[] CrearPdf(RequestSupportConstancyInfo info);
    }
}
