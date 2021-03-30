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

        public async Task<int> AddAsync(AddPropertyRequest request)
        {
            var newAttacments = new List<PropertyAttachment>();

            foreach (var file in request.AttachmentsToAdd)
            {
                var url = await UploadFileAsync(file);
                newAttacments.Add(new PropertyAttachment
                {
                    Name = file.Name,
                    Url = url,
                });
            }

            request.Attachments = request.Attachments.Concat(newAttacments);

            return await _client.AddPropertyAsync(request);
        }

        public async Task DeleteAsync(int id)
        {
            var property = await _client.GetByIdAsync(id);

            await _client.DeletePropertyAsync(id);

            foreach (var attachment in property.Attachments)
            {
                await DeleteFileAsync(attachment.Url);
            }
        }

        public Task<PropertyResponse> GetByIdAsync(int id)
        {
            return _client.GetByIdAsync(id);
        }

        public Task<IEnumerable<PropertyResponse>> GetAsync()
        {
            return _client.GetPropertiesAsync();
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
