using Newtonsoft.Json;
using Upstorm.Data.Configurations;
using Upstorm.Data.IRepositories;
using Upstorm.Domain.Commons;
using Upstorm.Domain.Entities;
using Upstorm.Domain.Enums;

namespace Upstorm.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        private string path;
        private long lastId = 0;

        // for checking user role admin or consumer
        User user = new User();
        public Repository()
        {
            if (typeof(TEntity) == typeof(User))
            {
                path = DatabasePath.USER_PATH;
            }
            
            AutoIncreamentId();
        }

        private async void AutoIncreamentId()
        {
            foreach (var item in await GetAllAsync())
            {
                if (item.Id > lastId)
                {
                    lastId = item.Id;
                }
            }
        }

        public async Task<TEntity> CreateAsync(TEntity model)
        {
            var entities = await GetAllAsync();
            
            model.Id = ++lastId;
            model.CreatedAt = DateTime.UtcNow;
            entities.Add(model);

            var text = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText(path, text);

            return model;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entities = await GetAllAsync();
            var deletingModel = entities.FirstOrDefault(x => x.Id == id);

            if (deletingModel is null)
            {
                return false;
            }

            entities.Remove(deletingModel);

            var text = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText(path, text);

            return true;
        }

        public async Task<List<TEntity>> GetAllAsync(Predicate<TEntity> predicate = null)
        {
            var text = File.ReadAllText(path);

            if (string.IsNullOrEmpty(text))
            {
                text = "[]";
                File.WriteAllText(path,"[]");
            }

            var results = JsonConvert.DeserializeObject<List<TEntity>>(text);

            return results;
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            var entities = await GetAllAsync();
            return entities.FirstOrDefault(x => x.Id == id);
        }

        public async Task<TEntity> UpdateAsync(TEntity model)
        {
            var entities = await GetAllAsync();
            var updatingModel = entities.FirstOrDefault(x => x.Id == model.Id);

            if (updatingModel is null)
            {
                return null;
            }

            int index = entities.IndexOf(model);

            entities.Remove(updatingModel);

            model.CreatedAt = updatingModel.CreatedAt;
            model.UpdatedAt = DateTime.UtcNow;

            entities.Insert(index, model);

            var text = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText(path, text);

            return model;
        }
    }
}
