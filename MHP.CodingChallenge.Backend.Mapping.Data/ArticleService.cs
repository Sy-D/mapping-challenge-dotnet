using System;
using System.Collections.Generic;
using MHP.CodingChallenge.Backend.Mapping.Data.DB;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO;

namespace MHP.CodingChallenge.Backend.Mapping.Data
{
    public class ArticleService
    {
        private ArticleRepository _articleRepository;
        private ArticleMapper _articleMapper;

        public ArticleService(ArticleRepository articleRepository, ArticleMapper articleMapper)
        {
            _articleRepository = articleRepository;
            _articleMapper = articleMapper;
        }

        public List<ArticleDto> GetAll()
        {
            List<Article> articles = _articleRepository.GetAll();

            var result = new List<ArticleDto>();
            foreach (var article in articles)
            {
                var articleDto = _articleMapper.Map(article);
                articleDto.SortBlocksByIndex();
                result.Add(articleDto);
            }

            return result;
        }

        public ArticleDto GetById(long id)
        {
            Article article = _articleRepository.FindById(id);

            if (article is null)
            {
                return null;
            }

            var result = _articleMapper.Map(article);
            result.SortBlocksByIndex();
            return result;
        }

        public object Create(ArticleDto articleDto)
        {
            Article create = _articleMapper.Map(articleDto);
            _articleRepository.Create(create);
            return _articleMapper.Map(create);
        }
    }
}
