﻿namespace MB.Application.Contracts.ArticleCategory;

public interface IArticleCategoryApplication
{
    List<ArticleCategoryViewModel> List();
    void Create(CreateArticleCategory command);
}