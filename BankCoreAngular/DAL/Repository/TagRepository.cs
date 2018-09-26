using MemBankCoreAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemBankCoreAngular.DAL.Repository
{
    public class TagRepository : BaseRepository
    {
        public TagRepository(MemBankContext context)
        {
            this._context = context;
        }

        public IEnumerable<Tag> GetAll()
        {
            return this._context.Tag;
        }

        public IEnumerable<Tag> GetTagsForParentType(int parentTypeId)
        {
            return this._context.Tag.Where(tag => tag.ParentTypeId == parentTypeId).OrderByDescending(tag => tag.Text);
        }

        public IEnumerable<Tag> GetTagsForParent(int parentId)
        {
            return this._context.Tag.Where(tag => tag.ParentId == parentId).OrderByDescending(tag => tag.Text);
        }

        public IEnumerable<TagCloudData> GetTagCloudData(int parentTypeId)
        {
            return this._context.Tag.Where(tag => tag.ParentTypeId == parentTypeId)
                .GroupBy(tag => tag.Text)
                .Select(t => new TagCloudData
                {
                    Weight = t.Count(),
                    Text = t.Key,
                });
        }

        public Tag GetById(int id)
        {
            var item = _context.Tag.Find(id);
            if (item == null)
            {
                return null;
            }
            return item;
        }

        public void Insert(Tag tag)
        {
            this._context.Tag.Add(tag);
        }

        public void Delete(Tag tag)
        {
            this._context.Tag.Remove(tag);
        }

    }
}
