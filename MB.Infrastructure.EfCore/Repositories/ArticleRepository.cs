﻿using System.Globalization;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly MasterBlogDbContext _dbContext;

    public ArticleRepository(MasterBlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<ArticleViewModel> GetAll()
    {
        return _dbContext.Articles.Include(x=>x.ArticleCategory)
            .Select(x => new ArticleViewModel()
        {
            Id = x.Id,
            Title = x.Title,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            IsDeleted = x.IsDeleted
        }).ToList();
    }

    public void Create(Article entity)
    {
        _dbContext.Articles.Add(entity);
        _dbContext.SaveChanges();
    }

    public Article Get(long id)
    {
        return _dbContext.Articles.FirstOrDefault(x => x.Id == id);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public bool IsArticleExist(string title)
    {
        return _dbContext.Articles.Any(x => x.Title.Equals(title));
    }
}