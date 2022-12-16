using IHaveNeverGame.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace IHaveNeverGame.Models.Repository
{
    public class QuestionRepository : IRepository<Question>
    {
        private List<Question> questions;
        public IEnumerable<Question> Entities => questions;
        public QuestionRepository(IDataLoader<Question> dataLoader) => questions = dataLoader.LoadData().ToList();
        public void AddRange(IEnumerable<Question> entities) => questions = entities.ToList();
        public void Update(Question entity) => GetByID(entity.ID).Text = entity.Text;
        public Question GetByID(long id) => questions.Where(question => question.ID == id).First();
        public void Delete(long id) => questions.Remove(GetByID(id));
    }
}
