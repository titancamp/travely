using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.PropertyManager;
using TourManager.Common.Clients.PropertyManager;
using TourManager.Service.Abstraction;

namespace TourManager.Service.Implementation
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyManagerClient _client;

        public PropertyService(IPropertyManagerClient client)
        {
            _client = client;
        }

        public async Task<int> AddAsync(int agencyId, AddPropertyRequestDto request)
        {
            var newAttacments = new List<PropertyAttachmentDto>();

            foreach (var file in request.AttachmentsToAdd)
            {
                var url = await UploadFileAsync(file);
                newAttacments.Add(new PropertyAttachmentDto
                {
                    Name = file.Name,
                    Url = url,
                });
            }

            return await _client.AddPropertyAsync(agencyId, request);
        }

        public async Task<int> EditAsync(int agencyId, EditPropertyRequestDto request)
        {
            var newAttacments = new List<PropertyAttachmentDto>();

            foreach (var file in request.AttachmentsToAdd)
            {
                var url = await UploadFileAsync(file);
                newAttacments.Add(new PropertyAttachmentDto
                {
                    Name = file.Name,
                    Url = url,
                });
            }

            request.Attachments = request.Attachments.Concat(newAttacments);

            return await _client.EditPropertyAsync(agencyId, request);
        }


        public async Task DeleteAsync(int agencyId, int id)
        {
            var property = await _client.GetByIdAsync(agencyId, id);

            await _client.DeletePropertyAsync(agencyId, id);

            foreach (var attachment in property.Attachments)
            {
                await DeleteFileAsync(attachment.Url);
            }
        }

        public Task<PropertyResponseDto> GetByIdAsync(int agencyId, int id)
        {
            return _client.GetByIdAsync(agencyId, id);
        }

        public Task<IEnumerable<PropertyResponseDto>> GetAsync(int agencyId)
        {
            return _client.GetPropertiesAsync(agencyId);
        }

        private Task<string> UploadFileAsync(FileModel file)
        {
            // TODO: upload file into file storage
            return Task.FromResult("http://example.com/file/" + file.Name);
        }

        private Task DeleteFileAsync(string url)
        {
            // TODO: delete file from file storage
            return Task.CompletedTask;
        }
    }
}
