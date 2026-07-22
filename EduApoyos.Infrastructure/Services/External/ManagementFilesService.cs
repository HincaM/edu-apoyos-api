using EduApoyos.Domain.Models;
using EduApoyos.Domain.Services;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EduApoyos.Infrastructure.Services.External
{
    public class ManagementFilesService() : IManagementFilesService
    {
        public byte[] CrearPdf(RequestSupportConstancyInfo info)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Header().Element(ComposeHeader);
                    page.Content().Element(x => Content(x, info));
                    page.Footer().Element(ComposeFooter);
                });
            }).GeneratePdf();
        }

        private static void ComposeHeader(IContainer container)
        {
            container
                .Text("Constancia")
                .FontSize(24)
                .Bold();
        }

        private static void Content(IContainer container, RequestSupportConstancyInfo info)
        {
            container.Column(column =>
            {
                column.Item().Text($"Estudiante: {info.StudentName}");
                column.Item().Text($"Documento: {info.DocumentTypeDescription} {info.DocumentNumber}");
                column.Item().Text($"Correo: {info.Email}");
                column.Item().Text($"Programa académico: {info.AcademicProgramName}");
                column.Item().Text($"Semestre: {info.Semester}");
                column.Item().Text($"Tipo de apoyo: {info.TypeSupportDescription}");
                column.Item().Text($"Monto solicitado: {info.RequestedAmount:C}");
                column.Item().Text($"Descripción: {info.Description}");
                column.Item().Text($"Estado: {info.StatusDescription}");
                column.Item().Text($"Fecha de solicitud: {info.ApplicationDate:d}");

                column.Item().PaddingTop(20);
            });
        }

        private static void ComposeFooter(IContainer container)
        {
            container
                .AlignCenter()
                .Text(x =>
                {
                    x.Span("Página ");
                    x.CurrentPageNumber();
                });
        }
    }
}
