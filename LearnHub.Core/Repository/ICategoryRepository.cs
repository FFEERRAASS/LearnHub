using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Core.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
        bool CreateCategory(Category stu);
        bool UpdateCategory(Category stu);
        bool DeleteCategory(int id);
        Category GetCategoryById(int id);
    }
}
